namespace DefaultNamespace
{
    public interface IWaterFlow
    {
        float StartSpeed { get; }
        float StartSize{ get; } 
        float Simulation { get; }
        
        float StartSpeedPercent { set; }
        float StartSizePercent { set; }
        float SimulationPercent { set; }
    }
}