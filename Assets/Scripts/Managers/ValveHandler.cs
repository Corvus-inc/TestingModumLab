using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ValveHandler : MonoBehaviour
{
   private FlowController _flowController;
   private PourController pourController;
   private List<Valve> valves;
   private IInputManager _input;
   
   private Valve _mostValve;
   
   public FlowController FlowController
      {
          set => _flowController = value;
      }
   
      public PourController PourController
      {
          set => pourController = value;
      }
   
      public List<Valve> Valves
      {
          set => valves = value;
      }
   
      public IInputManager Input
      {
          set => _input = value;
      }
      
   private void Start()
   {
       _input.RightButtonDown += OnValve;
       _input.RightButtonUp += OffValve;
       foreach (var valve in valves)
       {
           valve.Subscribe(_flowController);
           valve.Subscribe(pourController);
       }
   }

   private void OnValve(Vector3 mouseViewpoint)
    {
        _mostValve = valves[0];
        foreach (var valve in valves)
        {
            if ((mouseViewpoint - valve.ValveViewpoint ).magnitude < (mouseViewpoint - _mostValve.ValveViewpoint).magnitude)
                _mostValve = valve;
        }
        
        _input.RightButton += _mostValve.EulerRotation;
    }

   private void OffValve(Vector3 mouseViewpoint)
   {
           _mostValve.LastPoint = mouseViewpoint; 
           _input.RightButton -= _mostValve.EulerRotation;
   }
}
