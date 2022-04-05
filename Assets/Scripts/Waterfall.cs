using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
   [SerializeField] private ParticleSystem waterfall;
   [SerializeField] private ParticleSystem droplets;

   public ParticleSystem WaterfallEffect => waterfall;
   public ParticleSystem DropletsEffect => droplets;
}
