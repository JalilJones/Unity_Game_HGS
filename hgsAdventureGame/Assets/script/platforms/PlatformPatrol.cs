using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{     

    [Header("Floats")]
        public float platformSpeed;     
        public float patrolTime; 


    [Header("Bools")]
        public bool xPatrol;
        public bool yPatrol;
        public bool zPatrol; 
        public bool movePlayer;     

    [Header("Refs")]            
        public Vector3 direction; 
        public CharacterController playerController; 
       
    
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(xRoutine());
        StartCoroutine(zRoutine());
        StartCoroutine(yRoutine());
        playerController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * platformSpeed);

        if (movePlayer)
        {
            playerController.Move(direction * Time.deltaTime * platformSpeed);

        }
    }

    IEnumerator xRoutine()   
    {
        while(xPatrol)
        {
            direction = Vector3.left;

            yield return new WaitForSeconds(patrolTime);

            direction = Vector3.right;

            yield return new WaitForSeconds(patrolTime);    

        }
        
    }

    IEnumerator zRoutine()   
    {
        while(zPatrol)
        {
            direction = Vector3.forward;

            yield return new WaitForSeconds(patrolTime);

            direction = Vector3.back;

            yield return new WaitForSeconds(patrolTime);    

        }
        
    }

     IEnumerator yRoutine()   
    {
        while(yPatrol)
        {
            direction = Vector3.up;

            yield return new WaitForSeconds(patrolTime);

            direction = Vector3.down;

            yield return new WaitForSeconds(patrolTime);    

        }
        
    }
}
