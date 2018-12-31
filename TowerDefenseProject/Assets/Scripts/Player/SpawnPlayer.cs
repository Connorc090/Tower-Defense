using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

    public GameObject rangedCharacter;
    public GameObject meleeCharacter;
    public GameObject mageCharacter;

    [HideInInspector]
    public int charVal;

    bool spawned = false;

    Vector2 spawnPos;

    // Start is called before the first frame update
    void Start () {
        spawnPos = new Vector2(0, -30);
 
        charVal = GameObject.Find("MenuController").GetComponent<MenuController>().charControlVal;
    }

    // Update is called once per frame
    void Update () {
        if ((charVal == 1) & (spawned == false)) {
            GameObject player = Instantiate(rangedCharacter, spawnPos, Quaternion.identity);
            player.name = "Player 1";
            spawned = true;
        } else if ((charVal == 2) & (spawned == false)) {
            GameObject player = Instantiate(meleeCharacter, spawnPos, Quaternion.identity);
            player.name = "Player 1";
            spawned = true;
        } else if ((charVal == 3) & (spawned == false)) {
            GameObject player = Instantiate(mageCharacter, spawnPos, Quaternion.identity);
            player.name = "Player 1";
            spawned = true;
        }
    }
}
