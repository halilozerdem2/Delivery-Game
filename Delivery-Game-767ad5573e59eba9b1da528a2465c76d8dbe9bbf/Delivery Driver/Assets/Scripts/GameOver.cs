using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] public Text scoreText;
   
   public void TryAgainButtonClicked()
   {
        SceneManager.LoadScene(1);
   }
   public void QuitButtonClicked()
   {
        Application.Quit();
   }
   private void Awake() 
   {
        scoreText.text=Timer.timer;
   }
}
