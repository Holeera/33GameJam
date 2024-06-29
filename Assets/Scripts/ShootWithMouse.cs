using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootWithMouse : MonoBehaviour
{
    private bool isShooting = false;
    [SerializeField] Camera mainCam;
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
        if (Input.GetKeyDown(KeyCode.E) && !isShooting)
        {
            StartCoroutine(ShootNetBig());
        }
    }


    public IEnumerator Shoot()
    {
        isShooting = true;
        GameObject temp = Instantiate(ScriptInfrastructure.Instance.bullet, ScriptInfrastructure.Instance.player.transform.position, ScriptInfrastructure.Instance.player.transform.rotation);
        if (ScriptInfrastructure.Instance.playerMove.movement.normalized != new Vector3(0, 0, 0))
        {
            temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.playerMove.movement.normalized * 1000);

        }
        else
        {
            temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.playerMove.movement.normalized + new Vector3(0, 0, 1f) * 1000);
        }
        StartCoroutine(Kill(temp));
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    public IEnumerator ShootNet()
    {
        isShooting = true;
        GameObject temp = Instantiate(ScriptInfrastructure.Instance.net, ScriptInfrastructure.Instance.player.transform.position, ScriptInfrastructure.Instance.player.transform.rotation);
        if (ScriptInfrastructure.Instance.playerMove.movement.normalized != new Vector3(0, 0, 0))
        {
            temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.playerMove.movement.normalized * 1000);

        }
        else
        {
            temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.playerMove.movement.normalized + new Vector3(0, 0, 1f) * 1000);
        }
        StartCoroutine(Kill(temp));
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    private IEnumerator ShootNetBig()
    {
        isShooting = true;
        GameObject temp = Instantiate(ScriptInfrastructure.Instance.netBig, ScriptInfrastructure.Instance.player.transform.position, ScriptInfrastructure.Instance.player.transform.rotation);
        if (ScriptInfrastructure.Instance.playerMove.movement.normalized != new Vector3(0, 0, 0))
        {
            temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.playerMove.movement.normalized * 1000);

        }
        else
        {
            temp.GetComponent<Rigidbody>().AddForce(ScriptInfrastructure.Instance.playerMove.movement.normalized + new Vector3(0, 0, 1f) * 1000);
        }
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
