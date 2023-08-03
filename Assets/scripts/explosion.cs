using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class explosion : MonoBehaviour
{
    public GameObject anim;
    public GameObject part1;
    public GameObject part2;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject MainCamera;
    public GameObject AltCamera;
    public Text text;
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);
        part1.SetActive(false);
        part2.SetActive(false);
        anim.SetActive(true);
        Collider[] objectsCollider = Physics.OverlapSphere(transform.position, 5);
        for(int i =0; i< objectsCollider.Length; i++)
        {
            if(objectsCollider[i] != null && (objectsCollider[i].gameObject.name == enemy1.gameObject.name || objectsCollider[i].gameObject.name == enemy2.gameObject.name))
            {
                if (objectsCollider[i].gameObject.name != "Player")
                {
                    Animator a = objectsCollider[i].gameObject.GetComponent<Animator>();
                    a.SetInteger("state", 1);
                    NavMeshAgent agent = objectsCollider[i].gameObject.GetComponent<NavMeshAgent>();
                    agent.enabled = false;
                    Rigidbody rb = objectsCollider[i].gameObject.GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    text.GetComponent<Text>().text = text.GetComponent<Text>().text + objectsCollider[i].gameObject.name + " has died \n";
                }
                else
                {
                    if (objectsCollider[i].gameObject.GetComponent<PlayerMovement>().enabled)
                    {
                        text.GetComponent<Text>().text = text.GetComponent<Text>().text + objectsCollider[i].gameObject.name + " has died \n";
                        CharacterController cc = objectsCollider[i].gameObject.GetComponent<CharacterController>();
                        cc.enabled = false;
                        objectsCollider[i].gameObject.GetComponent<PlayerMovement>().enabled = false;
                        objectsCollider[i].gameObject.GetComponent<PlayerShooting>().enabled = false;
                        objectsCollider[i].gameObject.GetComponentInChildren<ThrowGranade>().enabled = false;
                        MainCamera.SetActive(false);
                        AltCamera.SetActive(true);

                    }                    
                    //granade.GetComponent<ThrowGranade>().enabled = false; 
                }
                BoxCollider bc = objectsCollider[i].gameObject.GetComponent<BoxCollider>();
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
        }

    }
}
