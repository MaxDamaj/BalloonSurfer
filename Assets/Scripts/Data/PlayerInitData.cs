using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.InitData
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerInitData")]
    public class PlayerInitData : InitData
    {
        public GameObject prefab;
        public float moveSideSpeed = 15;
        public Vector3 moveRotationAngle = new Vector3(0, 0, -20);
    }
}
