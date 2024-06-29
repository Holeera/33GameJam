using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private GameObject[] enemies;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {

        yield return new WaitForSeconds(10);
        Instantiate(enemies[Random.Range(0,2)], points[Random.Range(0, 4)].position, transform.rotation);
        StartCoroutine(Spawn());
    }
}
