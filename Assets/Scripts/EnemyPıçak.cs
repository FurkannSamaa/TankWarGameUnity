using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPýçak : MonoBehaviour
{

    public GameObject player;
    public Animator animator;
    public AudioSource sound;
    public Slider canbar;
    public float speed;
    public int health;
    private int coin;
    private int damage,minDamage;

    private float distance;

    void Start()
    {
        
        health = 200;
        canbar.maxValue = health;
        coin = 100;
        damage = 50;
        minDamage = 10;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 1.8f)
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isAttack", true);
        }
        else if (distance < 10) 
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("isWalk",true);
            animator.SetBool("isAttack", false);
        }
        else
        {
            animator.SetBool("isWalk",false);
            animator.SetBool("isAttack", false);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("PlayerCoin", PlayerPrefs.GetInt("PlayerCoin") + coin);
            
        }

        if (PlayerPrefs.GetInt("onSound") == 1)
        {
            sound.volume = 0.1f;
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
    public void Attack()
    {
        if (PlayerPrefs.GetInt("PlayerArmor") - damage > -minDamage)
        {
            PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - minDamage);
        }
        else
        {
            PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - damage + PlayerPrefs.GetInt("PlayerArmor"));
        }
    }
    public void PlaySound()
    {
        sound.Play();
    }

}
