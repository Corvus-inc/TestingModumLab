using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Valve : MonoBehaviour, IObservable<ValveStatus>
{
    private readonly List<IObserver<ValveStatus>> observers = new List<IObserver<ValveStatus>>();
    
    [SerializeField] private Transform transformValve;

    public int _id;
    
    [Range(MINRangeRotate, MAXRangeRotate)] private float _currentRangeRotate;
    private Quaternion _rotationValve;
    private Vector3 _lastPoint;
    private Vector3 _viewPoint;
    private const float MINRangeRotate = 0; 
    private const float MAXRangeRotate = 720;

    public Vector3 LastPoint { set => _lastPoint = value; }

    public ValveStatus valveStatus => new ValveStatus() {Id = _id, CurrentRangeRotate = _currentRangeRotate};

    public Vector3 ValveViewpoint
    {
        get
        {
            var point =Camera.main.WorldToViewportPoint(transformValve.position);
            _viewPoint = new Vector3(point.x, point.y, 0);
            return _viewPoint;
        }
    }
    private float CurrentRangeRotate => _currentRangeRotate;
    
    void Start()
    {
        _rotationValve = transformValve.rotation;
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
        var rotates = _currentRangeRotate + angle;
        if (rotates< MINRangeRotate) angle = 0;
        else if (rotates > MAXRangeRotate) angle = 0;
        
        _currentRangeRotate += angle;
        
        foreach (var observer in observers)
            observer.OnNext(valveStatus);
        
        var vector = new Vector3(transformValve.rotation.eulerAngles.x, _currentRangeRotate, transformValve.rotation.eulerAngles.z);
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
