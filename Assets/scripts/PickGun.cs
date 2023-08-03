using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject gun;
    public GameObject granade;
    
    // Start is called before the first frame update
 
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "gun" && gun.gameObject.activeSelf == false)
        {
            gun.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "granade" && granade.gameObject.activeSelf == false)
        {
            granade.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }

   
}
