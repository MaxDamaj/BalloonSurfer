using DG.Tweening;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class PlayerMoveSideSystem : IEcsInitSystem, IEcsDestroySystem, IEcsRunSystem
    {
        private EcsFilter<MoveSideComponent, MovableComponent> _filter = null;

        public void Destroy()
        {
            SwipeDetector.Instance.OnSwipe -= OnMoveSide;
        }

        public void Init()
        {
            SwipeDetector.Instance.OnSwipe += OnMoveSide;
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveSide = ref _filter.Get1(i);

                if (moveSide.remainingMoveTime > 0)
                {
                    moveSide.remainingMoveTime -= Time.deltaTime;
                }
            }
        }

        private void OnMoveSide(int direction)
        {
            foreach (var i in _filter)
            {
                ref var moveSide = ref _filter.Get1(i);
                ref var movable = ref _filter.Get2(i);

                if (1 >= (moveSide.currentLinePosition + direction) && -1 <= (moveSide.currentLinePosition + direction) && moveSide.remainingMoveTime <= 0)
                {
                    float moveTime = 20 / movable.speed;

                    moveSide.currentLinePosition += direction;
                    moveSide.remainingMoveTime = moveTime;

                    Sequence seq = DOTween.Sequence();
                    seq.Append(moveSide.transform.DOMoveX(moveSide.transform.position.x + (20 * direction), moveTime));
                    seq.Join(moveSide.transform.DORotate(MainData.Instance.playerInitData.moveRotationAngle * direction, moveTime));
                    seq.Append(moveSide.transform.DORotate(Vector3.zero, moveTime).SetEase(Ease.InOutSine));
                }
            }
        }
    }
}
