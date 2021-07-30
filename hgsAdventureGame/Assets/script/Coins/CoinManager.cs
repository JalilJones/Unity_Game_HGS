using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CoinManager : MonoBehaviour
{
    public int coins; 
    public Text coinText; 
    public AudioManager audioManager; 
    // Start is called before the first frame update
    void Start()
    {
        coins = 0; 
        coinText.text = "" + coins; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainCoins(int amount)
    {
        coins += amount; 
        print(coins);
        coinText.text = "" + coins;
        audioManager.coinSound.PlayOneShot(audioManager.coinSound.clip);
         
    }
}
