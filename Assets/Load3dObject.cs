/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Dawid SKlorz
//Date:         2017-11-18
//Description:  Pobranie ścieżki do obiektu
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       
//Date:         
//Description:  
/////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using System.IO;

public class Load3dObject : MonoBehaviour {

    public Text objectPath;

    public Button Objectfile_1; public Button Objectfile_2; public Button Objectfile_3;
    public Button Objectfile_4; public Button Objectfile_5; public Button Objectfile_6;
    public Button Objectfile_7; public Button Objectfile_8; public Button Objectfile_9;
    public Button Objectfile_10; public Button Objectfile_11; public Button Objectfile_12;
    public Button Objectfile_13; public Button Objectfile_14; public Button Objectfile_15;

    public Text Objectfile_text_1; public Text Objectfile_text_2; public Text Objectfile_text_3;
    public Text Objectfile_text_4; public Text Objectfile_text_5; public Text Objectfile_text_6;
    public Text Objectfile_text_7; public Text Objectfile_text_8; public Text Objectfile_text_9;
    public Text Objectfile_text_10; public Text Objectfile_text_11; public Text Objectfile_text_12;
    public Text Objectfile_text_13; public Text Objectfile_text_14; public Text Objectfile_text_15;

    private Button[] ButtonArray = new Button[15];
    private Text[] TextArray = new Text[15];
    private string[] filesPathArray;

    public void setFilesFromDirectory()
    {
        this.TextArray[0] = Objectfile_text_1; this.TextArray[1] = Objectfile_text_2; this.TextArray[2] = Objectfile_text_3;
        this.TextArray[3] = Objectfile_text_4; this.TextArray[4] = Objectfile_text_5; this.TextArray[5] = Objectfile_text_6;
        this.TextArray[6] = Objectfile_text_7; this.TextArray[7] = Objectfile_text_8; this.TextArray[8] = Objectfile_text_9;
        this.TextArray[9] = Objectfile_text_10; this.TextArray[10] = Objectfile_text_11; this.TextArray[11] = Objectfile_text_12;
        this.TextArray[12] = Objectfile_text_13; this.TextArray[13] = Objectfile_text_14; this.TextArray[14] = Objectfile_text_15;

        this.ButtonArray[0] = Objectfile_1; this.ButtonArray[1] = Objectfile_2; this.ButtonArray[2] = Objectfile_3;
        this.ButtonArray[3] = Objectfile_4; this.ButtonArray[4] = Objectfile_5; this.ButtonArray[5] = Objectfile_6;
        this.ButtonArray[6] = Objectfile_7; this.ButtonArray[7] = Objectfile_8; this.ButtonArray[8] = Objectfile_9;
        this.ButtonArray[9] = Objectfile_10; this.ButtonArray[10] = Objectfile_11; this.ButtonArray[11] = Objectfile_12;
        this.ButtonArray[12] = Objectfile_13; this.ButtonArray[13] = Objectfile_14; this.ButtonArray[14] = Objectfile_15;

        this.filesPathArray = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + "\\YourFiles\\", "*.obj");

        for (int i = 0; i < this.filesPathArray.Length; i++)
        {
            string[] pathArray = this.filesPathArray[i].Split('\\');
            string filenameWithExtension = pathArray[pathArray.Length - 1];
            this.TextArray[i].text = filenameWithExtension;
            this.ButtonArray[i].gameObject.SetActive(true);
        }
    }

    public void load3dObject(int number)
    {
        //ścieżka do pliku .obj
        string path = this.filesPathArray[number];
        if (path.Length > 0)
        {
            objectPath.text = path;
        }
    }

}
