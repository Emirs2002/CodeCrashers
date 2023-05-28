using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string NewGameScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NuevoJuego(){

        UnityEngine.SceneManagement.SceneManager.LoadScene(NewGameScene);

    }

    public void SalirJuego(){

        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
