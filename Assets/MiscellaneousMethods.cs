/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Grzegorz Jaruszewski
//Date:         2017-12-02
//Description:  Różne funkcjonalności, które są zbyt małe, 
//              by był sens tworzyć dla nich osobne skrypty.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class MiscellaneousMethods : MonoBehaviour {

    // Metody potrzebne do minimalizacji i maksymalizacji okna
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    // Zamyka aplikację
    public void ExitApplication()
    {
            Application.Quit();
    }

    // Minimalizuje / Maksymalizuje aplikację
    public void MinMaxApplication()
    {
        //Minimalizuj
        ShowWindow(GetActiveWindow(), 2);

        //Maksymalizuj
        //ShowWindow(GetActiveWindow(), 3);
    }

    void ToggleMenuButton()
    {
        
    }
}
