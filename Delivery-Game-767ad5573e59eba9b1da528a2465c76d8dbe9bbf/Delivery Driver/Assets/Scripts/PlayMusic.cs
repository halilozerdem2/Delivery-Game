using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    
    public AudioSource src;
    public AudioClip mainMenuMusic, playMusic, gameOverMusic;
    public bool playing;


    private void Update() 
    {
        DontDestroyOnLoad(gameObject);
        if(!src.isPlaying)
        {
            src.Play();
        }
    }
         void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change
        // as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
         
    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a 
        //scene change as soon as this script is disabled. Remember to always have an 
        //unsubscription for every delegate you subscribe to!
                 SceneManager.sceneLoaded -= OnLevelFinishedLoading;
             }
         
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if(scene.name=="MainMenuScene" )
            {
                src.clip=mainMenuMusic;
               
                  src.Play();
                
                
            }    
            if(scene.name=="SampleScene")
            {
                src.clip=playMusic;
                src.Play();
                 
            } 
            if(scene.name=="GameOverScene")
            {
                src.clip=gameOverMusic;
                src.Play();
                  
            } 
        }
  
}
