using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField]
    public SnakeTail nextTail; // target

    [SerializeField]
    private GameObject tailPref;

    protected void Move(Vector3 newPos)
    {
        if(nextTail != null)
            nextTail.Move(this.transform.position);
        this.transform.position = newPos;
    }

    protected void SetNextTail(SnakeTail newTail)
    {
        nextTail = newTail;
    }

    protected void SpawnTail()
    {
        Instantiate(tailPref, this.transform.position -= Vector3.forward, Quaternion.identity);
        //tailPref.GetComponent<SnakeTail>().SetNextTail(this.gameObject.GetComponent<SnakeTail>()); // prefab target 
    }
}
