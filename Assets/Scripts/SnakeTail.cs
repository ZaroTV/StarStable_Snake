using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField]
    public SnakeTail nextTail;

    [SerializeField]
    private GameObject tailPref;

    [SerializeField]
    private bool hasTail;

    private void Awake()
    {
           hasTail = false;
    }
    protected void Move(Vector3 newPos)
    {
        if(this.nextTail != null)
        {
            this.nextTail.Move(this.transform.position);
        }
        this.transform.position = newPos;
    }

    protected void SetNextTail(SnakeTail newTail)
    {
        this.nextTail = newTail;
    }

    public void SpawnTail()
    {
        if (!hasTail)
        {
            var newTail = Instantiate(tailPref, new Vector3(99,99,0), Quaternion.identity);
            this.SetNextTail(newTail.GetComponent<SnakeTail>());
            this.hasTail = true;
        }
        else if(hasTail)
        {
            this.nextTail.GetComponent<SnakeTail>().SpawnTail();
        }
    }
}
