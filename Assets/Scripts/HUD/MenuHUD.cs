using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHUD : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
