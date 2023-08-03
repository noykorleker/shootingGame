using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCMotion : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject point;
    public GameObject MuzzleEnd;
    public List<GameObject> spwan;
    public GameObject bullet;
    public GameObject granade;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject teamMate;
    public GameObject alternateTarget;
    private bool waiting = false;
    private RaycastHit hit;
    private List<GameObject> bullets = new List<GameObject>();
    List<GameObject> nades = new List<GameObject>();





    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // target = targets[Random.Range(0, 6)];
    }

    public void changeTarget()
    {
        // target = targets[Random.Range(0, 6)];
    }
    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position);
            BoxCollider TMBC = target.GetComponent<BoxCollider>();
            if (TMBC.enabled == false)
            {
                BoxCollider TMBC1 = teamMate.GetComponent<BoxCollider>();
                if (TMBC1.enabled == true && this.gameObject.name != "Sara")
                {
                    target = teamMate.gameObject;
                }
                else
                {
                    target = alternateTarget.gameObject;
                }
            }
            if (gun1.activeSelf == true || gun2.activeSelf == true)
            {
                if (gun1.activeSelf == true)
                {
                    Animator a = this.GetComponent<Animator>();
                    a.SetInteger("state", 2);
                }

                if (Physics.Raycast(point.transform.position, point.transform.right, out hit))
                {

                    if (hit.transform.gameObject.name == enemy1.gameObject.name || hit.transform.gameObject.name == enemy2.gameObject.name)
                    {
                        target = hit.transform.gameObject;

                        if (!waiting)
                        {
                            if (gun1.activeSelf && gun2.activeSelf)
                            {
                                int choice = Random.Range(0, 2);
                                if (choice == 0)
                                    StartCoroutine(GunShot());
                                else
                                    StartCoroutine(ThrowGranade());
                            }
                            else if (gun1.activeSelf)
                                StartCoroutine(GunShot());
                            else
                            {
                                StartCoroutine(ThrowGranade());

                            }

                        }
                    }
                }
            }
        }
        else
        {
            gun1.SetActive(false);
            gun2.SetActive(false);
        }
    }

    IEnumerator GunShot()
    {
        waiting = true;

        if (hit.collider != null && (hit.transform.gameObject.name == enemy1.gameObject.name || hit.transform.gameObject.name == enemy2.gameObject.name))
        {
            bullets.Clear();
            for (int i = 0; i < spwan.Count; i++)
            {
                if (spwan[i])
                {
                    GameObject proj = Instantiate(bullet, spwan[i].transform.position, Quaternion.Euler(spwan[i].transform.forward)) as GameObject;
                    Rigidbody rb1 = proj.GetComponent<Rigidbody>();
                    Vector3 direction = this.transform.forward * 10;
                    rb1.AddForce(direction, ForceMode.Impulse);
                    bullets.Add(proj);
                }
            }
            yield return new WaitForSeconds(1f);

        }
        waiting = false;
    }

    IEnumerator ThrowGranade()
    {
        waiting = true;
        if (hit.collider != null && (hit.transform.gameObject.name == enemy1.gameObject.name || hit.transform.gameObject.name == enemy2.gameObject.name))
        {
            nades.Clear();
            for (int i = 0; i < spwan.Count; i++)
            {
                if (spwan[i])
                {
                    GameObject proj = Instantiate(granade, spwan[i].transform.position, Quaternion.Euler(spwan[i].transform.forward)) as GameObject;
                    proj.SetActive(true);
                    Rigidbody rb1 = proj.GetComponent<Rigidbody>();
                    rb1.useGravity = true;
                    Vector3 direction = this.transform.forward * 10;
                    direction.y = 3;
                    rb1.AddForce(direction, ForceMode.Impulse);
                    nades.Add(proj);
                    Destroy(proj, 5f);
                }
            }
            yield return new WaitForSeconds(2f);
        }
        waiting = false;
    }
}
