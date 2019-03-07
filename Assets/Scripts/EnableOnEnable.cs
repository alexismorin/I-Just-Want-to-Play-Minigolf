using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnEnable : MonoBehaviour {

    void OnEnable () {

        Transform[] transformList = GetComponentsInChildren<Transform> (true);

        transformList[Random.Range (0, transformList.Length)].gameObject.SetActive (true);
    }

}