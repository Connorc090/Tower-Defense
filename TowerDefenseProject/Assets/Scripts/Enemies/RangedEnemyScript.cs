using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedEnemyScript : MonoBehaviour {

    public GameObject missile;

    private Vector2 player;
    private GameObject playerGO;

    private Vector2 origin;

    [HideInInspector]
    public Vector2 target;

    public float maxHealth;
    public float health;
    public float speed;

    public float collisionDamage;

    public float shootTimeStart;
    public float shootTime;

    public AudioClip minecraft;
    public AudioClip death;

    Image healthBar;

    // Use this for initialization
    void Start () {
        origin = new Vector2(0, 0);

        playerGO = GameObject.Find("Player 1");

        GameObject healthBarFill = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        healthBar = healthBarFill.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Player 1")) {
            player = playerGO.transform.position;
        }

        shootTime -= Time.deltaTime;

        if (gameObject.name.StartsWith("RangedEnemy")) {
            if ((Vector2.Distance(transform.position, player) > 45) & (Vector2.Distance(transform.position, origin) > 55)) {
                transform.position = Vector2.MoveTowards(transform.position, origin, speed * Time.deltaTime);
            } else if ((Vector2.Distance(transform.position, player) <= 45) & (shootTime <= 0)) {
                Shoot(player);
                shootTime = shootTimeStart;
            } else if ((Vector2.Distance(transform.position, origin) <= 55) & (shootTime <= 0)) {
                Shoot(origin);
                shootTime = shootTimeStart;
            }
        } else if (gameObject.name.StartsWith("RangedBoss")) {
            if ((Vector2.Distance(transform.position, player) > 80) & (Vector2.Distance(transform.position, origin) > 90)) {
                transform.position = Vector2.MoveTowards(transform.position, origin, speed * Time.deltaTime);
            } else if ((Vector2.Distance(transform.position, player) <= 80) & (shootTime <= 0)) {
                Shoot(player);
                shootTime = shootTimeStart;
            } else if ((Vector2.Distance(transform.position, origin) <= 90) & (shootTime <= 0)){
                Shoot(origin);
                shootTime = shootTimeStart;
            }
        }

        healthBar.fillAmount = health / maxHealth;

        if (health <= 0) {
            Destroy(gameObject);
            GameObject.Find("Player 1").GetComponent<PlayerScript>().gold += 5;
            GameObject.Find("GameSoundController").GetComponent<AudioSource>().PlayOneShot(death, .5f);

            if (GameObject.Find("Player 1").tag == "RangedPlayer") {
                GameObject.Find("Player 1").GetComponent<PlayerCombat>().rapidShootCharge += 5;
            } else if (GameObject.Find("Player 1").tag == "MeleePlayer") {
                GameObject.Find("Sword").GetComponent<SwordScript>().ultimateCharge += 5;
            }
        }
    }


    void Shoot (Vector2 theTarget) {
        GameObject newMissile = Instantiate(missile, transform.position, Quaternion.identity);
        newMissile.transform.SetParent(gameObject.transform, true);
        target = theTarget;
    }


    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player 1") {
            Destroy(gameObject);
            GameObject.Find("Player 1").GetComponent<PlayerScript>().health -= collisionDamage;
            GameObject.Find("GameSoundController").GetComponent<AudioSource>().PlayOneShot(minecraft, .6f);
        }  
    }
}

