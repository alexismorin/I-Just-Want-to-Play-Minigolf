using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomYRotation : MonoBehaviour {

    void OnEnable () {
        float newRot = Random.Range (0f, 360f);
        transform.localEulerAngles = new Vector3 (0f, newRot, 0f);
    }

}