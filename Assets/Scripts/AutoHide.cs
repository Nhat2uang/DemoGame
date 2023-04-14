using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Hide", 1f);
    }


    void Hide()
    { 
        this.gameObject.SetActive(false);
    }
}
