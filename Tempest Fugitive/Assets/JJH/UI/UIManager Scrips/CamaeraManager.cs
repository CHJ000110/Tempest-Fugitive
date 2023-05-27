using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaeraManager : MonoBehaviour
{
    public Camera backCam;
    public bool isbackCam = false;
    public bool isClicked = false;
    public float clicktimeMax = 0.5f;
    public float curClickTime = 0.0f;

    void Update()
    {
        if (Input.GetKey("space") && !isClicked)
        {
            isClicked = true;
            BackCamControl();
        }

        if (isClicked)
            ClickedTime();
    }

    void BackCamControl()
    {
        isbackCam = !isbackCam;

        if (isbackCam)
            backCam.rect = new Rect(0, 0, 1, 1);
        else
            backCam.rect = new Rect(0.05f, 0.85f, 0.1f, 0.1f);
    }

    void ClickedTime()
    {
        curClickTime += Time.deltaTime;

        if(curClickTime >= clicktimeMax)
        {
            isClicked = false;
            curClickTime = 0.0f;
        }
    }
}
