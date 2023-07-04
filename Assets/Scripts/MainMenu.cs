
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string NewGameScene;

    public GameObject continueButton;

    public GameObject newButton;

    public PlayerAbilityTracker player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        player = GetComponent<PlayerAbilityTracker>();
        continueButton.SetActive(false);
        newButton.SetActive(true);

        if(PlayerPrefs.HasKey("ContinueLevel")){
            continueButton.SetActive(true);
            newButton.SetActive(false);
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
        PlayerPrefs.DeleteKey("ContinueLevel");
        continueButton.SetActive(false);
        newButton.SetActive(false);
    }

}
