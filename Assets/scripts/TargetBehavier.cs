using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavier : MonoBehaviour
{
    private int[] height = new int[2]; 

    public GameObject owner1;
    public GameObject owner2;
    // Start is called before the first frame update
    void Start()
    {
        height[0] = 4;
        height[1] = 14;

        float x, y, z;
        x = Random.Range(-17, 34);
        z = Random.Range(-31, 17);
        if (z < -7 && x > 10)
        {
            y = height[0];
        }
        else
        {
            y = height[Random.Range(0, 2)];
        }
        this.transform.position = new Vector3(x, y, z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == owner1.gameObject.name || other.gameObject.name == owner2.gameObject.name)
        {
            float x, y, z;
            x = Random.Range(-17, 34);
            z = Random.Range(-31, 17);
            if(z < -7 && x > 10)
            {
                y = height[0];
            }
            else
            {
                y = height[Random.Range(0, 2)];
            }            
            this.transform.position = new Vector3(x, y, z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
