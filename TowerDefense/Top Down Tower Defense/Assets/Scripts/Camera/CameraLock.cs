using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour {

    bool locked;

    // Use this for initialization
    void Start () {
        GetComponent<CameraFollow>().enabled = true;
        locked = true;
    }

    // Update is called once per frame
    void Update () {
        if ((Input.GetKeyDown(KeyCode.Mouse2)) & (locked == true)) {
            locked = false;
        }
        else if ((Input.GetKeyDown(KeyCode.Mouse2)) & (locked == false)) {
            locked = true;
        }

        if (locked == true) {
            GetComponent<CameraFollow>().enabled = true;
        }
        else if (locked == false) {
            GetComponent<CameraFollow>().enabled = false;
        }
    }

}
