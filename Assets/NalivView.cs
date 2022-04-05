using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class NalivView : MonoBehaviour
{
    [SerializeField] private List<Valve> valves;
    [SerializeField] private List<Waterfall> waterFalls;
    [SerializeField] private Transform fluid;  
    [SerializeField] private Material fluidMaterial;
    
    public List<Valve> Valves => valves;
    public List<Waterfall> WaterFalls => waterFalls;
    public Transform Fluid => fluid;  
    public Material FluidMaterial => fluidMaterial;


    
}
