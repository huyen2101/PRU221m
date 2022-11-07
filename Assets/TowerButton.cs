using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : Singleton<TowerButton>
{

    [SerializeField]
    private int price;

    public int Price
    {
        get
        {
            return price;
        }
    }

    [SerializeField]
    private Text priceText;

    private void Start()
    {
        priceText.text = Price.ToString();
    }
}
