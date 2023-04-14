using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Path;
using UnityEngine;

public class WorkersManager : MonoBehaviour
{
    private static WorkersManager instance;
    public static WorkersManager Instance { get => instance; }

    public int workerPrice = 500;

    public int w1;
    public int w2;
    public int w3;

    public GameObject lock1;
    public GameObject lock3;

    public TMP_Text[] price_Text;
    public GameObject notE;

    public GameObject idle1;
    public GameObject idle2;   
    public GameObject idle3;

    public GameObject[] farmLocations;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckWorkers", 0f, 0.5f);
    }


    public void CheckWorkers()
    {
        foreach (var item in price_Text)
        {
            item.text = workerPrice.ToString();
        }

        w1 = PlayerPrefs.GetInt("w1");
        w3 = PlayerPrefs.GetInt("w3");

        if (w1 != 0)
        {
            lock1.SetActive(false);
        }
        if (w3 != 0)
        {
            lock3.SetActive(false);
        }
    }

    public void BuyWorker(int i)
    {
        if (i == 1)
        {
            if (ResourcesManager.Instance.goldA >= workerPrice)
            {
                ResourcesManager.Instance.goldA -= workerPrice;
                w1 = 1;
                PlayerPrefs.SetInt("w1", 1);
                lock1.SetActive(false);
            }
            else notE.SetActive(true);
        }
        if (i == 3)
        {
            if (ResourcesManager.Instance.goldA >= workerPrice)
            {
                ResourcesManager.Instance.goldA -= workerPrice;
                w3 = 1;
                PlayerPrefs.SetInt("w3", 1);
                lock3.SetActive(false);
            }
            else notE.SetActive(true);

        }
        PlayerPrefs.Save();
    }
}
