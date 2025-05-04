using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // function variables
    public int damage = 10;
    public float lifetime = 2f;
    private bool isClone = false;

    // markAsClone function helps identify which of the bullets are clones
    public void MarkAsClone()
    {
        isClone = true;
    }

    // detect clones and deletes them after a predertermined time
    void Start()
    {
        if (isClone)
        {
            Destroy(gameObject, lifetime);
        }
    }
}
