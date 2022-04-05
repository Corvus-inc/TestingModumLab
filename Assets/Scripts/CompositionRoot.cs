using DefaultNamespace.Managers;
using UnityEngine;

namespace DefaultNamespace
{
    public class CompositionRoot : MonoBehaviour
    {
        private static CameraMoveController _cameraMoveController;
        
        private static IResourceManager _resourceManager;
        private static IInputManager _inputManager;
        private static ValveHandler _valveHandler;
        private static NalivView _nalivView;
        private static FlowController _flowController;
        private static PourController _pourController;

        private void OnDestroy()
        {
            _inputManager = null;
        }

        public static PourController GetPourController()
        {
            if (_pourController == null)
            {
                GetResourceManager();
                _pourController = _resourceManager.CreatePrefabInstance<PourController, EManagers>(EManagers.PourController);
            }
            return _pourController;
        }

        public static FlowController GetFlowController()
        {
            if (_flowController == null)
            {
                GetResourceManager();
                _flowController = _resourceManager.CreatePrefabInstance<FlowController, EManagers>(EManagers.FlowController);
            }

            return _flowController;
        }

        public static ValveHandler GetValveHandler()
        {
            if (_valveHandler == null)
            {
                GetResourceManager();
                _valveHandler = _resourceManager.CreatePrefabInstance<ValveHandler, EManagers>(EManagers.ValveHandler);
            }

            return _valveHandler;
        }
        
        public static NalivView GetNalivView()
        {
            if (_nalivView == null)
            {
                GetResourceManager();
                _nalivView = _resourceManager.CreatePrefabInstance<NalivView, EComponents>(EComponents.naliv);
            }

            return _nalivView;
        }
        
        public static CameraMoveController GetCameraMoveController()
        { 
            if (_cameraMoveController == null)
            {
                GetResourceManager();
                _cameraMoveController = _resourceManager.CreatePrefabInstance<CameraMoveController, EComponents>( EComponents.FPVCamera);
            }
            
            return _cameraMoveController;
        }

        public static IResourceManager GetResourceManager()
        {
            if (_resourceManager == null)
            {
                _resourceManager = new ResourceManager();
            }
            
            return _resourceManager;
        }

        public static IInputManager GetInputManager()
        {
            if (_inputManager == null)
            {
                GetResourceManager();
                _inputManager = _resourceManager.CreatePrefabInstance<IInputManager, EManagers>( EManagers.InputManager);
            }

            return _inputManager;
        }
    }

    public enum EManagers
    {
        InputManager,
        ValveHandler,
        FlowController,
        PourController
    }

    public enum EComponents
    {
        FPVCamera,
        naliv
    }

}

