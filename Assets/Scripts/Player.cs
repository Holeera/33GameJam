using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public Camera cam;
    bool npcQuest = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            TakeDamage(5);
        }
        if (other.gameObject.tag == "supply")
        {
            ScriptInfrastructure.Instance.bigNetCounter = 5;
        }
        if(other.gameObject.tag == "NPC" && !npcQuest)
        {
            npcQuest = true;
            Debug.Log("Quest");
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyPlayer), 0.5f);
    }
    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        
        float t = cam.transform.position.y / (cam.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, 1, t * (point.z - cam.transform.position.z) + cam.transform.position.z);
        
        gameObject.transform.LookAt(finalPoint, Vector3.up);
    }
}

