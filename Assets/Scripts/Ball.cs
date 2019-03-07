using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Transform playerPosition;

    void OnEnable () {
        Transform playerPosition = GameObject.Find ("Player").transform;
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "club") {
            Invoke ("Adjust", 4f);
        }

    }

    void Adjust () {
        playerPosition.position = this.transform.position;
    }
}