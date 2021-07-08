using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{     

    [Header("Floats")]
        public float platformSpeed;     
        public float patrolTime; 

    [Header("Bools")]
        public bool xPatrol;
        public bool yPatrol;
        public bool zPatrol; 

    [Header("Refs")]        
        public Vector3 direction; 
        CharacterController myController; 
    
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        direction = Vector3.left; 
        StartCoroutine(xRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        myController.Move(direction * Time.deltaTime * platformSpeed);
    }

    IEnumerator xRoutine()   
    {
        while(xPatrol)
        {
            direction = Vector3.left;

            yield return new WaitForSeconds(patrolTime);

            direction = Vector3.forward;

            yield return new WaitForSeconds(patrolTime);  

            direction = Vector3.right;

            yield return new WaitForSeconds(patrolTime);

            direction = Vector3.back;

            yield return new WaitForSeconds(patrolTime);    
 

        }
        
    }


}
