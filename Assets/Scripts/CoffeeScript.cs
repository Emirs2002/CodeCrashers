using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeScript : MonoBehaviour
{
    public int stabilityAmount;

    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other) 
    {
    ScoreTextScript.coffeeAmount += 1;
    if(other.tag == "Player")
    {
        PlayerHealthController.instance.HandleStability(stabilityAmount);
        if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }
    }
    Destroy(gameObject);
    }

   
}
