using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BulletBehavior : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject MainCamera;
    public GameObject AltCamera;
    public Text text;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {        
        if(collision.gameObject.name == enemy1.name || collision.gameObject.name == enemy2.name)
        {
            if(collision.gameObject.name != "Player")
            {
                Animator a = collision.gameObject.GetComponent<Animator>();
                a.SetInteger("state", 1);
                NavMeshAgent agent = collision.gameObject.GetComponent<NavMeshAgent>();
                agent.enabled = false;
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                text.GetComponent<Text>().text = text.GetComponent<Text>().text + collision.gameObject.name + " has died \n";
            }
            else
            {
                CharacterController cc = collision.gameObject.GetComponent<CharacterController>();
                cc.enabled = false;
                collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
                if(collision.gameObject.GetComponent<PlayerShooting>() != null)
                    collision.gameObject.GetComponent<PlayerShooting>().enabled = false;
                if(collision.gameObject.GetComponentInChildren<ThrowGranade>() != null)
                    collision.gameObject.GetComponentInChildren<ThrowGranade>().enabled = false;
                MainCamera.SetActive(false);
                AltCamera.SetActive(true);
                //granade.GetComponent<ThrowGranade>().enabled = false; 
                text.GetComponent<Text>().text = text.GetComponent<Text>().text + collision.gameObject.name + " has died \n";
            }                  
            BoxCollider bc = collision.gameObject.GetComponent<BoxCollider>();
            bc.enabled = false;
            BoxCollider bc1 = enemy1.gameObject.GetComponent<BoxCollider>();
            BoxCollider bc2 = enemy2.gameObject.GetComponent<BoxCollider>();
            if (!bc1.enabled && !bc2.enabled)
            {
                if (enemy1.gameObject.name == "Player")
                    gameOverText.GetComponent<Text>().text = "GAME OVER\nEnemy Win";
                else
                    gameOverText.GetComponent<Text>().text = "GAME OVER\nYou Win";
            }
        }
        
        Destroy(this.gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
