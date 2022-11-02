using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    static public UIManager Instance;
    //[SerializeField] AudioSource buttonEffect;
    [SerializeField] GameObject Tutorial;
    [SerializeField] GameObject Warning;
    private void Awake()
    {
        Instance = this;
    }
    public void PlayGame()
    {
        //buttonEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //buttonEffect.Play();
        Debug.Log("Quit Game");
        Application.Quit();
    }
     public void Settting()
    {
        //buttonEffect.Play();
        Debug.Log("Setting");
        
    }
    public void Toturial()
    {
        //buttonEffect.Play();
        Tutorial.SetActive(true);  
        Debug.Log("Toturial");
    }
      public void Home()
    {
        //buttonEffect.Play();
        Tutorial.SetActive(false);  
    }
       public void Ok()
    {
        //buttonEffect.Play();
        Warning.SetActive(false);  
    }


    public void RestartloadGame()
    {
        SceneManager.LoadScene("UI Scene");
    }
}
