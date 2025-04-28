using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartTheGame : MonoBehaviour
{
    public GameObject panelSettings;
    public Text textScore;

    [Header("Settings")]
    public int score;

    private void Update()
    {
        textScore.text = "Рекорд: " + score;
    }

    private void Start()
    {
        if (panelSettings != null)
        panelSettings.SetActive(false);
    }

    public void Play1()
    {
        SceneManager.LoadScene("Nikita");
        
    }

    public void Play2()
    {
        SceneManager.LoadScene("Max");
      
    }

    public void Play3()
    {
        SceneManager.LoadScene("Kirill");
       
    }
    public void Settings()
    {
        if (panelSettings.activeSelf == false)
        {
            panelSettings.SetActive(true);
        }
        else if (panelSettings.activeSelf == true)
        {
            panelSettings.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
