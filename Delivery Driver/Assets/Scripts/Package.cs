using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Package : MonoBehaviour
{
   public Vector2 packagePos => transform.position;
   public bool isCollide=false;
   public bool delieverd=false;


   public List<Vector2> PossibleLocationOfPackages;
   public Vector2 Location;
   public int Xint;
   public int Yint;

   
   private void Awake() 
   {
      
      isCollide = false;
   }

   private void Update() 
   {
      if(isCollide&& !delieverd) 
          this.transform.position=DriverScript.PlayerPosition;
      
   }
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
  public Vector2 CalculateTheLocation()
  {
   
      PossibleLocationOfPackages=new List<Vector2>();
      for (int i = 0; i < 10; i++)
      {
         
         Xint=Random.Range(50,-50);
         Yint=Random.Range(50,-50);


         Location= new Vector2(Xint,Yint);
         PossibleLocationOfPackages.Add(Location);
   
  }
   return Location;
}
