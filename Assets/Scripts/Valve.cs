using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Valve : MonoBehaviour, IObservable<ValveStatus>
{
    private List<IObserver<ValveStatus>> observers = new List<IObserver<ValveStatus>>();
    
    [SerializeField] private InputManager _input;
    [Range(MINRangeRotate, MAXRangeRotate)] [SerializeField] private float currentRangeRotate;
    [SerializeField] private Transform transformValve;

    public int _id;
    private Quaternion _rotationValve;
    private Vector3 _lastPoint;
    private Vector3 _viewPoint;
    private const float MINRangeRotate = 0; 
    private const float MAXRangeRotate = 720;

    public ValveStatus valveStatus => new ValveStatus() {Id = _id, CurrentRangeRotate = currentRangeRotate};

    public Vector3 ValveViewpoint
    {
        get
        {
            var point =Camera.main.WorldToViewportPoint(transformValve.position);
            _viewPoint = new Vector3(point.x, point.y, 0);
            return _viewPoint;
        }
    }
    private float CurrentRangeRotate => currentRangeRotate;
    
    void Start()
    {
        _rotationValve = transformValve.rotation;
        
        //TODO Move to ValveHandler
        _input.RightButtonUp += vector3 =>
        {
            _lastPoint = vector3;
            _input.RightButton -= EulerRotation;
        };
        
        _lastPoint = _rotationValve.eulerAngles;
    }
    
    public void EulerRotation(Vector3 currentPoint)
    {
        var point =Camera.main.WorldToViewportPoint(transformValve.position);
        _viewPoint = new Vector3(point.x, point.y, 0);
        currentPoint -= _viewPoint;
        
        var angle = Vector3.Angle(_lastPoint, currentPoint);
        //Find direction
        angle = Mathf.Sign(Vector3.Cross(_lastPoint, currentPoint).z) * -angle;
        //Block for rotation
        var rotates = currentRangeRotate + angle;
        if (rotates< MINRangeRotate) angle = 0;
        else if (rotates > MAXRangeRotate) angle = 0;
        
        currentRangeRotate += angle;
        
        foreach (var observer in observers)
            observer.OnNext(valveStatus);
        
        var vector = new Vector3(transformValve.rotation.eulerAngles.x, currentRangeRotate, transformValve.rotation.eulerAngles.z);
        transformValve.rotation = Quaternion.Euler(vector);

        _lastPoint = currentPoint;
    }

    public IDisposable Subscribe(IObserver<ValveStatus> observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
            observer.OnNext(valveStatus);
        }
        return new Unsubscriber<ValveStatus>(observers, observer);
    }
}
internal class Unsubscriber<T> : IDisposable
{
    private List<IObserver<T>> _observers;
    private IObserver<T> _observer;

    internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
    {
        this._observers = observers;
        this._observer = observer;
    }

    public void Dispose()
    {
        if (_observers.Contains(_observer))
            _observers.Remove(_observer);
    }
}
