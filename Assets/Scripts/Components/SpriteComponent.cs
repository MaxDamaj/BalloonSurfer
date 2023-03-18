using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct SpriteComponent
    {
        public SpriteRenderer spriteRenderer;

        public void Init(GameObject prefab)
        {
            spriteRenderer = prefab.GetComponentInChildren<SpriteRenderer>();
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
