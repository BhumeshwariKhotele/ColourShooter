using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public Action onEnemyDestroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletController>() != null)
        {
            Destroy(gameObject);
            OnEnemyDestroyed();
        }
    }

    public void OnEnemyDestroyed()
    {
        Debug.Log("enemy destroyed");
    }
}

