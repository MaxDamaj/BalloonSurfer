using BalloonSurfer.Helpers;
using BalloonSurfer.InitData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct SpawnableComponent : IComponent
    {
        public string id;
        public Transform transform;

        private float _minSpawnHeight;
        private float _maxSpawnHeight;
        private bool _isRandomRotate;

        public void Init(GameObject prefab, float minHeight, float maxHeight, bool isRandomRotate = false)
        {
            transform = prefab.transform;

            _minSpawnHeight = minHeight;
            _maxSpawnHeight = maxHeight;
            _isRandomRotate = isRandomRotate;
        }

        public void Spawn(int line)
        {
            transform.position = new Vector3(
                line * MainData.GetData<FieldInitData>().FieldLineWidth,
                Random.Range(_minSpawnHeight,_maxSpawnHeight),
                0
             );

            if (_isRandomRotate)
            {
                transform.Rotate(0, 0, Random.Range(-180f, 180f));
            }
        }

        public void SetHeight(float height)
        {
            transform.position = new Vector3(
                transform.position.x,
                height,
                transform.position.z
            );
        }
    }
}
