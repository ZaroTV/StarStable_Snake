using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehaviour : MonoBehaviour
{
    [SerializeField]
    private int scoreValue;
    [SerializeField]
    private float lifeLength;
    public void Die(int didPlayerKill)
    {
        switch (didPlayerKill)
        {
            case 1:
                GetComponentInParent<GameHandler>().UpdateScore(scoreValue);
                Destroy(this.gameObject);
                break; 
            default:
                Destroy(this.gameObject);
                break;
        }
    }
    private void Start()
    {
        Invoke(nameof(Die), lifeLength);
    }
}
