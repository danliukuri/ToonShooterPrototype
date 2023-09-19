using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public class AlphaButtonsInputService : IInitializable, ITickable, IAlphaButtonsInputService
    {
        public event Action<int> AlphaButtonPressed;

        private Dictionary<KeyCode, Action> _inputEvents;

        public void Initialize() => _inputEvents = new Dictionary<KeyCode, Action>
        {
            { KeyCode.Alpha1, () => AlphaButtonPressed?.Invoke(0) },
            { KeyCode.Alpha2, () => AlphaButtonPressed?.Invoke(1) },
            { KeyCode.Alpha3, () => AlphaButtonPressed?.Invoke(2) },
            { KeyCode.Alpha4, () => AlphaButtonPressed?.Invoke(3) },
            { KeyCode.Alpha5, () => AlphaButtonPressed?.Invoke(4) },
            { KeyCode.Alpha6, () => AlphaButtonPressed?.Invoke(5) },
            { KeyCode.Alpha7, () => AlphaButtonPressed?.Invoke(6) },
            { KeyCode.Alpha8, () => AlphaButtonPressed?.Invoke(7) },
            { KeyCode.Alpha9, () => AlphaButtonPressed?.Invoke(8) },
            { KeyCode.Alpha0, () => AlphaButtonPressed?.Invoke(9) }
        };

        public void Tick()
        {
            foreach (KeyValuePair<KeyCode, Action> inputEvent in _inputEvents)
                if (UnityEngine.Input.GetKeyDown(inputEvent.Key))
                    inputEvent.Value.Invoke();
        }
    }
}