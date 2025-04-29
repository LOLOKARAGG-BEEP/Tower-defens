using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Igra : MonoBehaviour
{
    public GameObject panelSettings;


    public void StartGame()
    {
        SceneManager.LoadScene("Kirill");
    }

    public void Play2()
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
