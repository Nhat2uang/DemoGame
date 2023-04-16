using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LandsManager : MonoBehaviour
{
    private static LandsManager instance;
    public static LandsManager Instance { get => instance; }

    public int landPrice = 500;

    public int l1;
    public int l2;
    public int l3;
    public int l4;
    public int l6;

    public GameObject[] locations;
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject lock6;

    public TMP_Text[] price_Text; 
    public GameObject notE;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InvokeRepeating("CheckLands", 0f, 0.5f);
    }

    //Kiem tra xem dat da duoc mua hay chua
    public void CheckLands()
    {
        foreach (var item in price_Text)
        {
            item.text = landPrice.ToString();
        }

        l1 = PlayerPrefs.GetInt("land1");
        l2 = PlayerPrefs.GetInt("land2");
        l3 = PlayerPrefs.GetInt("land3");
        l4 = PlayerPrefs.GetInt("land4");
        l6 = PlayerPrefs.GetInt("land6");

        if (l1 != 0)
        {
            lock1.SetActive(false);
        }
        if (l2 != 0)
        {
            lock2.SetActive(false);
        }
        if (l3 != 0)
        {
            lock3.SetActive(false);
        }
        if (l4 != 0)
        {
            lock4.SetActive(false);
        }
        if (l6 != 0)
        {
            lock6.SetActive(false);
        }
    }

    //Mua dat
    public void BuyLand(int i)
    {
        if (i == 1)
        {
            if (ResourcesManager.Instance.goldA >= landPrice)
            {
                ResourcesManager.Instance.goldA -= landPrice;
                lock1.SetActive(false);
                PlayerPrefs.SetInt("land" + i, 1);
            }
            else
            {
                notE.SetActive(true);
            }
        }
        else if (i == 2)
        {
            if (ResourcesManager.Instance.goldA >= landPrice)
            {
                ResourcesManager.Instance.goldA -= landPrice;
                lock2.SetActive(false);
                PlayerPrefs.SetInt("land" + i, 1);
            }
            else
            {
                notE.SetActive(true);
            }
        }
        else if (i == 3)
        {
            if (ResourcesManager.Instance.goldA >= landPrice)
            {
                ResourcesManager.Instance.goldA -= landPrice;
                lock3.SetActive(false);
                PlayerPrefs.SetInt("land" + i, 1);
            }
            else
            {
                notE.SetActive(true);
            }
        }
        else if (i == 4)
        {
            if (ResourcesManager.Instance.goldA >= landPrice)
            {
                ResourcesManager.Instance.goldA -= landPrice;
                lock4.SetActive(false);
                PlayerPrefs.SetInt("land" + i, 1);
            }
            else
            {
                notE.SetActive(true);
            }
        }
        else if (i == 6)
        {
            if (ResourcesManager.Instance.goldA >= landPrice)
            {
                ResourcesManager.Instance.goldA -= landPrice;
                lock6.SetActive(false);
                PlayerPrefs.SetInt("land" + i, 1);
            }
            else
            {
                notE.SetActive(true);
            }
        }
    }

    //Kiem tra vi tri cua dat
    public GameObject GetLandPosition(int i)
    {
        if (i < 5)
        {
            return locations[i - 1];
        }
        else return locations[i-2];
    }
}
