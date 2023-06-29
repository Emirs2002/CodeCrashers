using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public Animator anim;
    public float distanceToOpen;
    public PlayerController player;

    private bool playerExiting;

    public Transform exitPoint;
    public float moveplayerSpeed;
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {

        player = PlayerHealthController.instance.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < distanceToOpen){
            anim.SetBool("Open", true);
        }else{

            anim.SetBool("Open", false);
        }

        if(playerExiting){
            player.transform.position = Vector3.MoveTowards(player.transform.position, exitPoint.position, moveplayerSpeed*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(!playerExiting){
                player.canMove = false;
                StartCoroutine(UseDoorCo());
            }
        }
    }

    IEnumerator UseDoorCo(){
        playerExiting = true;

        player.anim.enabled = false;

        UIController.instance.StartFadeToBlack();

        yield return new WaitForSeconds(1.5f);
        RespawnController.instance.SetSpawn(exitPoint.position);
        player.canMove = true;
        player.anim.enabled = true;

        UIController.instance.StartFadeFromBlack();

        PlayerPrefs.SetString("ContinueLevel", levelToLoad);
        PlayerPrefs.SetFloat("PosX", exitPoint.position.x);
        PlayerPrefs.SetFloat("PosY", exitPoint.position.y);
        PlayerPrefs.SetFloat("PosZ", exitPoint.position.z);

        SceneManager.LoadScene(levelToLoad);
    }
}
