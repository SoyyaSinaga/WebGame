using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject screen;

    public void aktifin()
    {
        screen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        Time.timeScale = 1f;
        screen.SetActive(false);
    }

    public void toMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
