using UnityEngine;
using UnityEngine.UI;

namespace ToonShooterPrototype.UI.MainMenu
{
    [RequireComponent(typeof(Button))]
    public class ExitButtonEventsHandler : MonoBehaviour
    {
        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(Clicked);

        private void OnDisable() => _button.onClick.RemoveListener(Clicked);

        private void Clicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            Application.Quit();
            Application.OpenURL("https://yuriy-danyliuk.itch.io/");
#else
            Application.Quit();
#endif
        }
    }
}