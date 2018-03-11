///////////////////////////////////////////////
//Author: Dawid Sklorz

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class ReceiveActionController : MonoBehaviour
{
    public ChangeImages changeImages = new ChangeImages();
    public PDFController pDFController = new PDFController();
    public RotateTarget rotateTarget = new RotateTarget();

    void Update()
    {
        if (Input.GetKey(KeyCode.PageUp))
        {
            print("pDFController.getIsOpenPDF() = " + pDFController.getIsOpenPDF());
            if(pDFController.getIsOpenPDF() == "1")
            {
                changeImages.zoomIn();
            }
            else
            {
                rotateTarget.moveCameraForward(1);
            }
        }
        else if (Input.GetKey(KeyCode.PageDown))
        {
            if (pDFController.getIsOpenPDF() == "1")
            {
                changeImages.zoomOut();
            }
            else
            {
                rotateTarget.moveCameraBack(1);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            changeImages.previousImage();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            changeImages.nextImage();
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            //click movethis - reverse
        }
    }
    
}
