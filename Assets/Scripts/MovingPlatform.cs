using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform posA, posB;

    public float speed;
    Vector3 targetPos;

    // Start is called before the first frame update
    private void Start()
    {
        targetPos = posB.position;
    }

    // mover de punto A a punto B
    private void Update()
    {
        
       if(Vector2.Distance(transform.position, posA.position) < 0.05f){

        targetPos = posB.position;
       }

       if(Vector2.Distance(transform.position, posB.position) < 0.05f){

        targetPos = posA.position;
       }

        transform.position = Vector3.MoveTowards(transform.position, targetPos,speed*Time.deltaTime);

    }

    //para que el personaje se mueva con la plataforma

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            collision.gameObject.transform.parent.SetParent(transform, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
             collision.gameObject.transform.parent.SetParent(null);
        }
        
    }

   
}

