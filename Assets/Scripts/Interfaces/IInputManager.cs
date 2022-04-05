using System;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IInputManager
    {
        event Action<Vector3> RightButton; 
        event Action<Vector3> RightButtonDown; 
        event Action<Vector3> RightButtonUp; 
        event Action<Vector3> LeftButton;

        event Action ToForward;
        event Action ToLeft;
        event Action ToBack;
        event Action ToRight;
        event Action BoostSpeedOn;
        event Action BoostSpeedOff;
    }
}