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

        public void Init(GameObject prefab, EnemySource enemyData)
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = prefab.GetComponentInChildren<SpriteRenderer>();
            }

            if (collider == null)
            {
                collider = prefab.GetComponent<BoxCollider>();
            }

            Init(enemyData);
        }

        public void Init(EnemySource enemyData)
        {
            if (spriteRenderer != null && enemyData.spriteRenderer != null)
            {
                spriteRenderer.sprite = enemyData.spriteRenderer.sprite;
            }

            if (collider != null && enemyData.boxCollider != null)
            {
                collider.size = enemyData.boxCollider.size;
            }
        }
    }
}
