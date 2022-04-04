using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveHandler : MonoBehaviour
{
   [SerializeField] private WaterFlowController waterFlowController;
   [SerializeField] private PourController pourController;
   [SerializeField] private List<Valve> valves;
   [SerializeField] private InputManager _input;

   private void Awake()
   {
       _input.RightButtonDown += OnValve;
   }

   private void Start()
   {
       foreach (var valve in valves)
       {
           valve.Subscribe(waterFlowController);
           valve.Subscribe(pourController);
       }
   }

   private void OnValve(Vector3 mouseViewpoint)
    {
        var mostValve = valves[0];
        foreach (var valve in valves)
        {
            if ((mouseViewpoint - valve.ValveViewpoint ).magnitude < (mouseViewpoint - mostValve.ValveViewpoint).magnitude)
                mostValve = valve;
        }
        
        _input.RightButton += mostValve.EulerRotation;
    }
}
