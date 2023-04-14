using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceData : MonoBehaviour
{
    public Resource resourceData;

    public Image sprite;
    public string nameText;
    public int life;
    public int cycle;
    public int price;

    public TMP_Text priceText;

    // Start is called before the first frame update
    void Start()
    {
        nameText = resourceData.name;
        sprite.sprite = resourceData.sprite;
        price = resourceData.price;

        if (this.gameObject.CompareTag("Seed"))
        {
            life = resourceData.life;
            cycle = resourceData.cycle;
        }

        if (this.gameObject.CompareTag("ShopProduct"))
        {
            priceText.text = price.ToString();
        }  
    }
}
