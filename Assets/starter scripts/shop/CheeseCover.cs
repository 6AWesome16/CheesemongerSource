using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseCover : MonoBehaviour {
    public GameObject shelf;
    public float minScale;
    //maxScale is equal to the y scale of the empty parent object
    public float maxScale;
    //public float shrinkSpeed;
    //public float growSpeed;
    public bool shrinking;
    public bool growing;
    private float width;
    public float lerpSpeed;

    // Use this for initialization
    void Start () {
        width = shelf.transform.localScale.x;
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
                //old calculation
                //width -=  Time.deltaTime * shrinkSpeed;
                //new calculation with Lerp!
                width = Mathf.Lerp(width, minScale, Time.deltaTime * lerpSpeed);
                if (width <= minScale)
                {
                    shrinking = false;
                }
            }
            shelf.transform.localScale = new Vector3(width, shelf.transform.localScale.y, shelf.transform.localScale.z);
        }
        if (Input.GetMouseButtonUp(0) && shrinking == false && width <= minScale)
        {
            growing = true;
        }
        //closes the cover
        if (growing)
        {
            if (Input.GetMouseButton(0))
            {
                //old calculation
                //width +=  Time.deltaTime * growSpeed;
                //new calculation with Lerp!
                width = Mathf.Lerp(width, maxScale, Time.deltaTime * lerpSpeed);
                if (width >= maxScale)
                {

                    growing = false;
                }
            }
            shelf.transform.localScale = new Vector3(width, shelf.transform.localScale.y, shelf.transform.localScale.z);
        }
        if (Input.GetMouseButtonUp(0) && growing == false && width >= maxScale)
        {
            shrinking = true;
        }
    }
}
