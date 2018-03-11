/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Dominika Brzozowska
//Date:         2017-10-22
//Description:  Obracanie obiektu
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Grzegorz Jaruszewski
//Date:         2017-11-20
//Description:  Zmiana sposobu działania kamery
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Dominika Brzozowska
//Date:         2017-11-23
//Description:  Foward/back - mouse scroll, delete target
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Grzegorz Jaruszewski
//Date:         2017-12-02
//Description:  Zwiększenie wartości progu aktywacji ruchu 
//              w danym kierunku przy poruszaniu obiektem.
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Grzegorz Jaruszewski
//Date:         2017-12-19
//Description:  Zakomentowanie linii odpowiedzialnych za obracanie.
//              
/////////////////////////////////////////////////

using UnityEngine;


public class RotateTarget : MonoBehaviour
{

    //Speed
    private float speed = 10f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private Transform target;


    void Start() { }

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetAxis("Mouse X") > 0.5f)
                transform.RotateAround(Vector3.zero, Vector3.up, 100 * Time.deltaTime);

            if (Input.GetAxis("Mouse X") < -0.5f)
                transform.RotateAround(Vector3.zero, Vector3.down, 100 * Time.deltaTime);

            if (Input.GetAxis("Mouse Y") > 0.5f)
                transform.RotateAround(Vector3.zero, Vector3.right, 100 * Time.deltaTime);

            if (Input.GetAxis("Mouse Y") < -0.5f)
                transform.RotateAround(Vector3.zero, Vector3.left, 100 * Time.deltaTime);
        }
        */

        //Forward - scroll
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            moveCameraForward(5);

        //Back - scroll
        if ((Input.GetAxis("Mouse ScrollWheel") < 0f))
            moveCameraBack(5);

        //Sprawdzenie czy środkowy przycisk myszy jest wciśniety
        /*
        if (((Input.touchCount > 0 && Input.GetTouch(2).phase == TouchPhase.Began) || Input.GetMouseButton(2)))
            rotateCamera();
        */
    }

    void rotateCamera()
    {
        /*
        if (Input.GetAxis("Mouse X") > 0f) //kierunek : prawo
            transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * speed);
        if (Input.GetAxis("Mouse X") < 0f) //kierunek : lewo
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * speed);
        if (Input.GetAxis("Mouse Y") > 0f) //kierunek : góra
            transform.RotateAround(target.transform.position, Vector3.right, Time.deltaTime * speed);
        if (Input.GetAxis("Mouse Y") < 0f) //kierunek : dół
            transform.RotateAround(target.transform.position, Vector3.left, Time.deltaTime * speed);
        */

            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    public void moveCameraForward(int divider)
    {
        transform.Translate(Vector3.forward / divider);
    }

    public void moveCameraBack(int divider)
    {
        transform.Translate(Vector3.back / divider);
    }

    /*
    //poruszanie kamera po osiach XY
    void moveCameraXY()
    {
        if (Input.GetAxis("Mouse Y") > 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);
        }

        else if (Input.GetAxis("Mouse Y") < 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0.0f);
        }
    }

    //poruszanie kamera po osiach XZ
    void moveCameraXZ()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }

        else if (Input.GetAxis("Mouse X") < 0)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }
    }
    */
    //procedura sprawdzająca, która opcja obrotu ma zostać wykonana
}