using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    [NonSerialized] public int factoryHealth = 200;

    public void TakeDamage(int damage)
    {
        factoryHealth -= damage;
        if (factoryHealth <= 0)
        {
            Destroy(gameObject);
            GameSystem gameSystem = FindObjectOfType<GameSystem>();
            if (gameSystem != null)
            {
                if (gameObject.CompareTag("EnemyObstacle"))
                {
                gameSystem.EnemyDestroyed();
                }
                else if (gameObject.CompareTag("PlayerObstacle"))
                {
                    gameSystem.PlayerDestroyed();
                }
            }
        }
    }
}
