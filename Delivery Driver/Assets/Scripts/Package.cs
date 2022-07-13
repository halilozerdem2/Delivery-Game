using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
   public Vector2 packagePos => transform.position;
   public bool isCollide=false;
   public bool delieverd=false;

  private void OnTriggerEnter2D(Collider2D other) 
  {   
      if(other.tag=="Player")
         {   
            isCollide = true;
         }
      if(other.tag=="Customer")
      {
         delieverd=true;
      }
  }
   

   private void Awake() 
   {
      isCollide = false;
   }

   private void Update() 
   {
      if(isCollide&& !delieverd) {
         this.transform.position=DriverScript.PlayerPosition;
      }
   }
}
