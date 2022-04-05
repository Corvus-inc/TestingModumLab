using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InputManager : MonoBehaviour, IInputManager
{
    public event Action<Vector3> RightButton; 
    public event  Action<Vector3> RightButtonDown; 
    public event  Action<Vector3> RightButtonUp; 
    public event Action<Vector3> LeftButton;

    public event Action ToForward;
    public event Action ToLeft;
    public event Action ToBack;
    public event Action ToRight;
    public event Action BoostSpeedOn;
    public event Action BoostSpeedOff;
    
    
    private Vector3 _mousePosition;
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
           _mousePosition = Input.mousePosition;
            var mouseViewpoint = Camera.main.ScreenToViewportPoint(_mousePosition);
            
            var ScreenCenter = new Vector3(Screen.width / 2 - _mousePosition.x, Screen.height / 2 - _mousePosition.y, 0);
            
            RightButton?.Invoke(mouseViewpoint);
        }

        if (Input.GetMouseButtonDown(1))
        {
            _mousePosition = Input.mousePosition;
            var mouseViewpoint = Camera.main.ScreenToViewportPoint(_mousePosition);
            
            var ScreenCenter = new Vector3(Screen.width / 2 - _mousePosition.x, Screen.height / 2 - _mousePosition.y, 0);
            
            RightButtonDown?.Invoke(mouseViewpoint);
        }
        if (Input.GetMouseButtonUp(1))
        {
            RightButtonUp?.Invoke(Vector3.zero);
        }
        
        if (Input.GetMouseButton(0))
        {
            var invertMousePosition = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            
            LeftButton?.Invoke(invertMousePosition);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            ToForward?.Invoke();
        }
        if (Input.GetKey(KeyCode.A))
        {
            ToLeft.Invoke();
        }
        if (Input.GetKey(KeyCode.S))
        {
            ToBack.Invoke();
        }
        if (Input.GetKey(KeyCode.D))
        {
            ToRight.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            BoostSpeedOn.Invoke();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            BoostSpeedOff.Invoke();
        }
    }
    
}