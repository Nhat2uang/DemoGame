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
    int b;
    int plantType;
    bool canCheck = true;

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
        InvokeRepeating("CheckWorkers", 0f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        WorkingTime();
    }

    //Thoi gian thu hoach
    void WorkingTime()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                if (PlayerPrefs.GetInt("w" + workerCode) == 2)
                {
                    Grow();
                }
                else if (PlayerPrefs.GetInt("w" + workerCode) == 3)
                {
                    Harvest();
                }
                canCheck = true;
                startTimer = false;
            }
        }
    }

    //Kiem tra trang thai. 0 la chua unlock, 1 la idle, 2 la gieo hat, 3 la thu hoach
    public void CheckWorkers()
    {
        status = PlayerPrefs.GetInt("w" + workerCode);
        if (canCheck)
        {
            //Chuyen tu trang thai idle sang work
            if (status == 1)
            {
                for (int i = 0; i < landGUIs.Length; i++)
                {
                    if (landGUIs[i].status == 1)
                    {
                        if (CheckSeedAmount() != 0)
                        {
                            a = i;
                            if (FindChildWithTag(farmPlaces[a], "Worker") == null)
                            {
                                PlayerPrefs.SetInt("w1" + workerCode, a);
                                this.transform.position = farmPlaces[a].transform.position;
                                this.transform.parent = farmPlaces[a].transform;
                                PlayerPrefs.SetInt("w" + workerCode, 2);
                                anim.SetBool("Work", true);
                                canCheck = false;
                                startTimer = true;
                                break;
                            }
                        }
                    }
                    else if (landGUIs[i].status == 3)
                    {
                        a = i;
                        if (FindChildWithTag(farmPlaces[a], "Worker") == null)
                        {
                            PlayerPrefs.SetInt("w1" + workerCode, a);
                            this.transform.position = farmPlaces[a].transform.position;
                            this.transform.parent = farmPlaces[a].transform;
                            PlayerPrefs.SetInt("w" + workerCode, 3);
                            anim.SetBool("Work", true);
                            canCheck = false;
                            startTimer = true;
                            break;
                        }
                    }
                }
            }

            //Chuyen tu trang thai work sang idle
            if (status == 2 || status == 3)
            {
                int b = PlayerPrefs.GetInt("w1" + workerCode);
                if (landGUIs[b].status == 2 || landGUIs[b].status == 1)
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
    }

    //Kiem tra so luong seed de gieo trong
    public int CheckSeedAmount()
    {
        if (ResourcesManager.Instance.tomatoSA >= 10)
        {
            plantType = 1;
        }
        else if (ResourcesManager.Instance.berrySA >= 10)
        {
            plantType = 2;
        }
        else if (ResourcesManager.Instance.strawSA >= 10)
        {
            plantType = 3;
        }
        else if (ResourcesManager.Instance.cowA >= 1)
        {
            plantType = 4;
        }
        return plantType;
    }
    //Tim kiem manh dat trong de gieo hat
    public void Grow()
    {
        landGUIs[a].Grow(plantType);
        timer = workTimer;
        plantType = 0;
    }

    //Tim kiem manh dat nao dang co trai de thu hoach
    public void Harvest()
    {
        landGUIs[a].Harvested();
        timer = workTimer;
    }

    //Tim child voi tag trong mot gameobject
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

    //Save Khi Quit
    public void OnApplicationQuit()
    {
        if (status == 2 || status == 3)
        {
            PlayerPrefs.SetInt("w" + workerCode, 1);
        }
    }

    //Save giua Scenes
    public void SaveBetweenScenes()
    {
        if (status == 2 || status == 3)
        {
            PlayerPrefs.SetInt("w" + workerCode, 1);
        }
    }
}
