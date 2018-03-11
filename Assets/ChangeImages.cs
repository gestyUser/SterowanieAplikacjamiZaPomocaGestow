/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Dawid Sklorz
//Date:         2017-11-18
//Description:  Zmiana stron dokumentu pdf
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Dominika Brzozowska       
//Date:         2017-12-25         
//Description:  Dodanie przybliżania/oddalania prezentacji 
/////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class ChangeImages : MonoBehaviour
{
    public Text filesPath;
    public Text currentImg;
    public Text actionFlag;
    private RawImage image;
    private Texture2D img;
    private string[] filesPathArray;
    public Button NextButton;
    public Button PrevButton;
    public Button FirstButton;
    public Button LastButton;
    public Button HidePDF;
    public Button zoomInB;
    public Button zoomOutB;
    public Button ClosePDF;

    private float zoom_x = 0f;
    private float zoom_y = 0f;
    private bool first = true;

    private void Start()
    {
        this.actionFlag.text = "true";
    }

    public void setactionFlag(string val)
    {
        this.actionFlag.text = val;
    }

    //Wstawienie obrazu jpg jako teksture do objektu
    private void getImage(int number)
    {
        WWW imgLink = new WWW(this.filesPathArray[number]);
        this.img = imgLink.texture;
        this.image = gameObject.GetComponent<RawImage>();
        if(first==true)
        // GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        {
            zoom_x = gameObject.GetComponent<RectTransform>().sizeDelta.x;
            zoom_y = gameObject.GetComponent<RectTransform>().sizeDelta.y;
        }
        this.image.texture = this.img;
    }

    //Pobranie obecnego zdjecia(strony pdf)
    private int getCurrentImage(String currentImageText)
    {
        return Int32.Parse(currentImageText);
    }

    private void Update()
    {
        if (this.filesPath.text.Length > 0 && this.actionFlag.text == "true")
        {
            this.filesPathArray = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + "\\FilesImg\\", "*.jpg", SearchOption.AllDirectories);
            this.actionFlag.text = "false";
            int currentImg = this.getCurrentImage(this.currentImg.text);

            this.getImage(currentImg - 1);

            //Pokazanie obiektów
            NextButton.gameObject.SetActive(true);
            PrevButton.gameObject.SetActive(true);
            FirstButton.gameObject.SetActive(true);
            LastButton.gameObject.SetActive(true);
            HidePDF.gameObject.SetActive(true);
            zoomInB.gameObject.SetActive(true);
            zoomOutB.gameObject.SetActive(true);
            ClosePDF.gameObject.SetActive(true);
        }
    }

    //Zmiana na następny obraz
    public void nextImage()
    {
        if (this.filesPath.text.Length > 0)
        {
            int currentImg = this.getCurrentImage(this.currentImg.text);
            currentImg++;
            //Sprawdzenie zapobiegające wyświetleniu obrazu spoza zakresu dokumentu
            if (currentImg <= this.filesPathArray.Length)
            {
                this.currentImg.text = (currentImg).ToString();

                this.getImage(currentImg - 1);
            }
        }
    }

    //Zmiana na poprzedni obraz
    public void previousImage()
    {
        if (this.filesPath.text.Length > 0)
        {
            int currentImg = this.getCurrentImage(this.currentImg.text);
            currentImg--;
            //Sprawdzenie zapobiegające wyświetleniu obrazu spoza zakresu dokumentu
            if (currentImg > 0)
            {
                this.currentImg.text = (currentImg).ToString();

                this.getImage(currentImg - 1);
            }
        }
    }

    //Wyświetlenie ostatniego dokumentu
    public void lastImage()
    {
        this.currentImg.text = (this.filesPathArray.Length).ToString();

        this.getImage(this.filesPathArray.Length - 1);
    }

    //Wyświetlenie pierwszego dokumentu
    public void firstImage()
    {
        this.currentImg.text = "1";

        this.getImage(0);
    }

    public void zoomIn()
    {
        zoom_x = zoom_x + 40;
        zoom_y = zoom_y + 40;
        first = false;
        GetComponent<RectTransform>().sizeDelta = new Vector2(zoom_x, zoom_y);

    }

    public void zoomOut()
    {

        zoom_x = zoom_x - 40;
        zoom_y = zoom_y - 40;
        first = false;
        GetComponent<RectTransform>().sizeDelta = new Vector2(zoom_x, zoom_y);

    }
}
