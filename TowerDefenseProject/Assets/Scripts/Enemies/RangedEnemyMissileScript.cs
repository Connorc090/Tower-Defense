using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyMissileScript : MonoBehaviour {

    Vector2 target;

    private Rigidbody2D rb;

    public float damage;
    public float missileSpeed;

    float destroyTime = 3;

    public AudioClip minecraft;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        Vector2 transform = GetComponentInParent<Rigidbody2D>().transform.position; 

        target = GetComponentInParent<RangedEnemyScript>().target;
        Vector2 moveVelocity = (target-transform).normalized * missileSpeed;
        rb.AddForce(moveVelocity);
	}
	
	// Update is called once per frame
	void Update () {
        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0) {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "MeleePlayer" || collision.tag == "RangedPlayer") {
            Destroy(gameObject);
            GameObject.Find("Player 1").GetComponent<PlayerScript>().health -= damage;
            GameObject.Find("GameSoundController").GetComponent<AudioSource>().PlayOneShot(minecraft, .6f);
        } else if (collision.tag == "Base") {
            Destroy(gameObject);
            GameObject.Find("Base").GetComponent<BaseScript>().health -= damage;
        }
    }
}

