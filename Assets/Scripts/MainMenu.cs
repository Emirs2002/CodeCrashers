
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public string NewGameScene;

    public GameObject continueButton;
    public GameObject newButton;
    public GameObject mensaje;

    public PlayerAbilityTracker player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        player = GetComponent<PlayerAbilityTracker>();
        continueButton.SetActive(false);
        newButton.SetActive(true);
        mensaje.SetActive(false);

        if(PlayerPrefs.HasKey("ContinueLevel")){
            continueButton.SetActive(true);
            newButton.SetActive(false);
            mensaje.SetActive(false);
        }
        AudioManager.instance.PlayMainMenuMusic();
    }

    public void NuevoJuego(){
        
        PlayerPrefs.DeleteAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene(NewGameScene);
    }

    public void Continue(){

        Debug.Log("Continuando partida");

        player.gameObject.SetActive(true);
        
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"),PlayerPrefs.GetFloat("PosY"),PlayerPrefs.GetFloat("PosZ"));

        UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("ContinueLevel"));
        
    }

    public void SalirJuego(){

        Application.Quit();
        Debug.Log("Cerrando juego");
        PlayerPrefs.DeleteKey("ContinueLevel");
        continueButton.SetActive(false);
        newButton.SetActive(false);
        mensaje.SetActive(true);

    }

}
