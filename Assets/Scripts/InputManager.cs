using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action<Vector3> RightButton; 
    public event  Action<Vector3> RightButtonDown; 
    public event  Action<Vector3> RightButtonUp; 
    public event Action<Vector3> LeftButton; 
    public event  Action<Vector3> LeftButtonDown; 
    public event  Action<Vector3> LeftButtonUp; 
    
    private Vector3 _mousePosition;
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
           _mousePosition = Input.mousePosition;
            // _mousePosition.z = 8.0f;
            // if (!(Camera.main is null)) _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            // var invertMousePosition = new Vector3(-_mousePosition.z, _mousePosition.y, 0);
            //
            // RightButton?.Invoke(invertMousePosition);
            
            var mouseViewpoint = Camera.main.ScreenToViewportPoint(_mousePosition);
            
            var ScreenCenter = new Vector3(Screen.width / 2 - _mousePosition.x, Screen.height / 2 - _mousePosition.y, 0);
            
            RightButton?.Invoke(mouseViewpoint);
        }

        if (Input.GetMouseButtonDown(1))
        {
            _mousePosition = Input.mousePosition;
            // _mousePosition.z = 8.0f;
            // if (!(Camera.main is null)) _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            //
            // var invertMousePosition = new Vector3(-_mousePosition.z, _mousePosition.y, 0);
            //
            // RightButtonDown?.Invoke(invertMousePosition);
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
            // _mousePosition = Input.mousePosition;
            // _mousePosition.z = 8.0f;
            // if (!(Camera.main is null)) _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            // var invertMousePosition = new Vector3(-_mousePosition.z, _mousePosition.y, _mousePosition.x);

            var invertMousePosition = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            
            LeftButton?.Invoke(invertMousePosition);
        }

        if (Input.GetMouseButtonDown(0))
        {
            // _mousePosition = Input.mousePosition;
            // _mousePosition.z = 8.0f;
            // if (!(Camera.main is null)) _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            // var invertMousePosition = new Vector3(-_mousePosition.z, _mousePosition.y, _mousePosition.x);

            var invertMousePosition = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            
            LeftButtonDown?.Invoke(invertMousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            // LeftButtonUp?.Invoke(Vector3.zero);
        }
    }
    
}