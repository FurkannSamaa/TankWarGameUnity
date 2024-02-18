using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGarage : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteKey("inGarage");
        if (!PlayerPrefs.HasKey("inGarage"))
        {
            PlayerPrefs.SetInt("inGarage", 0);
        }
    }

    public void inTrueGarage()
    {
        PlayerPrefs.SetInt("inGarage", 1);
    }

   public void inGarage()
    {
        SceneManager.LoadScene(2);
    }
}
