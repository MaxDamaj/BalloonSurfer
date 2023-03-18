using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Helpers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemySource : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public BoxCollider2D boxCollider;
        [Header("Stats")]
        public double minSpawnScore;
        public double maxSpawnScore;
        public float moveDownSpeed;
    }
}
