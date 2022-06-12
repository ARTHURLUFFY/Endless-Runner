using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject buttonUp;
    public GameObject buttonDown;

    
    //public Character character;
    void Awake()
    {/*
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        */
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Controller()
    {
        if (buttonUp.activeInHierarchy == false)
        {
            buttonUp.SetActive(true);
            buttonDown.SetActive(true);
        }
        else
        {
            buttonUp.SetActive(false);
            buttonDown.SetActive(false);
        }
    }


    public void Pause()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }








    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        Ads();

        FindObjectOfType<Character>().health += 3;
        FindObjectOfType<Character>().continues -= 1;
        Time.timeScale = 1;
    }

    IEnumerator Ads()
    {
        Advertisement.Initialize("3479621", true);

        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
    }
}
