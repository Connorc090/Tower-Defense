using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour {

    [HideInInspector]
    public float health;
    public float maxHealth = 500;

    Image healthBar;
    Text healthBarText;

	// Use this for initialization
	void Start () {
        health = 500;
        healthBar = GameObject.Find("BaseHpFill").GetComponent<Image>();
        healthBarText = GameObject.Find("BaseHpText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = health / maxHealth;
        healthBarText.text = health + "/" + maxHealth;

        if (health <= 0) {
            SceneManager.LoadScene("Game");
        }

        if (health > maxHealth) {
            health = maxHealth;
        }
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player 1") {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        }
    }
}
