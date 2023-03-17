using BalloonSurfer.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct ColliderComponent
    {
        public SpriteRenderer spriteRenderer;
        public BoxCollider collider;

        public void Init(GameObject prefab, EnemyData enemyData)
        {
            spriteRenderer = prefab.GetComponentInChildren<SpriteRenderer>();
            collider = prefab.GetComponent<BoxCollider>();
            Mutate(enemyData);
        }

        public void Mutate(EnemyData enemyData)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = enemyData.sprite;
            }

            if (collider != null)
            {
                collider.size = enemyData.colliderSize;
            }
        }
    }
}
