using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class DropletsSetting : MonoBehaviour, IWaterFlow
    {
        private const float MinStartSpeedDroplets = 0f;
        private const float MaxStartSpeedDroplets = 9f;
        private const float MinStartSizeDroplets = 0f;
        private const float MaxStartSizeDroplets = 15f;
        private const float MinSimulationDroplets = 0.5f;
        private const float MaxSimulationDroplets = 1f;

        [Range(MinStartSpeedDroplets, MaxStartSpeedDroplets)] [SerializeField]
        private float startSpeedDroplets;

        [Range(MinStartSizeDroplets, MaxStartSizeDroplets)] [SerializeField]
        private float startSizeDroplets;

        [Range(MinSimulationDroplets, MaxSimulationDroplets)] [SerializeField]
        private float simulationDroplets;

        public float StartSpeed => startSpeedDroplets;
        public float StartSize => startSizeDroplets;
        public float Simulation => simulationDroplets;

        public float StartSpeedPercent
        {
            // get => startSpeedDroplets / (MaxStartSpeedDroplets - MinStartSpeedDroplets) *100;
            set => startSpeedDroplets =
                WaterfallSetting.SetPercent(MinStartSpeedDroplets, MaxStartSpeedDroplets, value);
        }

        public float StartSizePercent
        {
            // get => startSizeDroplets/(MaxStartSizeDroplets - MinStartSizeDroplets) * 100;
            set => startSizeDroplets = WaterfallSetting.SetPercent(MinStartSizeDroplets, MaxStartSizeDroplets, value);
        }

        public float SimulationPercent
        {
            // get => simulationDroplets/(MaxSimulationDroplets - MinSimulationDroplets) * 100;
            set => simulationDroplets =
                WaterfallSetting.SetPercent(MinSimulationDroplets, MaxSimulationDroplets, value);
        }
    }
}
