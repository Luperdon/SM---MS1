using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCreate : MonoBehaviour
{
    public Interface countTroops;
    [NonSerialized]
    public bool IsEnemy = false;
    public GameObject car;
    public float time = 2f;
    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        for(int i = 1; i <= 5; i++)
        {
            yield return new WaitForSeconds(time);
            Vector3 pos = new Vector3(
                transform.GetChild(1).position.x + UnityEngine.Random.Range(3f, 7f),
                transform.GetChild(1).position.y,
                transform.GetChild(1).position.z + UnityEngine.Random.Range(3f, 7f));
            GameObject spawn = Instantiate(car, pos, Quaternion.identity);
            if (IsEnemy == true)
            {
                spawn.tag = "Enemy";
            }
        }
    }
}
