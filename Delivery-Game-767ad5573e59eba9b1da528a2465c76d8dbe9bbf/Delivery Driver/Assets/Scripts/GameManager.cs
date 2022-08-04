using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void Update() 
    {
        DontDestroyOnLoad(gameObject);

        if(SceneManager.GetActiveScene().buildIndex==1)
        {
            Timer.StartTimer();

            if(Delivery.Counter==5)
            {
                Timer.Finish();
                SceneManager.LoadScene(2);
            
            }    
        }
       
        else if( SceneManager.GetActiveScene().buildIndex==2)
        {
            Delivery.Counter=0;
        }

    }
   
    
}
