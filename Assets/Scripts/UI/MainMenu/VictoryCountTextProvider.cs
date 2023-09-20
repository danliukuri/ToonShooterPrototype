using TMPro;
using UnityEngine;

namespace ToonShooterPrototype.UI.MainMenu
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class VictoryCountTextProvider : MonoBehaviour
    {
        public TextMeshProUGUI TextMeshPro { get; private set; }

        private void Awake() => TextMeshPro = GetComponent<TextMeshProUGUI>();
    }
}