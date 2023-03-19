using BalloonSurfer.Helpers;
using BalloonSurfer.InitData;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BalloonSurfer.UI
{
    public class UIMainScreenPanel : MonoBehaviour, IScoreUpdate
    {
        [SerializeField] private Button _buttonPause = null;
        [SerializeField] private TextMeshProUGUI _textScore = null;

        public static event Action OnPause, OnUnpause;

        void Start()
        {
            _buttonPause.onClick.AddListener(PauseGame);
        }

        public void UpdateScore(int scoreValue)
        {
            _textScore.text = scoreValue.ToString();
        }


        private void PauseGame()
        {
            if (SharedData.Instance.isGamePaused)
            {
                OnUnpause?.Invoke();
            }
            else
            {
                OnPause?.Invoke();
            }
        }

        
    }
}
