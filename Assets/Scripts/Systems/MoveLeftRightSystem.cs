using BalloonSurfer.Components;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class MoveLeftRightSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<MoveLeftRightComponent> _filter = null;

        private float _leftBorder;
        private float _rightBorder;

        public void Init()
        {
            _leftBorder = MainData.GetData<FieldInitData>().FieldLowerBorder * MainData.GetData<FieldInitData>().FieldLineWidth - MainData.GetData<FieldInitData>().FieldLineWidth / 2;
            _rightBorder = MainData.GetData<FieldInitData>().FieldUpperBorder * MainData.GetData<FieldInitData>().FieldLineWidth + MainData.GetData<FieldInitData>().FieldLineWidth / 2;
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var leftRight = ref _filter.Get1(i);

                if (leftRight.transform.position.x > _rightBorder || leftRight.transform.position.x < _leftBorder)
                {
                    leftRight.SwitchDirection();
                }

                leftRight.transform.position += new Vector3(leftRight.direction, 0, 0);
            }
        }
    }
}
