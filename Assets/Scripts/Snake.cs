using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : SnakeTail
{
    [SerializeField]
    private float moveRate;

    private void Awake()
    {
        InvokeRepeating(nameof(SnakeMovement), 0.5f, moveRate);
    }
    private void SnakeMovement(Vector3 playerInput)
    {
        //always go right
        Move(this.transform.position + playerInput);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnTail();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SnakeMovement(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SnakeMovement(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SnakeMovement(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SnakeMovement(Vector3.right);
        }
    }
}
