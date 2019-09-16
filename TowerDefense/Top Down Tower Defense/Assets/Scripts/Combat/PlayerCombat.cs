using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public GameObject bullet;
    public GameObject megaBullet;
    public GameObject rfBullet;

    public float multiShootCdStart = 3;
    public float multiShootCd;

    public float megaShootCdStart = 6;
    public float megaShootCd;

    public float rapidShootChargeMax = 100;
    public float rapidShootCharge;
    
    [HideInInspector]
    public float damage = 10;

    // Use this for initialization
    void Start () {
        rapidShootCharge = 0;

        InvokeRepeating("Charge", 0, .1f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 player = new Vector2(transform.position.x, transform.position.y);



        multiShootCd -= Time.deltaTime;
        megaShootCd -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Shoot (player);
        }
        if ((Input.GetKeyDown(KeyCode.Mouse1)) & (multiShootCd <= 0)) {
            StartCoroutine (MultiShoot(8));
            multiShootCd = multiShootCdStart;
        }
        if ((Input.GetKeyDown(KeyCode.E)) & (megaShootCd <= 0)) {
            MegaShoot (player);
            megaShootCd = megaShootCdStart;
        }
        if ((Input.GetKeyDown(KeyCode.R)) & (rapidShootCharge >= rapidShootChargeMax)) {
            StartCoroutine (RapidShoot(1));
            rapidShootCharge = 0;
        }

        if (rapidShootCharge > rapidShootChargeMax) {
            rapidShootCharge = rapidShootChargeMax;
        }
    }

    void Shoot (Vector2 player) {
        GameObject newBullet = Instantiate(bullet, player, Quaternion.identity);
        newBullet.transform.SetParent(gameObject.transform, true);
    }

    void MegaShoot (Vector2 player) {
        GameObject newMegaBullet = Instantiate(megaBullet, player, Quaternion.identity);
        newMegaBullet.transform.SetParent(gameObject.transform, true);
    }

    IEnumerator MultiShoot (int number) {
        int i = 0;
        while (i < number) {
            Vector2 player = new Vector2(transform.position.x, transform.position.y);
            GameObject newBullet = Instantiate(bullet, player, Quaternion.identity);
            newBullet.transform.SetParent(gameObject.transform, true);
            i++;
            yield return new WaitForSeconds(.06f);
        }
    }

    IEnumerator RapidShoot (float rapidShootTime) {
        while (rapidShootTime > 0) {
            Vector2 player = new Vector2(transform.position.x, transform.position.y);
            rapidShootTime -= Time.deltaTime;
            GameObject newBullet = Instantiate(rfBullet, player, Quaternion.identity);
            newBullet.transform.SetParent(gameObject.transform, true);
            yield return new WaitForSeconds(.05f);
        }
    }


    void Charge () {
        rapidShootCharge += .1f;
    }
}
