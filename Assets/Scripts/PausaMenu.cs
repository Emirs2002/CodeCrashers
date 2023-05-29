using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public GameObject pausaMenu;
    public string NewGameScene;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pausaMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (isPaused){
                Reanudar();
            }else{
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        Debug.Log("Pausando");
        pausaMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Reanudar(){

        Debug.Log("Continuando");
        pausaMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Volver(){

        UnityEngine.SceneManagement.SceneManager.LoadScene(NewGameScene);

    }

    public void Cerrar(){

        Application.Quit();
        Debug.Log("Cerrando juego");
    }
}
