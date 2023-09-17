using Cinemachine;
using ToonShooterPrototype.Data.Static.Configuration;
using UnityEngine;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class PlayerCameraData
    {
        public PlayerCameraData(PlayerCameraConfig config, Transform transform, CinemachineFreeLook freeLook,
            CinemachineFreeLook aim)
        {
            Config = config;
            Transform = transform;
            FreeLook = freeLook;
            Aim = aim;
        }

        public PlayerCameraConfig Config { get; set; }

        public Transform Transform { get; set; }

        public CinemachineFreeLook FreeLook { get; set; }

        public CinemachineFreeLook Aim { get; set; }
    }
}