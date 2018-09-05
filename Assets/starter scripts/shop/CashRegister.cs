using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRegister : MonoBehaviour {

    // Use this for initialization
    public AudioClip dingClip;

    public AudioSource dingSource;
	void Start () {
        dingSource.clip = dingClip;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            dingSource.PlayOneShot(dingClip);
        }
    }

}
