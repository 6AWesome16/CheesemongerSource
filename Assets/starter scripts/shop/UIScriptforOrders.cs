using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScriptforOrders : MonoBehaviour {
    public Text orderText;
	// Use this for initialization
	void Start () {
        orderText.text = "No new orders";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            orderText.text = "1 order of Mozzarella";
        }
	}
}
