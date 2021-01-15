using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    private Vector2Int foodGridPos;
    private int width;
    private int height;
    [SerializeField]
    private GameObject food;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private float foodRate;
    private int score;

    private void Start()
    {
        width = 20;
        height = 20;
        InvokeRepeating("SpawnFood", 0.1f, foodRate);
    }
    private void SpawnFood()
    {
        foodGridPos = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        Instantiate(food, new Vector3(foodGridPos.x, foodGridPos.y, 0), Quaternion.identity, this.gameObject.transform);
    }

    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        Debug.Log("Snake just scored :" + score);
        if (score >= 1000)
        {
            Debug.Log(" nice gj");
        }

    }

    public void Win()
    {

    }

    public void Lose()
    {
        Debug.Log("Bruh u succ ballsaccc");
    }
}
