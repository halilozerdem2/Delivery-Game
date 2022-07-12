using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
   public Vector2 packagePos => transform.position;
   public bool isCollide;

  private void OnTriggerEnter2D(Collider2D other) 
  {   
      if(other.tag=="Player")
         {   
            isCollide = true;
         }
  }

   private void Awake() 
   {
      isCollide = false;
   }

   private void Update() 
   {
      if(isCollide) {
         this.transform.position=DriverScript.PlayerPosition;
      }
   }
}
