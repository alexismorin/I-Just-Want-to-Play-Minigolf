using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class gameStateManager : MonoBehaviour {

    public string[] loadedSettings;
    public GameObject tilePrefab;
    public GameObject[] tiles;
    [Space (15)]
    public GameObject startTile;
    public GameObject endTile;

    void Start () {
        LoadSettings ();
    }

    void LoadSettings () {

        string path = Application.streamingAssetsPath + "/settings.ini";

        StreamReader reader = new StreamReader (path);
        string settingsArray = reader.ReadToEnd ();
        reader.Close ();

        string[] lines = settingsArray.Split (new [] { System.Environment.NewLine }, System.StringSplitOptions.None);
        loadedSettings = lines;

        InitializeSettings ();
    }

    void InitializeSettings () {
        if (loadedSettings[0] == "1") { // use the seed provided on line 2 of settings.ini
            Random.InitState (int.Parse (loadedSettings[1]));
        } else { // random seed - do this if you want to play random matches every time
            Random.InitState (Random.Range (0, 999999));
        }

        BuildMap ();
    }

    void BuildMap () { // build golf green, square of size is line 3 of settings.ini

        for (int x = 0; x < int.Parse (loadedSettings[2]); x++) {
            Instantiate (tilePrefab, new Vector3 (x * 5f, 0, 0), Quaternion.identity);

            for (int y = 1; y < int.Parse (loadedSettings[2]); y++) {
                Instantiate (tilePrefab, new Vector3 (x * 5f, 0, y * 5f), Quaternion.identity);
            }

        }

        tiles = GameObject.FindGameObjectsWithTag ("tile");
        startTile = tiles[Random.Range (0, tiles.Length)];
        startTile.GetComponent<tile> ().BuildStep ();
    }

    public void MapCreatedCallback (GameObject exitTile) {
        print ("map created");
    }
}