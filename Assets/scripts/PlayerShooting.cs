using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerShooting : MonoBehaviour
{
    public GameObject gun;
    public GameObject aCamera;
    public GameObject target;
    private LineRenderer lr;
    public GameObject MuzzleEnd;
    public List<GameObject> spwan;
    List<GameObject> bullets = new List<GameObject>();
    private bool isShot = false;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && gun.activeSelf)
        {
            if (!isShot)
            {
                ShootBullet();
            }
        }
        //if (Input.GetKey("space") && gun.activeSelf)
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        //    {
        //        target.transform.position = hit.point;
        //        StartCoroutine(ShowLine());
        //        if (hit.transform.gameObject.name == "Sara" || hit.transform.gameObject.name == "James")
        //        {
        //            GameObject enemy = hit.transform.gameObject;
        //            Animator a = enemy.GetComponent<Animator>();
        //            a.SetInteger("state", 1);
        //            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        //            agent.enabled = false;                    
        //        }
        //    }
        //}
    }

    void ShootBullet()
    {
        isShot = true;
        bullets.Clear();
        for (int i = 0; i < spwan.Count; i++)
        {
            if (spwan[i])
            {
                GameObject proj = Instantiate(target, spwan[i].transform.position, Quaternion.Euler(spwan[i].transform.forward)) as GameObject;
                //proj.SetActive(true);
                Rigidbody rb1 = proj.GetComponent<Rigidbody>();
                Vector3 direction = this.transform.forward * 10;
                rb1.AddForce(direction, ForceMode.Impulse);
                bullets.Add(proj);
                StartCoroutine(Waiting());                
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(0.5f);
        isShot = false;
    }
        
    IEnumerator ShowLine()
    {
        lr.SetPosition(0, MuzzleEnd.transform.position);
        lr.SetPosition(1, target.transform.position);
        lr.enabled = true;
        target.SetActive(true);
        //sound.Play();
        //muzzleFlash.Play();
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
        target.SetActive(false);
    }

}

