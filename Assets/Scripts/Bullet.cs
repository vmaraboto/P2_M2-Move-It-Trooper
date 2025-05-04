using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifetime = 2f;
    private bool isClone = false;

    public void MarkAsClone()
    {
        isClone = true;
    }

    void Start()
    {
        if (isClone)
        {
            Destroy(gameObject, lifetime);
        }
    }
}
