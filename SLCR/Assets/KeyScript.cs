using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject Player;
    public bool isGoldKey;
    public bool isBlackKey;
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
        if(other.gameObject.tag == "Player" && isGoldKey)
        {
            Player.GetComponent<Inventory>().GoldKey = true;
            FindObjectOfType<AudioManager>().Play("got_key");

            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player" && isBlackKey)
        {
            Player.GetComponent<Inventory>().BlackKey = true;
            FindObjectOfType<AudioManager>().Play("got_key");
            Destroy(gameObject);
        }
    }
}
