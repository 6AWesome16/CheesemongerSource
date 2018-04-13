using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptforOrders : MonoBehaviour {
    public Text orderText;
    public float changeInterval;

    private int i = 0;
    private float timmy = 0;
	// Use this for initialization
	void Start () {
        orderText.text = "No new orders";
	}
	
	// Update is called once per frame
	void Update () {
        timmy += Time.deltaTime;
        Debug.Log(timmy);
        if (timmy >= changeInterval)
        {
            ChangeText();
        }
	}
    void ChangeText()
    {
        changeInterval = Random.Range(5f,8f);
        if(i == 0)
        {
            orderText.text = "1 order of Mozzarella";
            i++;
        }
        else if(i == 1)
        {
            orderText.text += "\n" + "1 order of Parmiggiano Reggiano";
            i++;
        }
        else if(i == 2)
        {
            orderText.text += "\n" + "1 order of Swiss";
            i++;
        }
        timmy = 0;
    }
}
