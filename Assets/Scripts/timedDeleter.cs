using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedDeleter : MonoBehaviour
{
    public float delay = 3f;
    void Start()
    {
        Invoke("Kill", delay);
    }

    // Update is called once per frame
    void Kill()
    {
        Destroy(gameObject);
    }
}
