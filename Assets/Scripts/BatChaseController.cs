using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatChaseController : MonoBehaviour
{
    public Batnary[] batArray;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            foreach(Batnary bat in batArray)
            {
                bat.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            foreach(Batnary bat in batArray)
            {
                bat.chase = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
