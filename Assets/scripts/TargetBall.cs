using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
       
            other.gameObject.GetComponent<NPCMotion>().changeTarget();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
