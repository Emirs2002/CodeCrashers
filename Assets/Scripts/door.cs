using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{

    private Animator anim;

    private void Awake(){
        
        anim = GetComponent<Animator>();

    }

    public void Open(){

        anim.SetTrigger("Open");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
