using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float scaleWave;
    
    [SerializeField] private Transform radiusWave;
    [SerializeField] private Transform levelWave;

    private void Update()
    {
        radiusWave.localScale = new Vector3(scaleWave, scaleWave, scaleWave);
        levelWave.localScale = new Vector3(scaleWave, scaleWave, scaleWave);
    }
}
