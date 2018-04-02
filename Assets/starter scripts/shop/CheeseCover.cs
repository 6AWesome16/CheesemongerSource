using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseCover : MonoBehaviour {
    public GameObject shelf;
    public float minScale;
    //maxScale is equal to the y scale of the empty parent object
    public float maxScale;
    public float shrinkSpeed;
    public float growSpeed;
    public bool shrinking;
    public bool growing;
    float height;

	// Use this for initialization
	void Start () {
        height = shelf.transform.localScale.y;
        //holds the state of the cover
        shrinking = true;
        growing = false;
    }

	// Update is called once per frame
	void Update () {
        //opens the cover
        if (shrinking)
        {
            if (shrinking && Input.GetMouseButton(0))
            {
                height -= 1f * Time.deltaTime * shrinkSpeed;
                if (height <= minScale)
                {
                    shrinking = false;
                }
            }
            shelf.transform.localScale = new Vector3(shelf.transform.localScale.x, height, shelf.transform.localScale.z);
        }
        if (Input.GetMouseButtonUp(0) && shrinking == false && height <= minScale)
        {
            growing = true;
        }
        //closes the cover
        if (growing)
        {
            if (Input.GetMouseButton(0))
            {
                height += 1f * Time.deltaTime * growSpeed;
                if (height >= maxScale)
                {

                    growing = false;
                }
            }
            shelf.transform.localScale = new Vector3(shelf.transform.localScale.x, height, shelf.transform.localScale.z);
        }
        if (Input.GetMouseButtonUp(0) && growing == false && height >= maxScale)
        {
            shrinking = true;
        }
    }
}
