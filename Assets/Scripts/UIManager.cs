using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PulseManager pulseManager;
    public GameObject pauseMenu, startMenu, gameOverMenu;
    public Button btnPause, btnReprendreJeu, btnCommencerJeu, btnRecommencerJeu, btnQuitterJeu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        btnPause.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CommencerJeu(){
        //print("CommencerJeu");
        startMenu.SetActive(false);
        btnPause.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void RecommencerJeu(){
        //print("RecommencerJeu");
        ReprendreJeu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MettreEnPause(){
        //print("MettreEnPause");
        btnPause.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReprendreJeu(){
        //print("ReprendreJeu");
        btnPause.gameObject.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitterJeu(){
        //print("Le jeu se termine.");
        Application.Quit();
    }

    public void GameOver(){
        //print("GameOver");
        //Time.timeScale = 0f;

        gameOverMenu.SetActive(true);
        btnPause.gameObject.SetActive(false);
    }

}
