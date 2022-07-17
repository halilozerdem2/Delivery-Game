using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Package : MonoBehaviour
{
   public ObjectPool PackageObject;
   public Delivery DeliveryObject;

   [SerializeField] GameObject LeftWall;    
   [SerializeField] GameObject RightWall;    
   [SerializeField] GameObject TopWall;    
   [SerializeField] GameObject BottomWall; 

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
         isCollide = true;
         
      else if(other.tag=="Customer")
         delieverd=true;
              
      
  }
  public Vector2 AssignThePackageLocation(GameObject aPackage)
  {      
      do
      {
        RandomPos(aPackage);
      }
      while(CanSpawn(Xint,Yint)==false);
         
      Debug.Log(Location);
      
      return Location;

   }

   public void RandomPos(GameObject aPackagePos)
   {
        //<! Tanımlı harita alanı
      int xLeftLine = (int) LeftWall.transform.position.x;
      float xRightLine = RightWall.transform.position.x;
      float yTopLine = TopWall.transform.position.y;
      float yBottomLine = BottomWall.transform.position.y;

      Xint=Random.Range((int)xLeftLine,(int) xRightLine);
      Yint=Random.Range((int) yBottomLine,(int) yTopLine);

      Location= new Vector2(Xint,Yint);
      
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
