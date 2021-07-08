using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{

	[Header("Bools")]
	public bool hitsPlayer;
	public bool hitsEnemy;
	public bool hitsObstacle;



	[Header("Int")]

	public int damageAmount; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void DealDamage(health Health)

   {

   	Health.TakeDamage(damageAmount); 

   }

   private void OnTriggerEnter(Collider other)

   {
   	if(other.gameObject.layer == 6)
   	{
   		bool canDealDamage = false; 
   		health Health = other.GetComponent<health>();
   		if(	(hitsPlayer && Health.isPlayer) ||
   			(hitsEnemy && Health.isEnemy) ||
   			(hitsEnemy && Health.isObstacle))
   		{
   			canDealDamage = true; 
   		}

   		if(canDealDamage)
   		{
   			DealDamage(Health);
   		}
   	}
   }
}
