using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    private static EquipmentManager instance;
    public static EquipmentManager Instance { get => instance; }

    public Resource equipment;
    public int level;
    public float performance = 0.1f;
    public TMP_Text level_Text;
    public TMP_Text shop_Level;
    public GameObject notE;
    public GameObject maxLv;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckLevel", 0f, 0.5f);
    }

    //Kiem tra va update level cua cong cu
    public void CheckLevel()
    {
        level = PlayerPrefs.GetInt("eLv");
        level_Text.text = "Level " + level;
        shop_Level.text = "Level " + level;
    }

    //Luu level cong cu vao PlayerPrefts
    public void SaveLevel()
    {
        PlayerPrefs.SetInt("eLv", level);
        PlayerPrefs.Save();
    }
    
    //Nang cap cong cu
    public void UpgradeEquip()
    {
        if (level < 5)
        {
            if (ResourcesManager.Instance.goldA >= equipment.price)
            {
                ResourcesManager.Instance.goldA -= equipment.price;
                level++;
            }
            else
            {
                notE.SetActive(true);
            }
            SaveLoad.Instance.Save();
        }
        else maxLv.SetActive(true);
    }

    //Lay ra gia tri performance de tinh toan nang suat
    public float Performance()
    {

        return (PlayerPrefs.GetInt("eLv") - 1) * performance;
    }
}
