using BalloonSurfer.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemiesInitData")]
public class EnemiesInitData : ScriptableObject
{
    public int maxEnemiesOnField = 8;
    public float enemiesSpawnDelay = 4;
    public GameObject baseEnemyPrefab;
    public List<EnemyData> enemies;
    public float minSpawnHeight = 120;
    public float maxSpawnHeight = 200;

    public EnemyData GetRandomEnemy()
    {
        var score = SharedData.Instance.scoreValue;
        var enemiesData = enemies.FindAll(x => x.minSpawnScore <= score && x.maxSpawnScore >= score);

        if (enemiesData.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, enemiesData.Count);
            return enemiesData[randomIndex];
        }
        else
        {
            return enemies.Last();
        }
    }
}
