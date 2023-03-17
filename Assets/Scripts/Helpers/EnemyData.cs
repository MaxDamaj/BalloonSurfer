using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Helpers
{
    [Serializable]
    public class EnemyData
    {
        public string enemyName;
        public Sprite sprite;
        public Vector2 colliderSize;
        public double minSpawnScore;
        public double maxSpawnScore;
        public float moveDownSpeed;
    }
}
