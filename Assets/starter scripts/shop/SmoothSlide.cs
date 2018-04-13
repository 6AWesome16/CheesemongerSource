using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothSlide : MonoBehaviour {

    public GameObject orderPanel;
    //outpos currently set to definite pixel. Adjust in the future to adjust to screensize
    public float outPosX;
    public float lerpSpeed;

    private float inPosX;
    private float tempPosX;

    private bool isVisible = false;
    public bool lerpNow = false;

	// Use this for initialization
	void Start () {
        //sets temp to position of object in scene
        tempPosX = orderPanel.transform.position.x;
        inPosX = orderPanel.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            lerpNow = true;
        }
        //if object is within view and Tab is pressed, put it out of view
        if (lerpNow && isVisible)
        {
            tempPosX = Mathf.Lerp(tempPosX, outPosX, Time.deltaTime * lerpSpeed);
            orderPanel.transform.position = new Vector3(tempPosX, orderPanel.transform.position.y, orderPanel.transform.position.z);
        }
        //if object is out of view and Tab is pressed, put it into view
        else if(lerpNow && !isVisible)
        {
            tempPosX = Mathf.Lerp(tempPosX, inPosX, Time.deltaTime * lerpSpeed);
            orderPanel.transform.position = new Vector3(tempPosX, orderPanel.transform.position.y, orderPanel.transform.position.z);
        }
        ManageSlide();
    }

    private void ManageSlide()
    {
        //if its not visible change isVisible
        if(tempPosX <= outPosX + 1)
        {
            isVisible = false;
            lerpNow = false;
        }
        //else if tempPosX is on Screen change isVisible
        else if(tempPosX >= inPosX - 1)
        {
            isVisible = true;
            lerpNow = false;
        }
    }    
    
}
