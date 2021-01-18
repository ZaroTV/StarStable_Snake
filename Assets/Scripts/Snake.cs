using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridDir;
    private Vector2Int gridPos;
    public List<Vector2Int> snakePrevPosList;

    [SerializeField]
    private GameObject snakeTail;
    public float moveRate;
    public int snakeSize;


    private void Awake()
    {
        gridPos = new Vector2Int(10, 10);
        InvokeRepeating("SetDir", 0.1f, moveRate);
        gridDir.x = 1;

        snakePrevPosList = new List<Vector2Int>();

    }

    private void Update()
    {
        PlayerInputs();
    }

    public void SnakeSize(int tail)
    {
        switch (tail)
        {
            case 1:
                snakeSize--;
                break;

            default:
                snakeSize++;
                AddLength();
                break;
        }
    }

    private void AddLength()
    {
        Instantiate(snakeTail, new Vector3(gridPos.x, gridPos.y), Quaternion.identity, this.gameObject.transform);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Apple"))
        {
            col.GetComponent<AppleBehaviour>().Die();
            SnakeSize(0);
        }
        

        if (col.CompareTag("Wall"))
        {
            col.GetComponentInParent<GameHandler>().Lose();
        }
    }

    private void PlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.W) && gridDir.y != -1)
        {
            gridDir.y = 1;
            gridDir.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.A) && gridDir.x != +1)
        {
            gridDir.y = 0;
            gridDir.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.S) && gridDir.y != +1)
        {
            gridDir.y = -1;
            gridDir.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) && gridDir.x != -1)
        {
            gridDir.y = 0;
            gridDir.x = 1;
        }
    }

    private void SetDir()
    {
        snakePrevPosList.Insert(0, gridPos);

        gridPos += gridDir;
        
        if(snakePrevPosList.Count >= snakeSize + 1)
        {
            snakePrevPosList.RemoveAt(snakePrevPosList.Count - 1);
        }

        transform.position = new Vector3(gridPos.x, gridPos.y);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridDir) - 90); //-90 is there because the Sprite is stolen and it's facing direction was not accounted for by the creator
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
