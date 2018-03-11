using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PDFController : MonoBehaviour {

    public Text isOpenPDF;

    public void hidePDF()
    {
        isOpenPDF.text = "0";
    }

    public void showPDF()
    {
        isOpenPDF.text = "1";
    }

    public string getIsOpenPDF()
    {
        return isOpenPDF.text;
    }

    public void setIsOpenPDF(string val)
    {
        isOpenPDF.text = val;
    }
}
