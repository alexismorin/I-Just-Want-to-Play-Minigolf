using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnEnable : MonoBehaviour {

    public GameObject[] itemsToEnable;

    void OnEnable () {

        itemsToEnable[Random.Range (0, itemsToEnable.Length)].gameObject.SetActive (true);
    }

}