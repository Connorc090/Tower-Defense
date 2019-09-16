using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform target;

    bool playerFound = false;

    void Start () {
   
    }


    void Update () {
        if ((GameObject.Find("Player 1")) & (playerFound == false)) {
            FindPlayer ();
            playerFound = true;
        }
    }


    void LateUpdate () {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }


    void FindPlayer () {
        GameObject player = GameObject.Find("Player 1");
        target = player.GetComponent<Rigidbody2D>().transform;
    }
}
