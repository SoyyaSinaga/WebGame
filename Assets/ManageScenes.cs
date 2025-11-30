using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public GameObject difficulty;

    void Start()
    {
        difficulty.SetActive(false);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }


    public void ChooseDiff()
    {
        difficulty.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void oto()
    {
        SceneManager.LoadScene("ez");
    }

    public void ani()
    {
        SceneManager.LoadScene("mid");
    }
}
