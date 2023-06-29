
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string NewGameScene;

    public GameObject continueButton;

    

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("ContinueLevel")){
            continueButton.SetActive(true);
        }
        
    }

    public void NuevoJuego(){

        PlayerPrefs.DeleteAll();

        UnityEngine.SceneManagement.SceneManager.LoadScene(NewGameScene);

    }

    public void Continue(){

        UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("ContinueLevel"));
    }

    public void SalirJuego(){

        Application.Quit();
        Debug.Log("Cerrando juego");
    }

}
