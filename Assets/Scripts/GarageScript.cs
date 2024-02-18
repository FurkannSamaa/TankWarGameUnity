using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GarageScript : MonoBehaviour
{

    public Animator animator;
    public Text HealthText, DamageText, ArmorText ,CoinText,HealthUpgradeText, DamageUpgradeText, ArmorUpgradeText;
    public AudioSource sound;
    public Button HealthButton, DamageButton,ArmorButton;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        HealthText.text = PlayerPrefs.GetInt("PlayerMaxHealth") + "";
        DamageText.text = PlayerPrefs.GetInt("PlayerDamage") + "";
        ArmorText.text = PlayerPrefs.GetInt("PlayerArmor") + "";
        CoinText.text = PlayerPrefs.GetInt("PlayerCoin") + "$";
        HealthUpgradeText.text = PlayerPrefs.GetInt("HealthUpgrade")+"$";
        DamageUpgradeText.text = PlayerPrefs.GetInt("DamageUpgrade") + "$";
        ArmorUpgradeText.text = PlayerPrefs.GetInt("ArmorUpgrade") + "$";

        if (PlayerPrefs.GetInt("onSound") == 1)
        {
            sound.volume = 0.1f;
        }
        else
        {
            sound.volume = 0;
        }
        if (!(PlayerPrefs.GetInt("PlayerCoin") >= PlayerPrefs.GetInt("HealthUpgrade")))
        {
            HealthButton.interactable = false;
        }
        if (!(PlayerPrefs.GetInt("PlayerCoin") >= PlayerPrefs.GetInt("DamageUpgrade")))
        {
            DamageButton.interactable = false;

        }
        if (!(PlayerPrefs.GetInt("PlayerCoin") >= PlayerPrefs.GetInt("ArmorUpgrade")))
        {
            ArmorButton.interactable = false;

        }
    }

    public void PlaySound()
    {
        sound.Play();
    }
    public void ContinueGame()
    {
        PlayerPrefs.SetInt("PlayerHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
        animator.SetTrigger("GarageExit");
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
    public void HealthUpgrade()
    {
        if (PlayerPrefs.GetInt("PlayerCoin") >= PlayerPrefs.GetInt("HealthUpgrade"))
        {
            PlayerPrefs.SetInt("PlayerMaxHealth", PlayerPrefs.GetInt("PlayerMaxHealth") + 100);
            PlayerPrefs.SetInt("PlayerCoin", PlayerPrefs.GetInt("PlayerCoin") - PlayerPrefs.GetInt("HealthUpgrade"));
            PlayerPrefs.SetInt("HealthUpgrade", PlayerPrefs.GetInt("HealthUpgrade") * 2);
        }
        
    }
    public void DamageUpgrade()
    {
        if (PlayerPrefs.GetInt("PlayerCoin") >= PlayerPrefs.GetInt("DamageUpgrade"))
        {
            PlayerPrefs.SetInt("PlayerDamage", PlayerPrefs.GetInt("PlayerDamage") + 10);
            PlayerPrefs.SetInt("PlayerCoin", PlayerPrefs.GetInt("PlayerCoin") - PlayerPrefs.GetInt("DamageUpgrade"));
            PlayerPrefs.SetInt("DamageUpgrade", PlayerPrefs.GetInt("DamageUpgrade") * 2);
        }
        
    }
    public void ArmorUpgrade()
    {
        if (PlayerPrefs.GetInt("PlayerCoin") >= PlayerPrefs.GetInt("ArmorUpgrade"))
        {
            PlayerPrefs.SetInt("PlayerArmor", PlayerPrefs.GetInt("PlayerArmor") + 10);
            PlayerPrefs.SetInt("PlayerCoin", PlayerPrefs.GetInt("PlayerCoin") - PlayerPrefs.GetInt("ArmorUpgrade"));
            PlayerPrefs.SetInt("ArmorUpgrade", PlayerPrefs.GetInt("ArmorUpgrade") * 2);
        }
        
    }
   

}
