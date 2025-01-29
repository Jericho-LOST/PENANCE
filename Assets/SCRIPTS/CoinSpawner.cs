using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    //referance to coin prefab
    public GameObject coin;

    //define the offsset or range where the coin should spawn on the platform 
    public Vector2 coinOfset = new Vector2(0, 1);//ast as nessicary 



    void Start()
    {
        //Spawn the coin on the platform at the desired position 
        SpawnCoin();

        
    }

    // Update is called once per frame
    void SpawnCoin()
    {
        //calculate the coin position relative to the platform 
        Vector3 coinPosition = coin.transform.position = (Vector3)coinOfset;

        //Instantiate the coin at the calculated position 
        Instantiate(coin, coinPosition, Quaternion.identity);
    }
}
