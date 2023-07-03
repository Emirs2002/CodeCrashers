using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public GameObject pausaMenu;
    public GameObject controles;
    public string NewGameScene;
    public static bool isPaused;
    public static bool isActiveControl;
    private PlayerController thePlayer;
    public GameObject gameOver;
   
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        pausaMenu.SetActive(false);
        controles.SetActive(false);
        thePlayer = PlayerHealthController.instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)){

            if ((isPaused)  && (!isActiveControl)){
                Reanudar();
                
            }else if ((isPaused)  && (isActiveControl)){
                VolverMenuPausa();
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

    public void VerControles(){

        Debug.Log("Viendo Controles");
        controles.SetActive(true);
        isActiveControl = true;
        pausaMenu.SetActive(false);
    }

    public void VolverMenuPausa(){
        Debug.Log("Volviendo");
        controles.SetActive(false);
        isActiveControl = false;
        pausaMenu.SetActive(true);
    }

}
