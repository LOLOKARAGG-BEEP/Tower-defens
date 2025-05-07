using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class ExitFromSettingMenu : MonoBehaviour
{
    public GameObject panelMainMenu;

    private void Start()
    {
        panelMainMenu.SetActive(false);
    }
    public void Back()
    {
        SceneManager.LoadScene("Nikita");
        //SceneManager.LoadScene(2)
    }
}