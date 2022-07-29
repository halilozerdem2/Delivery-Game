using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Package : MonoBehaviour
{
   public ObjectPool packageObject;
   public Delivery deliveryObject;

   [SerializeField] GameObject wall;



   public bool isCollide=false;
   public bool delieverd=false;
  


   public List<Vector2> possibleLocationOfPackages;
   public Vector2 location;
   public int XPos;
   public int YPos;

   
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
         
      else if(other.tag=="Customer")
      {
         delieverd=true;
      }
              
  }
  public Vector2 AssignThePackageLocation(GameObject aPackage)
  {      
      do
      {
        RandomPos(aPackage);
      }
      while(CanSpawn(XPos,YPos)==false);
            
      return location;

   }

   public void RandomPos(GameObject aPackagePos)
   {
        //<! Tanımlı harita alanı
         

      
      XPos=Random.Range(5,5);
      YPos=Random.Range(5,5);

      location= new Vector2(XPos,YPos);
      
   }

 public bool CanSpawn(float x, float y)
    {
        //<! Nokta spawnlanabilir bir yerdeyse null döner
        Collider2D noktanin_icinde_bulundugu_nesne = Physics2D.OverlapPoint(new Vector2(x,y));

        //<! Null dönmüşse => verilen nokta hiçbir objenin içinde değildir.
        if(noktanin_icinde_bulundugu_nesne == null) {
            return true;
        }
        
        //Debug.Log(noktanin_icinde_bulundugu_nesne.name + " objesinin içinde oluştu. Konum değiştiriliyor !!");
        //<! Null değilse => verilen nokta, belli bir objenin içindedir.
        return false;
    }

}
