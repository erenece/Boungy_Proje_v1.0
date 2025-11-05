using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    private PlayerController Player;
    public GameObject effect;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //baþka bir objedeki componente eriþmek için bu komutu kullanyoruz, tag den bir objeyi bulacak->"player" 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if(collision.gameObject.tag=="Player")

        {
            Player.coin++;
            
            Instantiate(effect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
