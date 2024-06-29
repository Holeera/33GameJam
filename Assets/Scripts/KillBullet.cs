using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBullet : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(killthis());
    }
    private IEnumerator killthis()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
   
}
