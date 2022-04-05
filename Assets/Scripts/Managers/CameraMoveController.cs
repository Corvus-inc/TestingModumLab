using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{ 
    private IInputManager _input;

    private float _speedCamera;
    private float _boostSpeedMove = 1;
    private float _boostSpeedRotate = 1;

    public IInputManager inputManager
    {
        set => _input = value;
    }

    private void Start()
    {
        _speedCamera = 3;
        _input.LeftButton += RotateCamera;
        _input.ToForward += () => transform.Translate(Vector3.forward * Time.deltaTime * _speedCamera * _boostSpeedMove);
        _input.ToLeft += () => transform.Translate(Vector3.left * Time.deltaTime * _speedCamera * _boostSpeedMove);
        _input.ToBack += () => transform.Translate(Vector3.back * Time.deltaTime * _speedCamera * _boostSpeedMove);
        _input.ToRight += () => transform.Translate(Vector3.right * Time.deltaTime * _speedCamera * _boostSpeedMove);
        _input.BoostSpeedOn += () =>
        {
            _boostSpeedMove = 5;
            _boostSpeedRotate = 1;
        };
        _input.BoostSpeedOff += () =>
        {
            _boostSpeedMove = 1;
            _boostSpeedRotate = 1;
        };
    }
    
    private void RotateCamera(Vector3 mousePosition)
    {
        transform.eulerAngles += mousePosition * _speedCamera * _boostSpeedRotate;
    }
}
