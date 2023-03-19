using BalloonSurfer.EntitySources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct ColliderComponent : IComponent
    {
        public BoxCollider2D collider;

        public void Init(GameObject prefab, EnemySource enemyData)
        {
            if (collider == null)
            {
                collider = prefab.GetComponent<BoxCollider2D>();
            }

            Init(enemyData);
        }

        public void Init(EnemySource enemyData)
        {
            if (collider != null && enemyData.boxCollider != null)
            {
                collider.size = enemyData.boxCollider.size;
            }
        }
    }
}
