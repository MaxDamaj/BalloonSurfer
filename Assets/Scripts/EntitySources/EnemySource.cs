using BalloonSurfer.Creators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.EntitySources
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemySource : MutableSource
    {
        public SpriteRenderer spriteRenderer;
        public BoxCollider2D boxCollider;
        [Header("Stats")]
        public double minSpawnScore;
        public double maxSpawnScore;
        public float moveDownSpeed;

        public override void SetCreator()
        {
            Creator = new EnemyCreator();
        }
    }
}
