using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    public AudioClip minecraft;
    public AudioClip collisionClip;
    public AudioClip death;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

    }
}
