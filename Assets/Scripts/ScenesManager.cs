using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("eLv", 1);

        PlayerPrefs.SetInt("w1", 0);
        PlayerPrefs.SetInt("w2", 1);
        PlayerPrefs.SetInt("w3", 0);

        PlayerPrefs.SetInt("land1", 0);
        PlayerPrefs.SetInt("land2", 0);
        PlayerPrefs.SetInt("land3", 0);
        PlayerPrefs.SetInt("land4", 0);
        PlayerPrefs.SetInt("land6", 0);
        PlayerPrefs.SetInt("land7", 1);
        PlayerPrefs.SetInt("land8", 1);
        PlayerPrefs.SetInt("land9", 1);

        PlayerPrefs.SetInt("Money", 100000);
        PlayerPrefs.SetInt("tomatoS", 10);
        PlayerPrefs.SetInt("tomato", 0);
        PlayerPrefs.SetInt("berryS", 10);
        PlayerPrefs.SetInt("berry", 0);
        PlayerPrefs.SetInt("strawS", 0);
        PlayerPrefs.SetInt("straw", 0);
        PlayerPrefs.SetInt("cow", 2);
        PlayerPrefs.SetInt("milk", 0);

        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
