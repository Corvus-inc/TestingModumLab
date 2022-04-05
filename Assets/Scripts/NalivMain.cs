using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class NalivMain : MonoBehaviour
    {
        private void Awake()
        {
           var input = CompositionRoot.GetInputManager();
           var cam = CompositionRoot.GetCameraMoveController();
           var valveHandler = CompositionRoot.GetValveHandler();
           var naliv = CompositionRoot.GetNalivView();
           var flowController = CompositionRoot.GetFlowController();
           var pourController = CompositionRoot.GetPourController();
           
           foreach (var el in naliv.WaterFalls)
           {
               flowController.AddWaterfall(el);
           }

           pourController.Fluid = naliv.Fluid;
           pourController.FluidMaterial = naliv.FluidMaterial;
           
           valveHandler.Valves = naliv.Valves;
           valveHandler.Input = input;
           valveHandler.FlowController = flowController;
           valveHandler.PourController = pourController;

           cam.inputManager = input;
        }
    }
}
