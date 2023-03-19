using BalloonSurfer.InitData;
using BalloonSurfer.UI;
using DG.Tweening;
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
            UnpauseGame();
        }

        public void Init()
        {
            UIMainScreenPanel.OnPause += PauseGame;
            UIMainScreenPanel.OnUnpause += UnpauseGame;
            PauseGame();

            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(4f);
            seq.AppendCallback(UnpauseGame);

            seq.SetUpdate(true);
            seq.Play();
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
