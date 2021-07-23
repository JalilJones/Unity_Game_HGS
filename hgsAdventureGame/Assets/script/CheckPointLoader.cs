using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointLoader : MonoBehaviour
{

	GameManager gameManager;
	public GameObject playerObject;
	public playr player; 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<playr>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        	player.myController.enabled = false; 
        	playerObject.transform.position = gameManager.checkPoint.location;
        	player.myController.enabled = true;  
        }
    }

    
}
