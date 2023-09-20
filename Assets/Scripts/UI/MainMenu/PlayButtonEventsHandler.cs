﻿using ToonShooterPrototype.Data.Static.Enumerations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ToonShooterPrototype.UI.MainMenu
{
    [RequireComponent(typeof(Button))]
    public class PlayButtonEventsHandler : MonoBehaviour
    {
        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(Clicked);

        private void OnDisable() => _button.onClick.RemoveListener(Clicked);

        private void Clicked() => SceneManager.LoadSceneAsync((int)SceneName.Gameplay);
    }
}