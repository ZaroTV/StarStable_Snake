using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private Vector2Int foodGridPos;
    private int width;
    private int height;
    private int score;
    private int timeElapsed;

    [SerializeField]
    private float foodRate;
    [SerializeField]
    private GameObject food;

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Text timeElapsedText;
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private AudioSource audioPlayer;
    [SerializeField]
    private AudioClip pickUpSound;
    [SerializeField]
    private AudioClip deathSound;

    private void Start()
    {
        InvokeRepeating(nameof(SetTime), 0.1f, 1f);
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
        scoreText.text = score.ToString();
        audioPlayer.PlayOneShot(pickUpSound);
        Debug.Log("Snake just scored :" + score);
        if (score >= 1000)
        {
            Win();
        }
    }
    public void Win()
    {
        Debug.Log("Good job");
    }
    public void Lose()
    {
        StartCoroutine(ReloadGame());
        Debug.Log("Unlucky, better luck next time");
    }
    private void SetTime()
    {
        timeElapsed++;
        timeElapsedText.text = timeElapsed.ToString();
    }
    IEnumerator ReloadGame()
    {
        audioPlayer.PlayOneShot(deathSound);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
        yield return null;
    }
}