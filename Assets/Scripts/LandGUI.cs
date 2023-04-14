using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

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
    bool startTimer = false;
    bool start_timer1 = false;
    bool start_timer2 = false;

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
        InvokeRepeating("CheckLandStatus", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            plantName_Text.text = plantName;
            //Cycle_Timer
            if (start_timer1)
            {
                if (timer1 > 0)
                {
                    timer1 -= Time.deltaTime;
                    timer1_Text.text = Mathf.Round(timer1).ToString();
                }
                if (timer1 < 0)
                {
                    timer1 = 0;
                    SaveLandStatus(3, plantType);
                }
            }

            //Life_Timer
            if (start_timer2)
            {
                if (timer2 > 0)
                {
                    timer2 -= Time.deltaTime;
                    timer2_Text.text = Mathf.Round(timer2).ToString();
                }
                if (timer2 < 0)
                {
                    timer1 = timer2 = 0;
                    SaveLandStatus(1, 0);
                }
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
            startTimer = true;
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
            start_timer1 = false;
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
            plantName = ResourcesManager.Instance.tName;
            if (isOnLife == 0)
            {
                timer2 = ResourcesManager.Instance.tomatoLife;
                PlayerPrefs.SetInt("land2" + landCode, 1);
            }
        }
        else if (plantType == 2)
        {
            timer1 = ResourcesManager.Instance.berryCycle;
            plantName = ResourcesManager.Instance.bName;
            if (isOnLife == 0)
            {
                timer2 = ResourcesManager.Instance.berryLife;
                PlayerPrefs.SetInt("land2" + landCode, 1);
            }
        }
        else if (plantType == 3)
        {
            timer1 = ResourcesManager.Instance.strawCycle;
            plantName = ResourcesManager.Instance.sName;
            if (isOnLife == 0)
            {
                timer2 = ResourcesManager.Instance.strawLife;
                PlayerPrefs.SetInt("land2" + landCode, 1);
            }
        }
        else if (plantType == 4)
        {
            timer1 = ResourcesManager.Instance.cowCycle;
            plantName = ResourcesManager.Instance.cName;
            if (isOnLife == 0)
            {
                timer2 = ResourcesManager.Instance.cowLife;
                PlayerPrefs.SetInt("land2" + landCode, 1);
            }
        }
    }

    //Spawn seed va check xem seed co tai hay khong de spawn ra. GetPlantInfor de tien hanh lay thoi gian cho timer1 va timer2
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

        //
        if (PlayerPrefs.GetInt("land" + landCode) == 2)
        {
            GetPlantInfor();
        }
    }

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

        //
        if (PlayerPrefs.GetInt("land" + landCode) == 2)
        {
            GetPlantInfor();
        }
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
            SaveLoad.Instance.Save();
        }
    }

    public void SaveLandStatus(int i, int j)
    {
        PlayerPrefs.SetInt("land" + landCode, i);
        PlayerPrefs.SetInt("land1" + landCode, j);
        PlayerPrefs.Save();
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
