using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

    GameObject player;

    public GameObject bullet;
    public GameObject megaBullet;

    public GameObject swordTip;
    Vector2 swordTipV;

    private Rigidbody2D rb;

    public float swordSpeed;
    public float swordDamage;

    [HideInInspector]
    public float projectileDamage = 10;

    public float largeShootCdStart = 3.5f;
    public float largeShootCd;

    public float manyShootCdStart = 2;
    public float manyShootCd;

    public float ultimateTimerStart = 10;
    public float ultimateTimer = 0;

    public float ultimateChargeMax = 100;
    public float ultimateCharge;

    public AudioClip collisionClip;

    private Camera cam;

    // Start is called before the first frame update
    void Start () {
        ultimateCharge = 0;
        InvokeRepeating("Charge", 0, .1f);

        player = GameObject.Find("Player 1");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        manyShootCd -= Time.deltaTime;
        largeShootCd -= Time.deltaTime;
        ultimateTimer -= Time.deltaTime;

        cam = Camera.main;
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;

        Vector3 playerPos = player.transform.position;

        Vector2 swordVelocity = (mouse - playerPos).normalized * swordSpeed;
        rb.AddForce(swordVelocity);

        swordTipV = swordTip.transform.position;

        if ((Input.GetKeyDown(KeyCode.Mouse1)) & (manyShootCd <= 0)) {
            StartCoroutine(ManyShoot(5));
            manyShootCd = manyShootCdStart;
        }
        if ((Input.GetKeyDown(KeyCode.E)) & (largeShootCd <= 0)) {
            LargeShoot(swordTipV);
            largeShootCd = largeShootCdStart;
        }
        if ((Input.GetKeyDown(KeyCode.R)) & (ultimateCharge >= ultimateChargeMax)) {
            Ultimate();
            ultimateCharge = 0;
        }

        if (ultimateTimer <= 0) {
            player.transform.localScale = new Vector2(1, 1);
            transform.localScale = new Vector2(1, 1);
            GameObject.Find("P1UI").transform.localScale = new Vector2(1, 1);
            player.GetComponent<PlayerScript>().speed = 16;
            swordDamage = 45;
        } else if (ultimateTimer > 0) {
            player.transform.localScale = new Vector2(2, 2);
            transform.localScale = new Vector2(2, 2);
            GameObject.Find("P1UI").transform.localScale = new Vector2(2, 2);
            player.GetComponent<PlayerScript>().speed = 27.5f;
            swordDamage = 100;
        }
    }


    IEnumerator ManyShoot (int number) {
        int i = 0;
        while (i < number) {
            Vector2 swordTipV2 = swordTip.transform.position;
            GameObject newBullet = Instantiate(bullet, swordTipV2, Quaternion.identity);
            newBullet.transform.SetParent(gameObject.transform, true);
            i++;
            yield return new WaitForSeconds(.06f);
        }
    }


    void LargeShoot (Vector2 swordTip) {
        GameObject newBullet = Instantiate(megaBullet, swordTipV, Quaternion.identity);
        newBullet.transform.SetParent(gameObject.transform, true);
    }

    
    void Ultimate () {
        ultimateTimer = ultimateTimerStart;
    }


    void Charge () {
        ultimateCharge += .1f;
    }


    void OnCollisionEnter2D(Collision2D collision) {
        GameObject.Find("GameSoundController").GetComponent<AudioSource>().PlayOneShot(collisionClip, .15f);

        if (collision.gameObject.tag == "MeleeEnemy") {
            collision.gameObject.GetComponent<MeleeEnemyScript>().health -= swordDamage;
        } else if (collision.gameObject.tag == "SuicideEnemy") {
            collision.gameObject.GetComponent<SuicideEnemyScript>().health -= swordDamage;
        } else if (collision.gameObject.tag == "RangedEnemy") {
            collision.gameObject.GetComponent<RangedEnemyScript>().health -= swordDamage;
        }
    }
}
