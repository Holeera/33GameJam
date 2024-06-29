using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System;
using UnityEditor.Experimental.GraphView;

public class PlayerMove : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody rb;
    public Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveCharacter(movement);
    }

    private void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction* speed * Time.fixedDeltaTime;
    }
}
