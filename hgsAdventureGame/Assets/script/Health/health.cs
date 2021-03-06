using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
	[Header("Bools")]
	public bool isPlayer;
	public bool isEnemy; 
	public bool isObstacle;


	[Header("Int")]
	public int  currentHealth;
	public int maxHealth; 

	[Header("Refs")]
	GameManager gameManager;
	HealthManagr healthManagr;
    public Level_Loader levelLoader; 



    // Start is called before the first frame update
    void Start()
    {
    	if(isPlayer)
    	{
    		gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    		healthManagr = gameManager.healthManagr;
    		healthManagr.healthText.text = "" + maxHealth; 
    	}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void TakeDamage(int damage)
    {
    	print ("take damage");
    	currentHealth = Mathf.Max(0, currentHealth - damage); 

    	if(isPlayer)
    	{
    		healthManagr.healthText.text = "" + currentHealth;
            if(currentHealth<=0)
            {
                levelLoader.LoadLevel();
            }
    	}
    	else
    	{
    		if(currentHealth<=0)
    		{
    			 Destroy(gameObject);
    		}
    	}
    }
}
