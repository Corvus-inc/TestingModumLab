using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    [SerializeField] private InputManager _input;

    private Camera _camera;
    private float _speedCamera;
    private float _boostSpeedMove = 1;
    private float _boostSpeedRotate = 1;
    private void Awake()
    {
        _camera = Camera.main;
        _speedCamera = 3;
    }

    private void Start()
    {
        _input.LeftButton += RotateCamera;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*Time.deltaTime * _speedCamera *_boostSpeedMove);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left*Time.deltaTime * _speedCamera*_boostSpeedMove);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back*Time.deltaTime * _speedCamera*_boostSpeedMove);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right*Time.deltaTime * _speedCamera*_boostSpeedMove);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _boostSpeedMove = 5;
            _boostSpeedRotate = 1;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _boostSpeedMove = 1;
            _boostSpeedRotate = 1;
        }
    }

    private void RotateCamera(Vector3 mousePosition)
    {

        transform.eulerAngles += mousePosition * _speedCamera * _boostSpeedRotate;
    }
}
