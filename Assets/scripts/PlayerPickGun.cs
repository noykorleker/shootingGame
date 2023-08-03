using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickGun : MonoBehaviour
{
    public GameObject gun;
    
    private bool touching;
    // Start is called before the first frame update
    private void Start()
    {
        //touching = false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        touching = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //        touching = false;
    //}
    private void OnMouseDown()
    {
        if(gun.gameObject.activeSelf == false )
        {
            gun.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
