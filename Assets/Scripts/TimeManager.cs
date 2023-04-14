using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;
    public static TimeManager Instance { get => instance; }

    public Resource TomatoData;
    public Resource BerryData;
    public Resource StrawData;
    public Resource CowData;

    public int tomatoTime1;
    public int tomatoTime2;

    public int berryTime1;
    public int berryTime2;

    public int strawTime1;
    public int strawTime2;

    public int cowTime1;
    public int cowTime2;

    string savedTime;
    DateTime savedDateTime;
    DateTime nowDateTime;
    public TMP_Text timeText; // Text ?? hi?n th? th?i gian

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime now = DateTime.Now; // L?y th?i gian hi?n t?i
        string timeString = now.ToString("hh:mm:ss"); // Chuy?n ??i thành chu?i theo ??nh d?ng hh:mm:ss
        timeText.text = timeString; // Hi?n th? chu?i lên màn hình
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetString("currentTime", DateTime.Now.ToString());

        string savedTime = PlayerPrefs.GetString("currentTime"); // L?y giá tr? chu?i t? PlayerPrefs
        DateTime savedDateTime = DateTime.Parse(savedTime); // Chuy?n ??i chu?i thành ??i t??ng DateTime
        TimeSpan duration = DateTime.Now.Subtract(savedDateTime); // Tính kho?ng th?i gian gi?a th?i gian hi?n t?i và th?i gian ?ã l?u
        Debug.Log("" + duration); // In ra màn hình
        nowDateTime = DateTime.Now;

        GetTimeData();
    }

    public void GetTimeData()
    {
        tomatoTime1 = TomatoData.life;
        tomatoTime2 = TomatoData.cycle;

        berryTime1 = BerryData.life;
        berryTime2 = BerryData.cycle;

        strawTime1 = StrawData.life;
        strawTime2 = StrawData.cycle;

        cowTime1 = CowData.life;
        cowTime2 = CowData.cycle;
    }
}
