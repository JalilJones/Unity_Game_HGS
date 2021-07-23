using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	public Vector3 location; 

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        location = transform.position; 
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            gameManager.checkPoint = this;
        }
    }

    
}
