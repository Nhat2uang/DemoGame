using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WorkerGUI : MonoBehaviour
{
    public int workerCode;
    public int status;
    Animator anim;
    public GameObject[] farmPlaces;
    public LandGUI[] landGUIs;
    int a;

    public GameObject idle1;
    public GameObject idle2;
    public GameObject idle3;

    bool startTimer = false;
    public float workTimer = 2f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = workTimer;
        anim = GetComponent<Animator>();
        InvokeRepeating("CheckWorkers", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        WorkingTime();
    }

    void WorkingTime()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                Harvest();
                startTimer = false;
            }
        }
    }

    public void CheckWorkers()
    {
        status = PlayerPrefs.GetInt("w" + workerCode);

        //Chuyen tu trang thai idle sang work
        if (status == 1)
        {
            for (int i = 0; i < landGUIs.Length; i++)
            {
                if (landGUIs[i].status == 3)
                {
                    a = i;
                    if (FindChildWithTag(farmPlaces[a], "Worker") == null)
                    {
                        PlayerPrefs.SetInt("w1" + workerCode, a);
                        this.transform.position = farmPlaces[a].transform.position;
                        this.transform.parent = farmPlaces[a].transform;
                        PlayerPrefs.SetInt("w" + workerCode, 2);
                        anim.SetBool("Work", true);
                        startTimer = true;
                        break;
                    }
                }
            }
        }

        //Chuyen tu trang thai work sang idle
        if (status == 2)
        {
            int b = PlayerPrefs.GetInt("w1" + workerCode);
            if (landGUIs[b].status == 2)
            {
                if (workerCode == 1)
                {
                    this.transform.position = idle1.transform.position;
                    this.transform.parent = idle1.transform;
                    PlayerPrefs.SetInt("w" + workerCode, 1);
                    anim.SetBool("Work", false);
                }
                if (workerCode == 2)
                {
                    this.transform.position = idle2.transform.position;
                    this.transform.parent = idle2.transform;
                    PlayerPrefs.SetInt("w" + workerCode, 1);
                    anim.SetBool("Work", false);
                }
                if (workerCode == 3)
                {
                    this.transform.position = idle3.transform.position;
                    this.transform.parent = idle3.transform;
                    PlayerPrefs.SetInt("w" + workerCode, 1);
                    anim.SetBool("Work", false);
                }
            }
        }
    }

    public void Harvest()
    {
        landGUIs[a].Harvested();
        timer = workTimer;
    }

    GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;
        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }
        return child;
    }
}
