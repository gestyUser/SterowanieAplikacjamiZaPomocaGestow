/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Dominika Brzozowska
//Date:         2017-11-25
//Description:  Przemieszczanie, powiększanie obiektu
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:
//Date:
//Description:
/////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformShape : MonoBehaviour {

    float distance = 10;

    public GameObject cube;
    
    void Start()
    {
       
    }
    void OnMouseEnter()
    {
    
       
    }
    void OnMouseOver()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButton(0))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            cube.transform.position = objPosition;
        }else

        if ((Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Began) || Input.GetMouseButton(1))
        {
            /*cube = (GameObject)Instantiate(cube, transform.position, Quaternion.identity);
            cube.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);*/
            cube.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
    void OnMouseExit()
    {
        
    }


  /*  void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }*/

}
