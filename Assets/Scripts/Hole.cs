using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour {

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "ball") {
            Scene scene = SceneManager.GetActiveScene ();
            SceneManager.LoadScene (scene.name);
        }
        if (other.gameObject.tag == "club") {

            Transform clubLocation = GameObject.Find ("Player").transform.GetChild (0);

            other.gameObject.transform.position = clubLocation.position;
   //         other.gameObject.transform.rotation = clubLocation.rotation;
        }
    }
}