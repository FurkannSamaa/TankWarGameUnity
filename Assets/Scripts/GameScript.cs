using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject PausePanel,MainMenuPanel,WinPanel,LosePanel;
    public Text musicText, soundText;
    public AudioSource music, sound;

    private bool esc = false;

    private void Awake()
    {
        Time.timeScale = 1;
        
    }


    public void Esc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc = !esc;
            PausePanel.SetActive(esc);
            

            if (esc)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                MainMenuPanel.SetActive(false);
            }
        }
    }
    public void Music(Text text)
    {
        if (PlayerPrefs.GetInt("onMusic") == 1)
        {
            PlayerPrefs.SetInt("onMusic", 0);
        }
        else if (PlayerPrefs.GetInt("onMusic") == 0)
        {
            PlayerPrefs.SetInt("onMusic", 1);
        }
    }
    public void Sound(Text text)
    {
        if (PlayerPrefs.GetInt("onSound") == 1)
        {
            PlayerPrefs.SetInt("onSound", 0);
        }
        else if (PlayerPrefs.GetInt("onSound") == 0)
        {
            PlayerPrefs.SetInt("onSound", 1);
        }
    }
    public void PlaySound()
    {
        sound.Play();
    }
    public void MainMenu()
    {
        MainMenuPanel.SetActive(true);
    }
    public void YesButton()
    {
        SceneManager.LoadScene(0);
    }
    public void NoButton()
    {
        MainMenuPanel.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void TryAgain()
    {
        PlayerPrefs.DeleteKey("PlayerCoin");
        PlayerPrefs.DeleteKey("PlayerDamage");
        PlayerPrefs.DeleteKey("PlayerMaxHealth");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerArmor");
        PlayerPrefs.DeleteKey("HealthUpgrade");
        PlayerPrefs.DeleteKey("DamageUpgrade");
        PlayerPrefs.DeleteKey("ArmorUpgrade");

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

        SceneManager.LoadScene(2);
    }
    public void MainMenu2()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("onSound") == 1)
        {
            sound.volume = 0.1f;
            soundText.text = "Sound : On";
        }
        else
        {
            sound.volume = 0;
            soundText.text = "Sound : Off";
        }
        if (PlayerPrefs.GetInt("onMusic") == 1)
        {
            music.volume = 0.1f;
            musicText.text = "Music : On";
        }
        else
        {
            music.volume = 0;
            musicText.text = "Music : Off";
        }

        Esc();
        if (PlayerPrefs.GetInt("PlayerHealth") <= 0)
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
