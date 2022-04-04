using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class WaterfallSetting : MonoBehaviour, IWaterFlow
    {
        private const float MinStartSpeedWaterfall = 0f;
        private const float MaxStartSpeedWaterfall = 9f;
        private const float MinStartSizeWaterfall = 0f;
        private const float MaxStartSizeWaterfall = 5f;
        private const float MinSimulationWaterfall = 0.5f;
        private const float MaxSimulationWaterfall = 1f;

        [Range(MinStartSpeedWaterfall, MaxStartSpeedWaterfall)] [SerializeField]
        private float startSpeedWaterfall;

        [Range(MinStartSizeWaterfall, MaxStartSizeWaterfall)] [SerializeField]
        private float startSizeWaterfall;

        [Range(MinSimulationWaterfall, MaxSimulationWaterfall)] [SerializeField]
        private float simulationWaterfall;

        public float StartSpeed => startSpeedWaterfall;
        public float StartSize => startSizeWaterfall;
        public float Simulation => simulationWaterfall;

        public float StartSpeedPercent
        {
            // get => startSpeedWaterfall / (MaxStartSpeedWaterfall - MinStartSpeedWaterfall) *100;
            set => startSpeedWaterfall = SetPercent(MinStartSpeedWaterfall, MaxStartSpeedWaterfall, value);
        }

        public float StartSizePercent
        {
            // get => startSizeWaterfall/(MaxStartSizeWaterfall - MinStartSizeWaterfall) * 100;
            set => startSizeWaterfall = SetPercent(MinStartSizeWaterfall, MaxStartSizeWaterfall, value);
        }

        public float SimulationPercent
        {
            // get => simulationWaterfall/(MaxSimulationWaterfall - MinSimulationWaterfall) * 100;
            set => simulationWaterfall = SetPercent(MinSimulationWaterfall, MaxSimulationWaterfall, value);
        }

        public static float SetPercent(float MinValue, float MaxValue, float percentValue)
        {
            return MinValue + (MaxValue - MinValue) / 100 * percentValue;
        }
    }
}
