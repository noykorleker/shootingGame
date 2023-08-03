using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMotion : MonoBehaviour
{
    private Animator anim;
    private AudioSource doorSound;
    public GameObject door;
    private BoxCollider bc;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
        bc = door.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "ignore")
        {
            counter++;
            bc.isTrigger = true;
            anim.SetBool("isOpen", true);
            doorSound.PlayDelayed(0.2f);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "ignore")
        {
            counter--;
            if (counter == 0)
            {
                anim.SetBool("isOpen", false);
                doorSound.PlayDelayed(1f);
                bc.isTrigger = false;
            }
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
