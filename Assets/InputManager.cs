using UnityEngine;

public delegate void MouseMoved2(float xMovement, float yMovement);
public class InputManager : AbstractKinectUICursor
{
    #region Private References
    private float _xMovement;
    private float _yMovement;
    public int kinect = 0;
    public static float xold;
    public static float yold;
    public static float xyoldFlag = 0;
    #endregion

    #region Events
    public static event MouseMoved2 MouseMoved2;
    #endregion

    #region Event Invoker Methods
    private static void OnMouseMoved(float xmovement, float ymovement)
    {
        var handler = MouseMoved2;
        if (handler != null) handler(xmovement, ymovement);
    }
    #endregion


    #region Private Methods
    private void InvokeActionOnInput(float x, float y)
    {
            if (kinect == 0)
            {
                _xMovement = Input.GetAxis("Mouse X");
                _yMovement = Input.GetAxis("Mouse Y");
            }
            else
            {
            if (xyoldFlag == 0)
            {
                xold = x;
                yold = y;
                xyoldFlag = 1;
            } else {
                _xMovement = x - xold;
                _yMovement = y - yold;
                xold = x;
                yold = y;
                OnMouseMoved(_xMovement*40, _yMovement*40);
            }

            }
    }
    #endregion

    #region Unity CallBacks

    public override void ProcessData()
    {
        transform.position = _data.GetHandScreenPosition();
        if (_data.IsPressing)
        {
            InvokeActionOnInput(transform.position.x, transform.position.y);
            kinect = 1;
        } else
        {
            xyoldFlag = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            InvokeActionOnInput(0, 0);
        }
    }
    #endregion
}