using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehaviour : MonoBehaviour
{
    [SerializeField]
    private int scoreValue;
    [SerializeField]
    private float lifeLength;
    public void Die()
    {
        GetComponentInParent<GameHandler>().UpdateScore(scoreValue);
        Destroy(this.gameObject);
    }

    private void Start()
    {
        Invoke("Die", lifeLength);
    }
}
