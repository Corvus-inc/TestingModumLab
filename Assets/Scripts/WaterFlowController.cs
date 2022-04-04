using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WaterFlowController : MonoBehaviour, IObserver<ValveStatus>
{
    [SerializeField] private ParticleSystem waterfall1;
    [SerializeField] private WaterfallSetting waterfall1Setting;
    [SerializeField] private ParticleSystem waterfall2;
    [SerializeField] private WaterfallSetting waterfall2Setting;
    
    [SerializeField] private ParticleSystem droplets1;
    [SerializeField] private DropletsSetting droplets1Setting;
    [SerializeField] private ParticleSystem droplets2;
    [SerializeField] private DropletsSetting droplets2Setting;
    
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
        var percent = value.CurrentRangeRotate / 7.2f;
        
        if (value.Id == 0)
        {
            ForceWaterFlow(waterfall1Setting, waterfall1, percent);
            ForceWaterFlow(droplets1Setting, droplets1, percent);
        }

        if (value.Id == 1)
        {
            ForceWaterFlow(waterfall2Setting, waterfall2, percent);
            ForceWaterFlow(droplets2Setting, droplets2, percent);
        }
    }

    private void ForceWaterFlow(IWaterFlow setting, ParticleSystem waterFlow, float percent)
    {
        setting.StartSpeedPercent = percent;
        setting.StartSizePercent = percent;
        setting.SimulationPercent = percent;
        
        var mainWaterfall = waterFlow.main;
        mainWaterfall.startSpeed = setting.StartSpeed;
        mainWaterfall.startSize = setting.StartSize;
        mainWaterfall.simulationSpeed = setting.Simulation;
    }
}
