using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemiesInitData")]
public class EnemiesInitData : ScriptableObject
{
    [Serializable]
    public class EnemyData
    {
        public GameObject prefab;
        public double minSpawnScore;
        public double maxSpawnScore;
        public float moveDownSpeed;
    }

    public List<EnemyData> enemies;
    public float minSpawnHeight = 120;
    public float maxSpawnHeight = 200;
}
