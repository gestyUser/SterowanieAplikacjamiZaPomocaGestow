using UnityEngine;

public delegate void MouseMoved(float xMovement, float yMovement);
public class InputManagerMouse : MonoBehaviour
{
    #region Private References
    private float _xMovement;
    private float _yMovement;
    public int kinect = 0;
    #endregion

    #region Events
    public static event MouseMoved MouseMoved;
    #endregion

    #region Event Invoker Methods
    private static void OnMouseMoved(float xmovement, float ymovement)
    {
        var handler = MouseMoved;
        if (handler != null) handler(xmovement, ymovement);
    }
    #endregion


    #region Private Methods
    private void InvokeActionOnInput(float x, float y)
    {
            print("DUPA MOJA");
            _xMovement = Input.GetAxis("Mouse X");
            _yMovement = Input.GetAxis("Mouse Y");
        print(_xMovement);
        print(_yMovement);

        OnMouseMoved(_xMovement, _yMovement);
    }
    #endregion

    #region Unity CallBacks

    public void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            print("DUPA STASIA");
            InvokeActionOnInput(0, 0);
        }
    }
    #endregion
}