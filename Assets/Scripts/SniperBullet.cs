using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{
    public float life = 1.5f;
    private int damage;
    private int minDamage;

    private void Awake()
    {
        Destroy(gameObject,life);
        damage = 25;
        minDamage = 10;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
            if (PlayerPrefs.GetInt("PlayerArmor") - damage > -minDamage)
            {
                PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - minDamage);
            }
            else
            {
                PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerHealth") - damage + PlayerPrefs.GetInt("PlayerArmor"));
            }
            Destroy(gameObject);
        }
    }


}
