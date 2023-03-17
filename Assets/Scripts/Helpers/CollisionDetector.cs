using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    public event Action OnEnemyHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                OnEnemyHit?.Invoke();
                break;
        }
    }

}
