using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    public GameObject shop;

    GameObject player;
    GameObject theBase;

    Text goldText;
    Text playerHpText;
    Text baseHpText;

    int displayGold;

    bool playerFound = false;
    bool shopOpen = false;

    // Start is called before the first frame update
    void Start () {
        theBase = GameObject.Find("Base");

    }

    // Update is called once per frame
    void Update () {
        if ((GameObject.Find("Player 1")) & (playerFound == false)) {
            player = GameObject.Find("Player 1");
            displayGold = player.GetComponent<PlayerScript>().gold;
        }

        if (shop.activeSelf == true) {
            goldText = GameObject.Find("GoldText").GetComponent<Text>();
            playerHpText = GameObject.Find("PlayerHpShopText").GetComponent<Text>();
            baseHpText = GameObject.Find("BaseHpShopText").GetComponent<Text>();

            goldText.text = displayGold + " Gold";
            playerHpText.text = player.GetComponent<PlayerScript>().health.ToString() + "/" + player.GetComponent<PlayerScript>().maxHealth.ToString() + " Hp";
            baseHpText.text = theBase.GetComponent<BaseScript>().health.ToString() + "/" + theBase.GetComponent<BaseScript>().maxHealth.ToString() + " Hp";
        }

        if (shopOpen == true) {
            shop.SetActive(true);
        } else if (shopOpen == false) {
            shop.SetActive(false);
        }

        if ((Vector2.Distance(player.transform.position, new Vector2(0, 0)) <= 50) & (GameObject.Find("Game Camera").GetComponent<SpawnEnemies>().waveTime >= 51)) {
            if ((Input.GetKeyDown(KeyCode.C)) & (shopOpen == false)) {
                shopOpen = true;
            } else if ((Input.GetKeyDown(KeyCode.C)) & (shopOpen == true)) {
                shopOpen = false;
            }
        } else {
            shopOpen = false;
        }
    }


    public void Health (int cost) {
        if (((displayGold - cost) >= 0) & (player.GetComponent<PlayerScript>().health != player.GetComponent<PlayerScript>().maxHealth)) {
            player.GetComponent<PlayerScript>().health += 40;
            player.GetComponent<PlayerScript>().gold -= cost;
        }
    }

    public void MaxHealth (int cost) {
        if ((displayGold - cost) >= 0) {
            player.GetComponent<PlayerScript>().health += 10;
            player.GetComponent<PlayerScript>().maxHealth += 10;
            player.GetComponent<PlayerScript>().gold -= cost;
        }
    }

    public void BaseHealth (int cost) {
        if (((displayGold - cost) >= 0) & (theBase.GetComponent<BaseScript>().health != theBase.GetComponent<BaseScript>().maxHealth)) {
            theBase.GetComponent<BaseScript>().health += 150;
            player.GetComponent<PlayerScript>().gold -= cost;
        }
    }

    public void MaxBaseHealth (int cost) {
        if ((displayGold - cost) >= 0) {
            theBase.GetComponent<BaseScript>().health += 50;
            theBase.GetComponent<BaseScript>().maxHealth += 50;
            player.GetComponent<PlayerScript>().gold -= cost;
        }
    }

    public void Damage (int cost) {
        if ((displayGold - cost) >= 0) {
            player.GetComponent<PlayerCombat>().damage += (player.GetComponent<PlayerCombat>().damage * .15f);
            player.GetComponent<PlayerScript>().gold -= cost;
        }
    }


    void FindPlayer () {
        player = GameObject.Find("Player 1");
    }
}
