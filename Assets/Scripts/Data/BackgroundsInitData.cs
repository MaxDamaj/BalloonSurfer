using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.InitData
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BackgroundsInitData")]
    public class BackgroundsInitData : InitData
    {
        public float backsSpawnDelay = 10f;

        public GameObject basePrefab;
        public float spawnHeight = 115;
        public float firstSpawnHeight = 115;
        public float moveSpeed = 1;

        public List<Sprite> backgrounds;


        public float DespawnHeight
        {
            get
            {
                return firstSpawnHeight + (firstSpawnHeight - spawnHeight);
            }
        }

        public Sprite NextBackgroundSprite
        {
            get
            {
                SharedData.Instance.currentBackIndex++;

                if (SharedData.Instance.currentBackIndex >= backgrounds.Count)
                {
                    SharedData.Instance.currentBackIndex = backgrounds.Count - 1;
                }

                return backgrounds[SharedData.Instance.currentBackIndex];
            }
        }
    }
}
