using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Transform playerPosition;
    public GameObject ovrPlayer;
    public Rigidbody rb;
    bool Updating;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPosition = GameObject.Find("Player").transform;
        ovrPlayer = GameObject.Find("OVRCameraRig");
        Updating = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "club" && Updating == true)
        {
            CancelInvoke("Adjust");
            CancelInvoke("Stop");
            Invoke("Adjust", 3f);
        }

    }

    public void Adjust()
    {
        rb.isKinematic = true;
        Updating = false;
        ovrPlayer.GetComponent<OVRPlayerController>().enabled = false;
        ovrPlayer.GetComponent<CharacterController>().enabled = false;
        playerPosition.position = this.transform.position;
        ovrPlayer.transform.position = this.transform.position;


        Invoke("Stop", 1f);
    }

    public void Stop()
    {
        ovrPlayer.GetComponent<OVRPlayerController>().enabled = true;
        ovrPlayer.GetComponent<CharacterController>().enabled = true;
        Invoke("Allow", 1f);
    }

    public void Allow()
    {
        rb.isKinematic = false;
        Updating = true;
    }


}