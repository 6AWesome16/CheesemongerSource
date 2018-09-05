using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScriptforOrders : MonoBehaviour {
    public Text orderText;
    public Text moneyText;
    public string[] cheeses = new string[] {"Mozzarella", "Cheddar", "Brie", "Asiago", "Feta", "Bleu", "Gorgonzola" };
	// Use this for initialization
	void Start () {
        orderText.text = "No new orders";
        moneyText.text = "$0";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            orderText.text = "1 order of " + cheeses.RandomItem();
            Data.instance.orderNum += 1;
        }
        if (Input.GetKey(KeyCode.T))
        {
            tip();
        }
        moneyText.text = "$" + Data.instance.money.ToString();
    }

    void tip()
    {
        float tip = Random.Range(1, 20);
        Data.instance.money += tip;
    }
}

public class Data
{
    private Data()
    {

    }

    static private Data _instance;
    static public Data instance
    {
        get
        {
            if (_instance == null)
                _instance = new Data();
            return _instance;
        }
    }
    public uint orderNum;
    public float money;
}

public static class ArrayExtensions
{
    // This is an extension method. RandomItem() will now exist on all arrays.
    public static T RandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
