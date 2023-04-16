using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour
{
    //Tu dong Hide sau 1f
    void OnEnable()
    {
        Invoke("Hide", 1f);
    }


    void Hide()
    { 
        this.gameObject.SetActive(false);
    }
}
