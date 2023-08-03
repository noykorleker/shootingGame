using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGranade : MonoBehaviour
{
    public GameObject player;
    public GameObject part1;
    public GameObject part2;
    public GameObject granade;
    public List<GameObject> spwan;
    List<GameObject> nades = new List<GameObject>();
    private bool isThrown = false;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            if (!isThrown)
            {
                ThrowingGranade();                
            }            
        }
    }

    void ThrowingGranade()
    {
        isThrown = true;

        nades.Clear();
        for (int i = 0; i < spwan.Count; i++)
        {
            if (spwan[i])
            {
                GameObject proj = Instantiate(granade, spwan[i].transform.position, Quaternion.Euler(spwan[i].transform.forward)) as GameObject;
                proj.SetActive(true);
                Rigidbody rb1 = proj.GetComponent<Rigidbody>();
                rb1.useGravity = true;
                Vector3 direction = player.transform.forward * 10;
                direction.y = 3;
                rb1.AddForce(direction, ForceMode.Impulse);
                nades.Add(proj);                
                Destroy(proj, 5f);                
            }
        }
        StartCoroutine(Explode());
    }
    
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1f);
        isThrown = false;
    }
}
