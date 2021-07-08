using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{	
	public PlatformPatrol platformPatrol; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            platformPatrol.movePlayer = true;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            platformPatrol.movePlayer = false;
        }
    }
}
