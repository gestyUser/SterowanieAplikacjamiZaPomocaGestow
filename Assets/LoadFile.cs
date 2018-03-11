/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Dawid Sklorz
//Date:         2017-11-18
//Description:  Załadowanie pdf do Unity, konwersja do jpg(ghostscript)
/////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using System.IO;

public class LoadFile : MonoBehaviour {

    public Text filesPath;
    private string pathDir;
    private string filename;
    private string filenameWithExtension;
    private string mainPath;
    public Text currentImg;
    public Text actionFlag;

    public Button PDFfile_1;public Button PDFfile_2;public Button PDFfile_3;
    public Button PDFfile_4;public Button PDFfile_5;public Button PDFfile_6;
    public Button PDFfile_7;public Button PDFfile_8;public Button PDFfile_9;
    public Button PDFfile_10;public Button PDFfile_11;public Button PDFfile_12;
    public Button PDFfile_13;public Button PDFfile_14;public Button PDFfile_15;

    public Text PDFfile_text_1;public Text PDFfile_text_2;public Text PDFfile_text_3;
    public Text PDFfile_text_4;public Text PDFfile_text_5;public Text PDFfile_text_6;
    public Text PDFfile_text_7;public Text PDFfile_text_8;public Text PDFfile_text_9;
    public Text PDFfile_text_10;public Text PDFfile_text_11;public Text PDFfile_text_12;
    public Text PDFfile_text_13;public Text PDFfile_text_14;public Text PDFfile_text_15;

    private Button[] ButtonArray = new Button[15];
    private Text[] TextArray = new Text[15];
    private string[] filesPathArray;


    //przypisanie plików PDF objektom Unity
    public void setFilesFromDirectory()
    {
        this.TextArray[0] = PDFfile_text_1;this.TextArray[1] = PDFfile_text_2;this.TextArray[2] = PDFfile_text_3;
        this.TextArray[3] = PDFfile_text_4;this.TextArray[4] = PDFfile_text_5;this.TextArray[5] = PDFfile_text_6;
        this.TextArray[6] = PDFfile_text_7;this.TextArray[7] = PDFfile_text_8;this.TextArray[8] = PDFfile_text_9;
        this.TextArray[9] = PDFfile_text_10;this.TextArray[10] = PDFfile_text_11;this.TextArray[11] = PDFfile_text_12;
        this.TextArray[12] = PDFfile_text_13;this.TextArray[13] = PDFfile_text_14;this.TextArray[14] = PDFfile_text_15;

        this.ButtonArray[0] = PDFfile_1;this.ButtonArray[1] = PDFfile_2;this.ButtonArray[2] = PDFfile_3;
        this.ButtonArray[3] = PDFfile_4;this.ButtonArray[4] = PDFfile_5;this.ButtonArray[5] = PDFfile_6;
        this.ButtonArray[6] = PDFfile_7;this.ButtonArray[7] = PDFfile_8;this.ButtonArray[8] = PDFfile_9;
        this.ButtonArray[9] = PDFfile_10;this.ButtonArray[10] = PDFfile_11;this.ButtonArray[11] = PDFfile_12;
        this.ButtonArray[12] = PDFfile_13;this.ButtonArray[13] = PDFfile_14;this.ButtonArray[14] = PDFfile_15;

        this.filesPathArray = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + "\\YourFiles\\", "*.pdf");

        for (int i = 0; i < this.filesPathArray.Length; i++)
        {
            string[] pathArray = this.filesPathArray[i].Split('\\');
            string filenameWithExtension = pathArray[pathArray.Length - 1];
            this.TextArray[i].text = filenameWithExtension;
            this.ButtonArray[i].gameObject.SetActive(true);
        }
    }

    //Usuwanie starych jpg z folderu outputImagesPath
    private void deleteOldFiles(String outputImagesPath)
    {
        if (System.IO.Directory.Exists(outputImagesPath) == false)
        {
            System.IO.DirectoryInfo dir = System.IO.Directory.CreateDirectory(outputImagesPath);
        }
        System.IO.DirectoryInfo directory = new DirectoryInfo(outputImagesPath);

        foreach (FileInfo file in directory.GetFiles())
        {
            file.Delete();
        }
    }

    //Kotwertowanie pdf -> jpg
    private void ConvertPDFToJPG(String inputPDFFile, String outputImagesPath)
    {
        this.deleteOldFiles(outputImagesPath);

        string ghostScriptPath = System.IO.Directory.GetCurrentDirectory()+"\\Assets\\Ghostscript\\bin\\gswin64.exe";

        String ars = "-dNOPAUSE -sDEVICE=jpeg -r300 -o" + outputImagesPath + "%d.jpg -sPAPERSIZE=a4 " + "\"" + inputPDFFile + "\"";
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo.FileName = ghostScriptPath;
        proc.StartInfo.Arguments = ars;
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        proc.Start();
        proc.WaitForExit();
    }

    public void loadFile(int number)
    {
        //ścieżka do pliku .pdf
        string path = this.filesPathArray[number];
        string[] pathArray = path.Split('\\');
        this.filenameWithExtension = pathArray[pathArray.Length - 1];
        this.filename = System.IO.Path.GetFileNameWithoutExtension(this.filenameWithExtension);
        this.mainPath = path.Replace(this.filenameWithExtension, "");

        if (path.Length > 0)
        {
            this.pathDir = System.IO.Directory.GetCurrentDirectory() + "\\FilesImg\\";

            this.filesPath.text = this.pathDir;
            this.currentImg.text = "1";
            this.actionFlag.text = "true";

            //Konwertowanie pdf do jpg do folderu
            this.ConvertPDFToJPG(path, this.pathDir);
        }
    }

    private void Start()
    {
        //Sprawdzenie czy katalog istnieje i w razie koniecznosci jego stowrzenie
        filesPath.text = System.IO.Directory.GetCurrentDirectory() + "\\FilesImg\\";
        if (System.IO.Directory.Exists(filesPath.text) == false)
        {
            System.IO.DirectoryInfo dir = System.IO.Directory.CreateDirectory(filesPath.text);
        }
        if (System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\YourFiles\\") == false)
        {
            System.IO.DirectoryInfo dir = System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\YourFiles\\");
        }
    }
}
