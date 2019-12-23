using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Destination;
    public bool isL1EscapePortal;
    public bool isL2EscapePortal;
    public bool isNormalPortal;
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
        if(other.gameObject.tag == "Player")
        {
            if(isL1EscapePortal && Player.GetComponent<PlayerController>().inventory.GoldKey)
            {
                FindObjectOfType<AudioManager>().Stop("battle1");
                FindObjectOfType<AudioManager>().Play("port");
                Invoke("playAudio", .5f);
                other.transform.position = Destination.transform.position;
                other.transform.rotation = Destination.transform.rotation;
            }
            else if(isL2EscapePortal && Player.GetComponent<PlayerController>().inventory.BlackKey)
            {
                FindObjectOfType<AudioManager>().Stop("battle2");
                FindObjectOfType<AudioManager>().Play("port");
                Invoke("playAudio", .5f);
                other.transform.position = Destination.transform.position;
                other.transform.rotation = Destination.transform.rotation;
                Player.GetComponent<PlayerController>().Victory = true;
            }
            else if(isNormalPortal)
            {
                other.transform.position = Destination.transform.position;
                other.transform.rotation = Destination.transform.rotation;
            }
        }        
    }
    public void playAudio()
    {

        FindObjectOfType<AudioManager>().Play("safe");
    }
}
