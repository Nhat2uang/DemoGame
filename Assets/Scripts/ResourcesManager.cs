using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
    private static ResourcesManager instance;
    public static ResourcesManager Instance { get => instance; }

    public int goldA;
    public TMP_Text gold_Text;
    public GameObject notE;

    [Header("TomatoSeed")]
    public string tName;
    public int tomatoSA;
    public int tomatoSPrice;
    public TMP_Text tS_text;
    public int tomatoLife;
    public int tomatoCycle;
    [Header("TomatoProduct")]
    public int tomatoA;
    public int tomatoPrice;
    public TMP_Text t_text;

    [Header("BerrySeed")]
    public string bName;
    public int berrySA;
    public int berrySPrice;
    public TMP_Text bS_text;
    public int berryLife;
    public int berryCycle;
    [Header("BerryProduct")]
    public int berryA;
    public int berryPrice;
    public TMP_Text b_text;

    [Header("StrawberrySeed")]
    public string sName;
    public int strawSA;
    public int strawSPrice;
    public TMP_Text sS_text;
    public int strawLife;
    public int strawCycle;
    [Header("StrawberryProduct")]
    public int strawA;
    public int strawPrice;
    public TMP_Text s_text;

    [Header("Cow")]
    public string cName;
    public int cowA;
    public int cowPrice;
    public TMP_Text cow_text;
    public int cowLife;
    public int cowCycle;
    [Header("Milk")]
    public int milkA;
    public int milkPrice;
    public TMP_Text milk_text;

    public Resource tomatoSeed;
    public Resource tomatoProduct;

    public Resource berrySeed;
    public Resource berryProduct;

    public Resource strawberrySeed;
    public Resource strawberryProduct;

    public Resource cowSeed;
    public Resource milkProduct;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadAmount();
        InvokeRepeating("UpdateAmount", 0f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveAmount()
    {
        PlayerPrefs.SetInt("Money", goldA);
        PlayerPrefs.SetInt("tomatoS", tomatoSA);
        PlayerPrefs.SetInt("tomato", tomatoA);
        PlayerPrefs.SetInt("berryS", berrySA);
        PlayerPrefs.SetInt("berry", berryA);
        PlayerPrefs.SetInt("strawS", strawSA);
        PlayerPrefs.SetInt("straw", strawA);
        PlayerPrefs.SetInt("cow", cowA);
        PlayerPrefs.SetInt("milk", milkA);
        PlayerPrefs.Save();
    }

    public void LoadAmount()
    {
        goldA = PlayerPrefs.GetInt("Money");
        tomatoSA = PlayerPrefs.GetInt("tomatoS");
        tomatoA = PlayerPrefs.GetInt("tomato");
        berrySA = PlayerPrefs.GetInt("berryS");
        berryA = PlayerPrefs.GetInt("berry");
        strawSA = PlayerPrefs.GetInt("strawS");
        strawA = PlayerPrefs.GetInt("straw");
        cowA = PlayerPrefs.GetInt("cow");
        milkA = PlayerPrefs.GetInt("milk");

        tName = tomatoProduct.name;
        tomatoSPrice = tomatoSeed.price;
        tomatoLife = tomatoSeed.life;
        tomatoCycle = tomatoSeed.cycle;
        tomatoPrice = tomatoProduct.price;

        bName = berryProduct.name;
        berrySPrice = berrySeed.price;
        berryLife = berrySeed.life;
        berryCycle = berrySeed.cycle;
        berryPrice = berryProduct.price;

        sName = strawberryProduct.name;
        strawSPrice = strawberrySeed.price;
        strawLife = strawberrySeed.life;
        strawCycle = strawberrySeed.cycle;
        strawPrice = strawberryProduct.price;

        cName = cowSeed.name;
        cowPrice = cowSeed.price;
        cowLife = cowSeed.life;
        cowCycle = cowSeed.cycle;
        milkPrice = milkProduct.price;


        gold_Text.text = goldA.ToString();
        tS_text.text = tomatoSA.ToString();
        bS_text.text = berrySA.ToString();
        sS_text.text = strawSA.ToString();
        cow_text.text = cowA.ToString();
        t_text.text = tomatoA.ToString();
        b_text.text = berryA.ToString();
        s_text.text = strawA.ToString();
        milk_text.text = milkA.ToString();
    }

    public void UpdateAmount()
    {
        gold_Text.text = goldA.ToString();
        tS_text.text = tomatoSA.ToString();
        bS_text.text = berrySA.ToString();
        sS_text.text = strawSA.ToString();
        cow_text.text = cowA.ToString();
        t_text.text = tomatoA.ToString();
        b_text.text = berryA.ToString();
        s_text.text = strawA.ToString();
        milk_text.text = milkA.ToString();
    }

    public void BuySeed(int i)
    {
        if (i == 1)
        {
            if (goldA >= tomatoSPrice)
            {
                goldA -= tomatoSPrice;
                tomatoSA += 10;
            }
            else
            {
                notE.SetActive(true);
            }
        }
        if (i == 2)
        {
            if (goldA >= berrySPrice)
            {
                goldA -= berrySPrice;
                berrySA += 10;
            }
            else
            {
                notE.SetActive(true);
            }
        }
        if (i == 3)
        {
            if (goldA >= strawSPrice)
            {
                goldA -= strawSPrice;
                strawSA += 10;
            }
            else
            {
                notE.SetActive(true);
            }
        }
        if (i == 4)
        {
            if (goldA >= cowPrice)
            {
                goldA -= cowPrice;
                cowA += 1;
            }
            else
            {
                notE.SetActive(true);
            }
        }
        SaveAmount();
    }

    public void SellAll()
    {
        int amount = (tomatoA * tomatoPrice) + (berryA * berryPrice) + (strawA * strawPrice) + (milkA * milkPrice);
        goldA += amount;
        tomatoA = berryA = strawA = milkA = 0;
        SaveLoad.Instance.Save();
    }
}
