using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    [HideInInspector]
    public float damage;

    float destroyTime = 3;

    public float bulletSpeed;
    private Rigidbody2D rb;
    Vector2 moveVelocity;

    private Camera cam;

    public AudioClip collisionClip;

	// Use this for initialization
	void Start () {
        Vector3 player = GameObject.Find("Player 1").GetComponent<Rigidbody2D>().transform.position;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);        
        mouse.z = 0;
        if (GameObject.Find("Player 1").tag == "RangedPlayer") {
            moveVelocity = (mouse - player).normalized * bulletSpeed;
        } else if (GameObject.Find("Player 1").tag == "MeleePlayer") {
            Vector3 swordTip = GameObject.Find("SwordTip").transform.position;
            moveVelocity = (mouse - swordTip).normalized * bulletSpeed;
        }
        rb.AddForce(moveVelocity);
	}
	
	// Update is called once per frame
	void Update () { 
        if (GameObject.Find("Player 1").tag == "RangedPlayer") {
            damage = GameObject.Find("Player 1").GetComponent<PlayerCombat>().damage;
        } else if (GameObject.Find("Player 1").tag == "MeleePlayer") {
            damage = GameObject.Find("Sword").GetComponent<SwordScript>().projectileDamage;
        }

        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0) {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D collision) {
        GameObject.Find("GameSoundController").GetComponent<AudioSource>().PlayOneShot(collisionClip, .15f);

        if (collision.tag == "MeleeEnemy") {
            Destroy(gameObject);
            collision.GetComponent<MeleeEnemyScript>().health -= damage;
        } else if (collision.tag == "SuicideEnemy") {
            Destroy(gameObject);
            collision.GetComponent<SuicideEnemyScript>().health -= damage;
        } else if (collision.tag == "RangedEnemy") {
            Destroy(gameObject);
            collision.GetComponent<RangedEnemyScript>().health -= damage;
        }

        if ((collision.tag == "MeleeEnemy") & (gameObject.tag == "MegaBullet")) {
            Destroy(gameObject);
            collision.GetComponent<MeleeEnemyScript>().health -= (damage * 2.5f);
        } else if ((collision.tag == "SuicideEnemy") & (gameObject.tag == "MegaBullet")) {
            Destroy(gameObject);
            collision.GetComponent<SuicideEnemyScript>().health -= (damage * 2.5f);
        } else if ((collision.tag == "RangedEnemy") & (gameObject.tag == "MegaBullet")) {
            Destroy(gameObject);
            collision.GetComponent<RangedEnemyScript>().health -= (damage * 2.5f);
        }
    }
}
