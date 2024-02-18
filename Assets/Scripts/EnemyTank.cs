using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTank : MonoBehaviour
{
    public GameObject player,WinPanel;
    public Animator animator;
    public Slider canbar;
    public Transform bulletSpawnPoint;
    public AudioSource sound;
    public GameObject bulletPrefab;
    private float bulletSpeed = 5f;
    private float attackCooldown;
    public int health;
    private float distance;


    void Start()
    {
        health = 750;
        canbar.maxValue = health;

    }

    void Update()
    {
        attackCooldown += Time.deltaTime;

        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            animator.SetBool("TankAttack",true);
        }
        else
        {
            animator.SetBool("TankAttack", false);
        }

        if (health <= 0)
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);
            Destroy(gameObject);

        }
        if (PlayerPrefs.GetInt("onSound") == 1)
        {
            sound.volume = 0.05f;
        }
        else
        {
            sound.volume = 0;
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

    public void AttackCooldown()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * -bulletSpeed;
        sound.Play();
    }

}
