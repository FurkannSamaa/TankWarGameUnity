using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySniper : MonoBehaviour
{

    public GameObject player;
    public Animator animator;
    public Slider canbar;
    public AudioSource sound;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 5f;
    private float attackCooldown;
    public int health;
    public int coin;
    private float distance;

    void Start()
    {
        health = 100;
        canbar.maxValue = health;

        coin = 100;
    }

    void Update()
    {
        attackCooldown += Time.deltaTime;

        distance = Vector2.Distance(transform.position, player.transform.position);
        if (PlayerPrefs.GetInt("onSound") == 1)
        {
            sound.volume = 1f;
        }
        else
        {
            sound.volume = 0;
        }

        if (distance < 10) 
        {
            if(attackCooldown > 0.5f)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * -bulletSpeed;
                sound.Play();
                attackCooldown = 0;
            }
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("PlayerCoin", PlayerPrefs.GetInt("PlayerCoin") + coin);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health -= PlayerPrefs.GetInt("PlayerDamage");
            canbar.value = health;
            canbar.gameObject.SetActive(true);
        }
    }
}
