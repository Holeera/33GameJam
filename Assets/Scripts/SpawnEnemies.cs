using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3);
        Instantiate(ScriptInfrastructure.Instance.meleeEnemy, transform.position, transform.rotation);
        StartCoroutine(Spawn());
    }
}
