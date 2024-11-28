using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAttack : MonoBehaviour
{
    [NonSerialized] public int _health = 100;

    public const float radius = 70f;
    public GameObject bullet;
    private Coroutine _coroutine = null;
    private void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        if (hitColliders.Length == 0 && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;

            if (gameObject.CompareTag("Enemy"))
                GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
        }

        foreach (var el in hitColliders)
        {
            if ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy")) ||
                (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player")) ||
                ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("EnemyObstacle")) ||
                ((gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("PlayerObstacle")))))
            {
                GetComponent<NavMeshAgent>().SetDestination(el.transform.position);

                if (_coroutine == null && (gameObject.CompareTag("Enemy") || (gameObject.CompareTag("EnemyObstacle"))))
                {
                    _coroutine = StartCoroutine(StartAttack(el));
                }
            }
        }
    }

    IEnumerator StartAttack(Collider enemyPos)
    {
            GameObject obj = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
            obj.GetComponent<BulletController>().position = enemyPos.transform.position;
            yield return new WaitForSeconds(1f);
            StopCoroutine(_coroutine);
            _coroutine = null;
    }
}
