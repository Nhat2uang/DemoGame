using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private static SaveLoad instance;
    public static SaveLoad Instance { get => instance; }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        ResourcesManager.Instance.SaveAmount();
        EquipmentManager.Instance.SaveLevel();
        PlayerPrefs.Save();
    }

    public void Load()
    {
        ResourcesManager.Instance.LoadAmount();
        EquipmentManager.Instance.CheckLevel();
        LandsManager.Instance.CheckLands();
    }
}
