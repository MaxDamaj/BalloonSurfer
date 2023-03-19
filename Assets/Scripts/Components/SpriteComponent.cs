using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct SpriteComponent : IComponent
    {
        public SpriteRenderer spriteRenderer;

        public void Init(GameObject prefab)
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = prefab.GetComponentInChildren<SpriteRenderer>();
            }
        }

        public void Init(Sprite sprite)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprite;
            }
        }
    }
}
