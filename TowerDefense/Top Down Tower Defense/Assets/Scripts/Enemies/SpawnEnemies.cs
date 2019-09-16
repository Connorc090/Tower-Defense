using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour {

    public GameObject meleeEnemy;
    public GameObject rangedEnemy;
    public GameObject suicideEnemy;
    public GameObject meleeBoss;
    public GameObject rangedBoss;
    public GameObject suicideBoss;

    Text eventText;
    Text respawnText;
    Text eventText2;

    public float meleeSpawnTimeStart;
    public float meleeSpawnTime;

    public float rangedSpawnTimeStart;
    public float rangedSpawnTime;

    public float suicideSpawnTimeStart;
    public float suicideSpawnTime;

    float waveTimeFloat;
    public float waveTime;

    int waveNumber = 1;

    int i = 0;
    int j = 0;
    int k = 0;

	   
    // Use this for initialization
	void Start () {
        eventText = GameObject.Find("EventText").GetComponent<Text>();
        eventText2 = GameObject.Find("EventText2").GetComponent<Text>();
        respawnText = GameObject.Find("RespawnText").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update () {
        waveTimeFloat += Time.deltaTime;
        waveTime = Mathf.RoundToInt(waveTimeFloat);


        meleeSpawnTime -= Time.deltaTime;
        rangedSpawnTime -= Time.deltaTime;
        suicideSpawnTime -= Time.deltaTime;

        if ((waveTime >= 5) & (waveTime <= 50)) {
            Invoke("Wave" + waveNumber, 0);
        } else if (waveTime >= 51) {
            CancelInvoke("Wave" + waveNumber);
            DestroyEnemies ();
            eventText.fontSize = 60;
            eventText2.text = "Press C to enter the shop";
            if ((waveTime % 2 == 0) & (respawnText.text == "")) {
                eventText.text = "Press Enter To Begin Wave " + (waveNumber + 1);
                eventText2.text = "Press C to enter the shop";
            } else {
                eventText.text = "";
            }
            if (waveNumber == 10 || waveNumber == 20 || waveNumber == 30) {
                GameObject.Find("Player 1").GetComponent<PlayerScript>().health = GameObject.Find("Player 1").GetComponent<PlayerScript>().maxHealth;
                GameObject.Find("Base").GetComponent<BaseScript>().health = GameObject.Find("Base").GetComponent<BaseScript>().maxHealth;
            }
        } else {
            eventText.text = "";
            eventText2.text = "";
            eventText.fontSize = 100;
        }
        if ((waveTime >= 51) & (Input.GetKeyDown(KeyCode.Return))) {
            waveTimeFloat = 0 + Time.deltaTime;
            waveNumber++;
        }
    }


    void Wave1 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 1";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 7;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave2 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 2";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 6;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave3 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 3";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 4;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave4 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 4";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 7;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 9;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave5 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 5";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 7;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave6 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 6";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 5;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave7 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 7";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 8;
        rangedSpawnTimeStart = 8;
        suicideSpawnTimeStart = 9;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave8 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 8";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 7;
        rangedSpawnTimeStart = 8;
        suicideSpawnTimeStart = 7;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave9 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 9";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 7;
        suicideSpawnTimeStart = 6;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave10 () {
        if (waveTime <= 8) {
            eventText.text = "Boss Wave";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (i < 3) {
            if (z == 1) {
                Instantiate(rangedBoss, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedBoss, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedBoss, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedBoss, new Vector2(150, posY), Quaternion.identity);
            }
            i++;
        }
    }

    void Wave11 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 11";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 6;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave12 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 12";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave13 () {
        if (waveTime <= 8){
            eventText.text = "Wave 13";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 3.5f;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave14 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 14";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 6;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 8;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave15 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 15";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 4;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 6;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave16 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 16";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 4;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 5;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave17 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 17";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 6;
        rangedSpawnTimeStart = 6;
        suicideSpawnTimeStart = 8;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave18 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 18";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 7;
        suicideSpawnTimeStart = 7;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4){
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave19 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 19";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 6;
        suicideSpawnTimeStart = 6;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave20 () {
        if (waveTime <= 8) {
            eventText.text = "Boss Wave";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (j < 4) {
            if (z == 1) {
                Instantiate(suicideBoss, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideBoss, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideBoss, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideBoss, new Vector2(150, posY), Quaternion.identity);
            }
            j++;
        }
    }

    void Wave21 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 21";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5.5f;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave22 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 22";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave23 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 23";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 3.5f;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 1000;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }
    }

    void Wave24 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 24";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 6;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 6.5f;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave25 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 25";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 4;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 5.5f;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave26 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 26";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 4;
        rangedSpawnTimeStart = 1000;
        suicideSpawnTimeStart = 5;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave27 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 27";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 6;
        rangedSpawnTimeStart = 6;
        suicideSpawnTimeStart = 8;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave28 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 28";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 6;
        suicideSpawnTimeStart = 6;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave29 () {
        if (waveTime <= 8) {
            eventText.text = "Wave 29";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        meleeSpawnTimeStart = 5;
        rangedSpawnTimeStart = 5;
        suicideSpawnTimeStart = 6;

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (meleeSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(meleeEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(meleeEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(meleeEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(meleeEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            meleeSpawnTime = meleeSpawnTimeStart;
        }

        if (rangedSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(rangedEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            rangedSpawnTime = rangedSpawnTimeStart;
        }

        if (suicideSpawnTime <= 0) {
            if (z == 1) {
                Instantiate(suicideEnemy, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(suicideEnemy, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(suicideEnemy, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) { 
                Instantiate(suicideEnemy, new Vector2(150, posY), Quaternion.identity);
            }
            suicideSpawnTime = suicideSpawnTimeStart;
        }
    }

    void Wave30 () {
        if (waveTime <= 8) {
            eventText.text = "Boss Wave";
        } else if (waveTime > 8) {
            eventText.text = "";
        }

        int posX = Random.Range(-150, 150);
        int posY = Random.Range(-100, 100);
        int z = Random.Range(1, 4);

        if (k < 4) {
            if (z == 1) {
                Instantiate(rangedBoss, new Vector2(posX, -100), Quaternion.identity);
            } else if (z == 2) {
                Instantiate(rangedBoss, new Vector2(posX, 100), Quaternion.identity);
            } else if (z == 3) {
                Instantiate(rangedBoss, new Vector2(-150, posY), Quaternion.identity);
            } else if (z == 4) {
                Instantiate(rangedBoss, new Vector2(150, posY), Quaternion.identity);
            }
            k++;
        }
    }


    void DestroyEnemies() {
        string[] enemyTags = {
            "MeleeEnemy",
            "SuicideEnemy",
            "RangedEnemy",
        };

        foreach (string tag in enemyTags) { 
        GameObject[] enemies = (GameObject.FindGameObjectsWithTag(tag));
            for (int i = 0; i < enemies.Length; i++) {
                Destroy(enemies[i]);
            }
        }
    }
}