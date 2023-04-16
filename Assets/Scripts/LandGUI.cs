using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System;

public class LandGUI : MonoBehaviour
{
    public int landCode;
    public int status;
    public int plantType;
    public int canChecked;
    public int isOnLife;
    public GameObject notE;

    public TMP_Text plantName_Text;
    public string plantName;
    public TMP_Text timer1_Text;
    public TMP_Text timer2_Text;
    public float timer1;
    public float timer2;
    public bool start_timer;
    public bool start_timer1 = false;
    public bool start_timer2 = false;

    public GameObject mode1;
    public GameObject mode2;

    public GameObject tomato1;
    public GameObject tomato2;

    public GameObject berry1;
    public GameObject berry2;

    public GameObject straw1;
    public GameObject straw2;

    public GameObject cow1;
    public GameObject cow2;

    // Start is called before the first frame update
    void Start()
    {
        TimePass();
        Invoke("GetPlantName", 0.02f);
        InvokeRepeating("CheckLandStatus", 0f, 0.05f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeCounter();
    }

    //Dem thoi gian
    public void TimeCounter()
    {
        plantName_Text.text = plantName;
        //Cycle_Timer
        if (start_timer)
        {
            if (timer1 > 0)
            {
                timer1 -= Time.fixedDeltaTime;
                timer1_Text.text = Mathf.Round(timer1).ToString();
            }
            if (timer1 < 0)
            {
                timer1 = 0;
                SaveLandStatus(3, PlayerPrefs.GetInt("land1" + landCode));
            }
        }

        //Life_Timer
        if (start_timer2)
        {
            if (timer2 > 0)
            {
                timer2 -= Time.fixedDeltaTime;
                timer2_Text.text = Mathf.Round(timer2).ToString();
            }
            if (timer2 < 0)
            {
                timer1 = timer2 = 0;
                SaveLandStatus(1, 0);
            }
        }
    }

    //0 = dat chua mo, 1 = dat chua gieo hat, 2 = cay dang phat trien, 3 = co the thu hoach
    //Check xem voi cac trang thai tren thi hinh anh da spawn ra dung hay chua va setup GUI, timer tuong ung voi tung trang thai
    public void CheckLandStatus()
    {
        status = PlayerPrefs.GetInt("land" + landCode);
        plantType = PlayerPrefs.GetInt("land1" + landCode);
        
        if (status == 1)
        {
            PlayerPrefs.SetInt("land2" + landCode, 0);
            mode1.SetActive(true);
            mode2.SetActive(false);
            timer1 = timer2 = 0;
            start_timer1 = start_timer2 = false;
            if (FindChildWithTag(this.gameObject, "Seed"))
            {
                Destroy(FindChildWithTag(this.gameObject, "Seed"));
            }
            if (FindChildWithTag(this.gameObject, "Product"))
            {
                Destroy(FindChildWithTag(this.gameObject, "Product"));
            }
        }
        else if (status == 2)
        {
            mode1.SetActive(false);
            mode2.SetActive(true);
            start_timer1 = true;
            start_timer2 = true;

            if (FindChildWithTag(this.gameObject, "Product"))
            {
                Destroy(FindChildWithTag(this.gameObject, "Product"));
            }
            if (FindChildWithTag(this.gameObject, "Seed") == null)
            {
                Grow2(plantType);
            }
        }
        else if (status == 3)
        {
            mode1.SetActive(false);
            mode2.SetActive(true);
            start_timer1 = false;
            start_timer2 = true;
            timer1_Text.text = "HARVEST";

            if (FindChildWithTag(this.gameObject, "Seed"))
            {
                Destroy(FindChildWithTag(this.gameObject, "Seed"));
            }

            if (FindChildWithTag(this.gameObject, "Product") == null)
            {
                Harvest(plantType);
            }
        }
    }

    //Xet theo trang thai status lay thoi gian cho timer
    public void GetPlantInfor()
    {
        status = PlayerPrefs.GetInt("land" + landCode);
        plantType = PlayerPrefs.GetInt("land1" + landCode);
        isOnLife = PlayerPrefs.GetInt("land2" + landCode);

        if (plantType == 1)
        {
            timer1 = ResourcesManager.Instance.tomatoCycle;
            timer1 -= timer1 * EquipmentManager.Instance.Performance();
            plantName = ResourcesManager.Instance.tName;
            if (isOnLife == 0)
            {
                timer2 = ResourcesManager.Instance.tomatoLife;
                timer2 -= timer2 * EquipmentManager.Instance.Performance();
                PlayerPrefs.SetInt("land2" + landCode, 1);
            }
        }
        else if (plantType == 2)
        {
            timer1 = ResourcesManager.Instance.berryCycle;
            timer1 -= timer1 * EquipmentManager.Instance.Performance();
            plantName = ResourcesManager.Instance.bName;
            if (isOnLife == 0)
            {
                timer2 = ResourcesManager.Instance.berryLife;
                timer2 -= timer2 * EquipmentManager.Instance.Performance();
                PlayerPrefs.SetInt("land2" + landCode, 1);
            }
        }
        else if (plantType == 3)
        {
            timer1 = ResourcesManager.Instance.strawCycle;
            timer1 -= timer1 * EquipmentManager.Instance.Performance();
            plantName = ResourcesManager.Instance.sName;
            if (isOnLife == 0)
            {
                timer2 = ResourcesManager.Instance.strawLife;
                timer2 -= timer2 * EquipmentManager.Instance.Performance();
                PlayerPrefs.SetInt("land2" + landCode, 1);
            }
        }
        else if (plantType == 4)
        {
            timer1 = ResourcesManager.Instance.cowCycle;
            timer1 -= timer1 * EquipmentManager.Instance.Performance();
            plantName = ResourcesManager.Instance.cName;
            if (isOnLife == 0)
            {
                timer2 = ResourcesManager.Instance.cowLife;
                timer2 -= timer2 * EquipmentManager.Instance.Performance();
                PlayerPrefs.SetInt("land2" + landCode, 1);
            }
        }
    }

    //Lay ten cho cay
    public void GetPlantName()
    {
        plantType = PlayerPrefs.GetInt("land1" + landCode);
        if (plantType == 1)
        {
            plantName = ResourcesManager.Instance.tName;
        }
        if (plantType == 2)
        {
            plantName = ResourcesManager.Instance.bName;
        }
        if (plantType == 3)
        {
            plantName = ResourcesManager.Instance.sName;
        }
        if (plantType == 4)
        {
            plantName = ResourcesManager.Instance.cName;
        }
    }

    //Spawn seed. GetPlantInfor de tien hanh lay thoi gian cho timer1 va timer2
    public void Grow(int i)
    {
        status = PlayerPrefs.GetInt("land" + landCode);
        GameObject position = LandsManager.Instance.GetLandPosition(landCode);

        if (i == 1)
        {
            if (ResourcesManager.Instance.tomatoSA >= 10)
            {
                ResourcesManager.Instance.tomatoSA -= 10;
                SaveLandStatus(2, i);
                Instantiate(tomato1, position.transform.position, tomato1.transform.rotation, this.gameObject.transform);
                SaveLoad.Instance.Save();
            }
            else notE.SetActive(true);
        }
        else if (i == 2)
        {
            if (ResourcesManager.Instance.berrySA >= 10)
            {
                ResourcesManager.Instance.berrySA -= 10;
                SaveLandStatus(2, i);
                Instantiate(berry1, position.transform.position, berry1.transform.rotation, this.gameObject.transform);
                SaveLoad.Instance.Save();
            }
            else notE.SetActive(true);
        }
        else if (i == 3)
        {
            if (ResourcesManager.Instance.strawSA >= 10)
            {
                ResourcesManager.Instance.strawSA -= 10;
                SaveLandStatus(2, i);
                Instantiate(straw1, position.transform.position, straw1.transform.rotation, this.gameObject.transform);
                SaveLoad.Instance.Save();
            }
            else notE.SetActive(true);
        }
        else if (i == 4)
        {
            if (ResourcesManager.Instance.cowA >= 1)
            {
                ResourcesManager.Instance.cowA -= 1;
                SaveLandStatus(2, i);
                Instantiate(cow1, new Vector3(position.transform.position.x + 2.5f, position.transform.position.y, position.transform.position.z), cow1.transform.rotation, this.gameObject.transform);
                SaveLoad.Instance.Save();
            }
            else notE.SetActive(true);
        }
        
        //Lay gia tri cho timer1 va timer2
        if (PlayerPrefs.GetInt("land" + landCode) == 2)
        {
            GetPlantInfor();
        }
    }

    //Check xem seed co ton tai hay khong de spawn ra
    public void Grow2(int i)
    {
        status = PlayerPrefs.GetInt("land" + landCode);
        GameObject position = LandsManager.Instance.GetLandPosition(landCode);
        
        if (i == 1)
        {
            Instantiate(tomato1, position.transform.position, tomato1.transform.rotation, this.gameObject.transform);
        }
        else if (i == 2)
        {
            Instantiate(berry1, position.transform.position, berry1.transform.rotation, this.gameObject.transform);
        }
        else if (i == 3)
        {
            Instantiate(straw1, position.transform.position, straw1.transform.rotation, this.gameObject.transform);
        }
        else if (i == 4)
        {
            Instantiate(cow1, new Vector3(position.transform.position.x + 2.5f, position.transform.position.y, position.transform.position.z), cow1.transform.rotation, this.gameObject.transform);
        }
        SaveLandStatus(status, plantType);
    }


    //Spawn product va check xem product co ton tai hay khong de spawn ra
    public void Harvest(int i)
    {
        GameObject position = LandsManager.Instance.GetLandPosition(landCode);
        if (i == 1)
        {
            Instantiate(tomato2, position.transform.position, tomato2.transform.rotation, this.gameObject.transform);
        }
        else if (i == 2)
        {
            Instantiate(berry2, position.transform.position, berry2.transform.rotation, this.gameObject.transform);
        }
        else if (i == 3)
        {
            Instantiate(straw2, position.transform.position, straw2.transform.rotation, this.gameObject.transform);
        }
        else if (i == 4)
        {
            Instantiate(cow2, new Vector3(position.transform.position.x + 2.5f, position.transform.position.y, position.transform.position.z), cow2.transform.rotation, this.gameObject.transform);
        }
    }

    //Bi thu hoach: Chuyen doi tu status 3 sang 2
    public void Harvested()
    {
        if (PlayerPrefs.GetInt("land" + landCode) == 3)
        {
            PlayerPrefs.SetInt("land" + landCode, 2);
            plantType = PlayerPrefs.GetInt("land1" + landCode);
            if (plantType == 1)
            {
                ResourcesManager.Instance.tomatoA += 1;
            }
            else if (plantType == 2)
            {
                ResourcesManager.Instance.berryA += 1;
            }
            else if (plantType == 3)
            {
                ResourcesManager.Instance.strawA += 1;
            }
            else if (plantType == 4)
            {
                ResourcesManager.Instance.milkA += 1;
            }
            GetPlantInfor();
            SaveLoad.Instance.Save();
        }
    }

    //Save vao PlayerPrefts
    public void SaveLandStatus(int i, int j)
    {
        PlayerPrefs.SetInt("land" + landCode, i);
        PlayerPrefs.SetInt("land1" + landCode, j);
        PlayerPrefs.Save();
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

    //Tinh toan thoi gian da troi qua va apply cho timer1 timer2
    public void TimePass()
    {
        DateTime savedTime = DateTime.Parse(PlayerPrefs.GetString("savedTime"));
        DateTime currentTime = DateTime.Now;
        TimeSpan timeSpan = currentTime.Subtract(savedTime);
        float duration = (float)timeSpan.TotalSeconds;
        float temp_t1 = PlayerPrefs.GetFloat("timer1" + landCode);
        float temp_t2 = PlayerPrefs.GetFloat("timer2" + landCode);

        if (PlayerPrefs.GetInt("land" + landCode) != 0)
        {
            if (duration >= temp_t1)
            {
                timer1 = -1;
            }
            else 
            {
                timer1 = temp_t1 - duration;
            }

            if (duration >= temp_t2)
            {
                timer2 = -1;
            }
            else
            {
                timer2 = temp_t2 - duration;
            }
            start_timer1 = start_timer2 = true;
        }
    }

    //Save Khi Thoat
    public void OnApplicationQuit()
    {
        if (status == 3)
        {
            PlayerPrefs.SetInt("land" + landCode, status);
        }
        PlayerPrefs.SetInt("land1" + landCode, plantType);
        PlayerPrefs.SetFloat("timer1" + landCode, timer1);
        PlayerPrefs.SetFloat("timer2" + landCode, timer2);
        PlayerPrefs.SetString("savedTime", DateTime.Now.ToString());
    }

    //Save Giua Scene
    public void SaveBetweenScenes()
    {
        if (status == 3)
        {
            PlayerPrefs.SetInt("land" + landCode, status);
        }
        PlayerPrefs.SetInt("land1" + landCode, plantType);
        PlayerPrefs.SetFloat("timer1" + landCode, timer1);
        PlayerPrefs.SetFloat("timer2" + landCode, timer2);
        PlayerPrefs.SetString("savedTime", DateTime.Now.ToString());
    }
}