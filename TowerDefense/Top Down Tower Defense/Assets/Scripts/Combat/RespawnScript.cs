using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnScript : MonoBehaviour {

    GameObject player;
    Text respawnText;

    public int respawnCd;
    float respawnCdFloat;

    bool playerFound = false;

	// Use this for initialization
	void Start () {
        respawnCd = -1;
        respawnCdFloat = -1;

        respawnText = GameObject.Find("RespawnText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((GameObject.Find("Player 1")) & (playerFound == false)) {
            FindPlayer ();
            playerFound = true;
        }

        respawnCdFloat -= Time.deltaTime;
        respawnCd = Mathf.RoundToInt(respawnCdFloat);

        if (player.GetComponent<PlayerScript>().health <= 0) {
            player.SetActive(false);
            player.GetComponent<PlayerScript>().health = 100;
            respawnCdFloat = 10 - Time.deltaTime;
        }
      
        if (respawnCd == 0) {
            player.GetComponent<Rigidbody2D>().transform.position = new Vector2(0, -30);
            player.SetActive(true);
            respawnCdFloat = -1;
            respawnText.text = "";
        }

        if (respawnCd > 0) {
            respawnText.text = respawnCd.ToString();
        } 
	}


    void FindPlayer () {
        player = GameObject.Find("Player 1");
    }
}
