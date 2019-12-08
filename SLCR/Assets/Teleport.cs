﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Stop("battle1");
            FindObjectOfType<AudioManager>().Play("port");
            Invoke("playAudio", .5f);
            other.transform.position = Destination.transform.position;
            other.transform.rotation = Destination.transform.rotation;
        }
    }
    public void playAudio()
    {

        FindObjectOfType<AudioManager>().Play("safe");
    }
}
