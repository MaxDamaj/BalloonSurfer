using BalloonSurfer.InitData;
using BalloonSurfer.UI;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class PauseGameSystem : IEcsInitSystem, IEcsDestroySystem
    {
        public void Destroy()
        {
            UIMainScreenPanel.OnPause -= PauseGame;
            UIMainScreenPanel.OnUnpause -= UnpauseGame;
        }

        public void Init()
        {
            UIMainScreenPanel.OnPause += PauseGame;
            UIMainScreenPanel.OnUnpause += UnpauseGame;
            UnpauseGame();
        }

        public void PauseGame()
        {
            SharedData.Instance.isGamePaused = true;
            Time.timeScale = 0;
        }

        public void UnpauseGame()
        {
            SharedData.Instance.isGamePaused = false;
            Time.timeScale = 1;
        }
    }
}
