/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Dominika Brzozowska
//Date:         2017-12-03
//Description:  Czyszcenie obiektów
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       
//Date:         
//Description:  
/////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class ClearObject : ChangeScene {

    private bool check_status;
    static private bool change_cursor;


    void OnMouseDrag()
    {
        if (check_status == true)
        Destroy(gameObject);
    }

   public void clear_object()
    {
        check_status = true;
    }

    public void stop_clearing()
    {
        check_status = false;
    }

   public void changeKinect()
    {
        change_cursor = true;

    }

    public void changeMouse()
    {
        change_cursor = false;
    }

    public void Reload ()
    {
        if (change_cursor == true)
        {           
            ChangeToScene("lineReloadK");
        }

        else
            ChangeToScene("lineReloadM");
    }

}
