using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Level_Loader : MonoBehaviour
{
	public int levelToLoad; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel()
    {
    	SceneManager.LoadScene(levelToLoad);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
        	LoadLevel(); 

        }
    }
}
