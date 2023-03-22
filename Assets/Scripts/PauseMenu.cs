using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject MengPause;
    // public Gaskeunn DahWin;


    public void Paused()
    {
        MengPause.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        // DahWin.MengWin.SetActive(false);
        
    }

    public void Resume()
    {
        MengPause.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("---Menu---");
    }

    public void QuitGame(){
        Debug.Log("---Quit---");
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPause){
                Resume();
            }
            else {
                Paused();
            }
        }
    }

}
