using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
    ScoreTextScript.coffeeAmount += 1;
    Destroy(gameObject);
   }
}
