using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public Transform[] points;
    public GameObject factory;

    private void Start()
    {
        StartCoroutine(SpawnFactory());
    }

    IEnumerator SpawnFactory()
    {
        for (int i = 0; i < points.Length; i++)
        {
            yield return new WaitForSeconds(10f);
            GameObject spawn = Instantiate(factory);
            Destroy(spawn.GetComponent<PlaceObjects>());
            spawn.tag = "EnemyObstacle";
            spawn.transform.position = points[i].position;
            spawn.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            spawn.GetComponent<CarCreate>().enabled = true;
            spawn.GetComponent<CarCreate>().IsEnemy = true;

            GameSystem gameSystem = FindObjectOfType<GameSystem>();
            if (gameSystem != null)
            {
                gameSystem.enemyCount++;
            }
        }
    }
}
