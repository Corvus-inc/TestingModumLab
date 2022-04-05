using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class FlowController : MonoBehaviour, IObserver<ValveStatus>
{
    private List<Waterfall> waterfalls = new List<Waterfall>();
    
    private List<ValveStatus> _valves;
    private List<WaterfallSetting> _waterfallSettings;
    private List<DropletsSetting> _dropletsSettings;

    public void AddWaterfall(Waterfall value)
    {
        waterfalls.Add(value);
        _waterfallSettings.Add(new WaterfallSetting());
        _dropletsSettings.Add(new DropletsSetting());
    }
    
    private void Awake()
    {
        _valves = new List<ValveStatus>();
        _waterfallSettings = new List<WaterfallSetting>();
        _dropletsSettings = new List<DropletsSetting>();
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
        if (_valves.Any(_ => _.Id == value.Id))
        {
            _valves.Add(value);
            _waterfallSettings.Add(new WaterfallSetting());
            _dropletsSettings.Add(new DropletsSetting());
        }
        var percent = value.CurrentRangeRotate / 7.2f;
        
        ForceWaterFlow(_waterfallSettings[value.Id], waterfalls[value.Id].WaterfallEffect,percent);
        ForceWaterFlow(_dropletsSettings[value.Id], waterfalls[value.Id].DropletsEffect,percent);
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
