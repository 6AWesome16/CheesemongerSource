using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverFiller : MonoBehaviour {

    public GameObject shelf;

    public float maxValue;
    public float minValue;
    public float lerpSpeed;

    private float width;

    private bool isOpen = false;
    private bool onStart;

    //    private float fillAmount = 0f;

    //public Image content;//thats what it's usually called

    void Start() {
        width = shelf.transform.localScale.x;
        onStart = true;
    }

    void Update() {
        ManageCover();
    }

    private void ManageCover()
    {
        //if open and clicked, close
        if (isOpen || onStart)
        {
            width = Mathf.Lerp(width, maxValue, Time.deltaTime * lerpSpeed);
            shelf.transform.localScale = new Vector3(width, shelf.transform.localScale.y, shelf.transform.localScale.z);
            //works with fill material but doesn't allow detection beneath the image
            //content.fillAmount = Mathf.Lerp(content.fillAmount, 1f, Time.deltaTime * lerpSpeed);
        }
        //if closed, open
        else if (!isOpen)
        {
            //works with fill material but doesn't allow detection beneath the image
            //content.fillAmount = Mathf.Lerp(content.fillAmount, 0.1f, Time.deltaTime * lerpSpeed);
            //integrate with cheesecover code attempt, will scale the image with lerp
            width = Mathf.Lerp(width, minValue, Time.deltaTime * lerpSpeed);
            shelf.transform.localScale = new Vector3(width, shelf.transform.localScale.y, shelf.transform.localScale.z);

        }
    }

    public void SwitchBool()
    {
        if (onStart && !isOpen)
        {
            isOpen = false;
            onStart = false;
        }
        else if (!isOpen)
        {
            isOpen = true;
        }
        else if(isOpen)
        {
            isOpen = false;
        }
    }
}
