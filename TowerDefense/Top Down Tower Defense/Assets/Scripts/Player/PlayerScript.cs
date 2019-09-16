using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public float speed;
    public float health;
    public float maxHealth = 100;
    public int gold;

    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    private bool isDashing;

    // Ranged Player CDs
    float multiShootCdStart;
    float multiShootCd;

    float megaShootCdStart;
    float megaShootCd;

    float rapidShootChargeMax;
    float rapidShootCharge;


    // Melee Player CDs
    float manyShootCdStart;
    float manyShootCd;

    float largeShootCdStart;
    float largeShootCd;

    float ultimateChargeMax;
    float ultimateCharge;

    Image healthBar;
    Image uiHealthBar;
    Image ability1;
    Image ability2;
    Image ability3;
    Image ability4;

    Text uiHealthBarText;
    Text goldText;
    Text ability1Cd;
    Text ability2Cd;
    Text ability3Cd;

    Canvas uiCanvas;

    private Camera cam;
    private Camera mainCam;
    public Vector2 mouseVelocity;

    // Use this for initialization
    void Start () {
        gold = 0;

        uiCanvas = GameObject.Find("P1UI").GetComponent<Canvas>();
        mainCam = GameObject.Find("Game Camera").GetComponent<Camera>();
        uiCanvas.worldCamera = mainCam;

       
        healthBar = GameObject.Find("P1HpFill").GetComponent<Image>();
        uiHealthBar = GameObject.Find("P1UIHpFill").GetComponent<Image>();
        goldText = GameObject.Find("P1GoldText").GetComponent<Text>();
        ability1 = GameObject.Find("P1AbilityBackground 1").GetComponent<Image>();
        ability2 = GameObject.Find("P1AbilityBackground 2").GetComponent<Image>();
        ability3 = GameObject.Find("P1AbilityBackground 3").GetComponent<Image>();
        ability4 = GameObject.Find("P1AbilityFill 4").GetComponent<Image>();
        ability2Cd = GameObject.Find("P1AbilityCd 2").GetComponent<Text>();
        ability3Cd = GameObject.Find("P1AbilityCd 3").GetComponent<Text>();
        uiHealthBarText = GameObject.Find("P1UIHpText").GetComponent<Text>();
         

        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        ability1.fillAmount = 1 - (dashTime / startDashTime);
        if (gameObject.tag == "RangedPlayer") {
            multiShootCdStart = GetComponent<PlayerCombat>().multiShootCdStart;
            multiShootCd = GetComponent<PlayerCombat>().multiShootCd;

            megaShootCdStart = GetComponent<PlayerCombat>().megaShootCdStart;
            megaShootCd = GetComponent<PlayerCombat>().megaShootCd;

            rapidShootCharge = GetComponent<PlayerCombat>().rapidShootCharge;
            rapidShootChargeMax = GetComponent<PlayerCombat>().rapidShootChargeMax;

            ability2.fillAmount = multiShootCd / multiShootCdStart;
            ability3.fillAmount = megaShootCd / megaShootCdStart;
            ability4.fillAmount = rapidShootCharge / rapidShootChargeMax;

            if (multiShootCd > 0) {
                ability2Cd.text = multiShootCd.ToString();
            } else if (multiShootCd <= 0) {
                ability2Cd.text = "";
            } if (megaShootCd > 0) {
                ability3Cd.text = megaShootCd.ToString();
            } else if (megaShootCd <= 0) {
                ability3Cd.text = "";
            }
        } else if (gameObject.tag == "MeleePlayer") {
            GameObject sword = GameObject.Find("Sword");

            manyShootCdStart = sword.GetComponent<SwordScript>().manyShootCdStart;
            manyShootCd = sword.GetComponent<SwordScript>().manyShootCd;

            largeShootCdStart = sword.GetComponent<SwordScript>().largeShootCdStart;
            largeShootCd = sword.GetComponent<SwordScript>().largeShootCd;

            ultimateChargeMax = sword.GetComponent<SwordScript>().ultimateChargeMax;
            ultimateCharge = sword.GetComponent<SwordScript>().ultimateCharge;

            ability2.fillAmount = manyShootCd / manyShootCdStart;
            ability3.fillAmount = largeShootCd / largeShootCdStart;
            ability4.fillAmount = ultimateCharge / ultimateChargeMax;

            if (manyShootCd > 0) {
                ability2Cd.text = manyShootCd.ToString();
            } else if (manyShootCd <= 0) {
                ability2Cd.text = "";
            } if (largeShootCd > 0) {
                ability3Cd.text = largeShootCd.ToString();
            } else if (largeShootCd <= 0) {
                ability3Cd.text = "";
            }
        }

        uiHealthBar.fillAmount = health / maxHealth;
        healthBar.fillAmount = health / maxHealth;

        uiHealthBarText.text = health + "/" + maxHealth;

        goldText.text = gold + " Gold";

        if ((Input.GetKeyDown(KeyCode.Space)) & (dashTime == startDashTime)) {
            moveVelocity = moveInput.normalized * dashSpeed;
            isDashing = true;
        }

        if (isDashing == true) {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0) {
                isDashing = false;
                dashTime = startDashTime;
            }
        }

        if (health > maxHealth) {
            health = maxHealth;
        }
    }


    void FixedUpdate () {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
