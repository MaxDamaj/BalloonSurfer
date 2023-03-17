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
        public EnemySource enemySource;
        public double minSpawnScore;
        public double maxSpawnScore;
        public float moveDownSpeed;
    }
}
