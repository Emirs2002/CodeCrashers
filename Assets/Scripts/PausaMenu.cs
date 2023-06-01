using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public GameObject pausaMenu;
    public string NewGameScene;
    public static bool isPaused;
    private PlayerController thePlayer;
   
    // Start is called before the first frame update
    void Start()
    {
        pausaMenu.SetActive(false);
        thePlayer = PlayerHealthController.instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)){

            if (isPaused){
                Reanudar();
                
            }else{
                PausarJuego();
                 
            }
        }
    }

    private void PausarJuego()
    {
        Debug.Log("Pausando");
        pausaMenu.SetActive(true);
        Time.timeScale = 0f; 
        thePlayer.canShoot = false;  
        thePlayer.canMove = false;  
        isPaused = true;

    }

    public void Reanudar(){

        Debug.Log("Continuando");
        pausaMenu.SetActive(false);
        Time.timeScale = 1f;        
        thePlayer.canShoot = true;  
        thePlayer.canMove = true;  
        isPaused = false;
    }

    public void Volver(){

        UnityEngine.SceneManagement.SceneManager.LoadScene(NewGameScene);

    }

}
