using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class PourController : MonoBehaviour, IObserver<ValveStatus>
{
    private Transform _fluid;
    private Material _fluidMaterial;

    private float _rangeFluid;
    private float _pourSpeed;
    private readonly Dictionary<float, float> _valvesPercents = new Dictionary<float, float>();

    private float _greenCount;
    private float _blueCount;
    
    public Transform Fluid
    {
        set => _fluid = value;
    }

    public Material FluidMaterial
    {
        set => _fluidMaterial = value;
    }
    private void Start()
    {
        _pourSpeed = 100000;
        _fluid.localScale = new Vector3(1, 0, 1);
    }
    
    private void Update()
    {
        if(_fluid.localScale.y >= 0.9f)
            return;
        
        _rangeFluid  = _valvesPercents.Sum(percent => percent.Value);
        _greenCount += _valvesPercents[0];
        _blueCount += _valvesPercents[1];
        _fluid.localScale += new Vector3(0, _rangeFluid*Time.deltaTime/_pourSpeed, 0);
        
        _fluidMaterial.color = Color.Lerp(Color.blue, Color.green,  _greenCount/((_greenCount+_blueCount)/100)/100);
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(ValveStatus value)
    {
        var currentRange = value.CurrentRangeRotate;
        const float inaccuracy = 0.2f;

        if (!_valvesPercents.ContainsKey(value.Id))
        {
            _valvesPercents.Add(value.Id, currentRange);
        }
        else
        {
            if (value.CurrentRangeRotate < inaccuracy)
            {
                currentRange = 0;
            }
            _valvesPercents[value.Id] = currentRange;
        }
    }
}
