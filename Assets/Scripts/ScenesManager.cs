using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject[] workers;
    public GameObject[] farms;

    // Start is called before the first frame update
    void Start()
    {
        //Tu dong tim kiem cac object voi tag nhat dinh va add vao array
        if (SceneManager.GetActiveScene().name == "Game")
        { 
            workers = GameObject.FindGameObjectsWithTag("Worker");
            farms = GameObject.FindGameObjectsWithTag("LandGUI");
        }
    }

    //Start New Game
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

        PlayerPrefs.SetInt("Money", 10000);
        PlayerPrefs.SetInt("tomatoS", 10);
        PlayerPrefs.SetInt("tomato", 0);
        PlayerPrefs.SetInt("berryS", 10);
        PlayerPrefs.SetInt("berry", 0);
        PlayerPrefs.SetInt("strawS", 0);
        PlayerPrefs.SetInt("straw", 0);
        PlayerPrefs.SetInt("cow", 2);
        PlayerPrefs.SetInt("milk", 0);
        PlayerPrefs.SetString("savedTime", DateTime.MinValue.ToString());

        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    //Load Game
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Game -> Menu
    public void LoadMenu()
    {
        foreach (var item in workers)
        {
            WorkerGUI worker = item.GetComponent<WorkerGUI>();
            worker.SaveBetweenScenes();
        }

        foreach (var item in farms)
        {
            LandGUI land = item.GetComponent<LandGUI>();
            land.SaveBetweenScenes();
        }

        SaveLoad.Instance.Save();
        SceneManager.LoadScene("Menu");
    }

    //Thoat Game
    public void ExitGame()
    {
        Application.Quit();
    }
}
