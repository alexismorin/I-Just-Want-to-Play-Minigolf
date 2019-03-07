using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Transform playerPosition;
     public Rigidbody rb;
     bool Updating;

    void Start () {
         rb = GetComponent<Rigidbody>();
         playerPosition = GameObject.Find ("Player").transform;
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "club") {
            
            Invoke ("Adjust", 3f);
        }

    }

    public void Adjust(){
Updating = true;
Invoke ("Stop", 3f);
    }

        public void Stop(){
Updating = true;
    }

    void Update(){
    if(rb.velocity.magnitude >0f && Updating == true){
 playerPosition.position = this.transform.position;
    }
    }


}