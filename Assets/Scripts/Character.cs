using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    float horizontal;
    public float speed=3f;
    public Rigidbody2D rb;
    public float baseTime;
    public Slider canBar;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 5f;
    public Animator animator,garageAnimator;
    public AudioSource TankShoot;
    private bool inGarage;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerCoin"))
        {
            PlayerPrefs.SetInt("PlayerCoin", 0);
        }
        if (!PlayerPrefs.HasKey("PlayerDamage"))
        {
            PlayerPrefs.SetInt("PlayerDamage", 20);
        }
        if (!PlayerPrefs.HasKey("PlayerMaxHealth"))
        {
            PlayerPrefs.SetInt("PlayerMaxHealth", 200);
        }
        if (!PlayerPrefs.HasKey("PlayerHealth"))
        {
            PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
        }
        if (!PlayerPrefs.HasKey("PlayerArmor"))
        {
            PlayerPrefs.SetInt("PlayerArmor", 10);
        }
        if (!PlayerPrefs.HasKey("HealthUpgrade"))
        {
            PlayerPrefs.SetInt("HealthUpgrade", 50);
        }
        if (!PlayerPrefs.HasKey("DamageUpgrade"))
        {
            PlayerPrefs.SetInt("DamageUpgrade", 50);
        }
        if (!PlayerPrefs.HasKey("ArmorUpgrade"))
        {
            PlayerPrefs.SetInt("ArmorUpgrade", 50);
        }
        canBar.maxValue = PlayerPrefs.GetInt("PlayerMaxHealth");
    }

    private void Update()
    {
        print(PlayerPrefs.GetInt("PlayerHealth"));
        canBar.value = PlayerPrefs.GetInt("PlayerHealth");
        if(canBar.value == PlayerPrefs.GetInt("PlayerMaxHealth"))
        {
            canBar.gameObject.SetActive(false);
        }
        else
        {
            canBar.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("inGarage") == 1)
            inGarage = false;
        else
            inGarage = true;
        if (PlayerPrefs.GetInt("onSound") == 1)
        {
            TankShoot.volume = 0.05f;
        }
        else
        {
            TankShoot.volume = 0;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetMouseButtonDown(0)&&Time.timeScale>0&&!inGarage)
        {
            animator.SetTrigger("TankAttack");
        }
        if (Input.GetKey(KeyCode.B))
        {
            baseTime += Time.deltaTime;
            if (baseTime >= 3)
            {
                gameObject.transform.position = new Vector2(-18f, -4.663544f);
            }
        }
        else
        {
            baseTime = 0;
        }
    }
    private void FixedUpdate()
    {
        if (!inGarage)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Garage") && Input.GetKey(KeyCode.Space))
        {

            garageAnimator.SetTrigger("GarageClose");
            PlayerPrefs.SetInt("inGarage", 0);
        }
    }

    public void TankAttack()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        PlaySound();
    }
    public void PlaySound()
    {
        TankShoot.Play();
    }
}
