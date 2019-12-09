using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Teleport : MonoBehaviour
{
    public Transform Level2_Destination;
    public GameObject Player;

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
        if(other.gameObject.tag == "Player" && Player.GetComponent<Inventory>().GoldKey)
        {
            FindObjectOfType<AudioManager>().Stop("safe");
            FindObjectOfType<AudioManager>().Play("port");
            Invoke("playAudio", .5f);
            other.transform.position = Level2_Destination.transform.position;
            other.transform.rotation = Level2_Destination.transform.rotation;
        }
    }
    public void playAudio()
    {
        FindObjectOfType<AudioManager>().Play("battle2");
    }
}
