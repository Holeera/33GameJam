using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootWithMouse : MonoBehaviour
{
    private bool isShooting = false;
    Vector3 mousePos;

    private void Start()
    {

    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
        if (Input.GetMouseButtonDown(1) && !isShooting)
        {
            StartCoroutine(ShootNet());
        }
        if (Input.GetKeyDown(KeyCode.E) && !isShooting && ScriptInfrastructure.Instance.bigNetCounter > 0)
        {
            StartCoroutine(ShootNetBig());
        }
    }


    public IEnumerator Shoot()
    {
        isShooting = true;
        GameObject temp = Instantiate(ScriptInfrastructure.Instance.bullet, ScriptInfrastructure.Instance.gun.transform.position, ScriptInfrastructure.Instance.gun.transform.rotation);
        temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.player.transform.forward * 1000);
        StartCoroutine(Kill(temp));
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    public IEnumerator ShootNet()
    {
        isShooting = true;
        GameObject temp = Instantiate(ScriptInfrastructure.Instance.net, ScriptInfrastructure.Instance.gun.transform.position, ScriptInfrastructure.Instance.gun.transform.rotation);
        temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.player.transform.forward * 1000);
        StartCoroutine(Kill(temp));
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    private IEnumerator ShootNetBig()
    {
        ScriptInfrastructure.Instance.bigNetCounter--;
        isShooting = true;
        GameObject temp = Instantiate(ScriptInfrastructure.Instance.netBig, ScriptInfrastructure.Instance.gun.transform.position, ScriptInfrastructure.Instance.gun.transform.rotation);
        temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.player.transform.forward * 1000);
        StartCoroutine(Kill(temp));
        yield return new WaitForSeconds(0.5f);
        isShooting = false;

    }
    public IEnumerator Kill(GameObject temp)
    {
        yield return new WaitForSeconds(1);

        Destroy(temp);
    }
}
