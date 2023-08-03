using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerCamera;
    private CharacterController controller;
    private float speed = 15f;
    private float rx = 0, ry;
    private float angularSpeed = 180;
    private AudioSource footStepSound;
    //public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // get player controller
       // footStepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float dx = 0, dz = 0;

        rx -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;

        if (rx < 90 && rx > -90)
        {
            playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);
        }

        transform.localEulerAngles = new Vector3(0, ry, 0);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            //NavMeshAgent nma = enemy.GetComponent<NavMeshAgent>();
            //Animator an = enemy.GetComponent<Animator>();
            //if (!nma.enabled && an.GetInteger("NPCState") != 2)
            //{
            //    nma.enabled = true;
            //    an.SetInteger("NPCState", 1);
            //}

        }

        Vector3 motion = new Vector3(dx, -1, dz);

        motion = transform.TransformDirection(motion); // 
        controller.Move(motion);

        //transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z + speed), transform.rotation);
        //if (!footStepSound.isPlaying && controller.velocity.magnitude > 0.1f)
        //{
        //    footStepSound.Play();
        //}

    }
}
