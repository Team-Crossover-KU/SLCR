using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Teleport : MonoBehaviour
{
    public Transform Level1_Destination;


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
            
            FindObjectOfType<AudioManager>().Stop("start");
            FindObjectOfType<AudioManager>().Play("port");
            Invoke("playAudio", 2f);
            // System.Threading.Thread.Sleep(5000);
            //wait(5000);
            FindObjectOfType<AudioManager>().Play("battle1");
            other.transform.position = Level1_Destination.transform.position;
            other.transform.rotation = Level1_Destination.transform.rotation;
        }
    }

    public void playAudio()
    {
        //  System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        //  if (x == 0 || x < 0) return;
        //Console.WriteLine("start wait timer");
        //  timer1.Interval = x;
        //timer1.Enabled = true;
        //timer1.Start();
        FindObjectOfType<AudioManager>().Play("battle1");

    }
}
