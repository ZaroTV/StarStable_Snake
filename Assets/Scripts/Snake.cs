using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : SnakeTail
{
    [SerializeField]
    private float moveRate;

    [SerializeField]
    private GameObject gameHandler;

    private static readonly Quaternion DIRECTION_UP = Quaternion.Euler(0,0,0);

    private static readonly Quaternion DIRECTION_LEFT = Quaternion.Euler(0, 0, 90);

    private static readonly Quaternion DIRECTION_DOWN = Quaternion.Euler(0, 0, 180);

    private static readonly Quaternion DIRECTION_RIGHT = Quaternion.Euler(0, 0, 270);


    private void Awake()
    {
        InvokeRepeating(nameof(AutoMovement), 0.5f, moveRate);
    }

    private void AutoMovement()
    {
        SnakeMovement(this.transform.up);
    }
    private void SnakeMovement(Vector3 playerInput)
    {
        Move(this.transform.position + playerInput);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && this.transform.eulerAngles != new Vector3(0, 0, 180))
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A) && this.transform.eulerAngles != new Vector3(0, 0, 270))
        {
            this.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.S) && this.transform.eulerAngles != new Vector3(0,0,0))
        {
            this.transform.eulerAngles = new Vector3(0, 0, -180);
        }
        if (Input.GetKeyDown(KeyCode.D) && this.transform.eulerAngles != new Vector3(0, 0, 90))
        {
            this.transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Tail") || col.gameObject.CompareTag("Wall"))
        {
            gameHandler.GetComponent<GameHandler>().Lose();
        }
        if (col.gameObject.CompareTag("Apple"))
        {
            col.gameObject.GetComponent<AppleBehaviour>().Die(1);
            SpawnTail();
        }
    }
}
