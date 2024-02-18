using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public GameObject howtoplayPanel,settingsPanel;
    public Button nextButton, backButton;
    public Sprite[] sprites;
    public Image image;
    private int imageCounter;
    public Text musicText, soundText;
    public AudioSource music, sound;
    private void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.DeleteKey("PlayerCoin");
        PlayerPrefs.DeleteKey("PlayerDamage");
        PlayerPrefs.DeleteKey("PlayerMaxHealth");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerArmor");
        PlayerPrefs.DeleteKey("HealthUpgrade");
        PlayerPrefs.DeleteKey("DamageUpgrade");
        PlayerPrefs.DeleteKey("ArmorUpgrade");

        if (!PlayerPrefs.HasKey("onMusic"))
        {
            PlayerPrefs.SetInt("onMusic", 1);
        }
        if (!PlayerPrefs.HasKey("onSound"))
        {
            PlayerPrefs.SetInt("onSound", 1);
        }

    }
    private void Update()
    {
        if(imageCounter == sprites.Length - 1)
        {
            nextButton.interactable = false;
            backButton.interactable = true;

        }
        else if (imageCounter == 0)
        {
            backButton.interactable = false;
            nextButton.interactable = true;

        }
        else
        {
            nextButton.interactable= true;
            backButton.interactable = true;
        }
        if (PlayerPrefs.GetInt("onSound")==1)
        {
            sound.volume = 0.1f;
            soundText.text = "Sound : On";
        }
        else 
        { 
            sound.volume = 0;
            soundText.text = "Sound : Off";
        }
        if (PlayerPrefs.GetInt("onMusic")==1)
        {
            music.volume = 0.1f;
            musicText.text = "Music : On";
        }
        else
        {
            music.volume=0;
            musicText.text = "Music : Off";
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        sound.Play();
    }
    public void HowToPlay()
    {
        howtoplayPanel.SetActive(true);
        imageCounter = 0;
        image.sprite = sprites[imageCounter];
        sound.Play();
    }
    public void Setting()
    {
        settingsPanel.SetActive(true);
        sound.Play();
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void Exit(GameObject panel)
    {
        panel.SetActive(false);
        sound.Play();
    }
    public void Music(Text text)
    {
        if(PlayerPrefs.GetInt("onMusic")==1)
        {
            PlayerPrefs.SetInt("onMusic", 0);
        }
        else if(PlayerPrefs.GetInt("onMusic")==0)
        {
            PlayerPrefs.SetInt("onMusic", 1);
        }
        sound.Play();
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
        sound.Play();
    }
    public void NextImage()
    {
        imageCounter++;
        image.sprite = sprites[imageCounter];
        sound.Play();
    }
    public void BackImage()
    {
        imageCounter--;
        image.sprite = sprites[imageCounter];
        sound.Play();
    }
}
