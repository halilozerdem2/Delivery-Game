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
   public int XPos;
   public int YPos;

   
   private void Awake() 
   {
      
      isCollide = false;
   }

   private void Update() 
   {
      if(isCollide&& !delieverd) 
      {
          this.transform.position=DriverScript.playerPosition;
      }
      
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
  public Vector2 AssignThePackageLocation()
  {      
      do
      {
        RandomPos();
      }
      while(!CanSpawn(Location));
      
      return Location;
   }

   public Vector2 RandomPos()
   {
        //<! Tanımlı harita alanı
      float xLeftLine = LeftWall.transform.position.x;
      float xRightLine = RightWall.transform.position.x;
      float yTopLine = TopWall.transform.position.y;
      float yBottomLine = BottomWall.transform.position.y;

      XPos=Random.Range((int)xLeftLine,(int) xRightLine);
      YPos=Random.Range((int) yBottomLine,(int) yTopLine);
      
      Location= new Vector2(XPos,YPos);
     
      return Location;
   }

   public bool CanSpawn(Vector2 pos)
   {
        //<! Nokta spawnlanabilir bir yerdeyse null döner
        Collider2D isPossibleSpawnSpoint = Physics2D.OverlapPoint(pos);

        //<! Null dönmüşse => verilen nokta hiçbir objenin içinde değildir.
        if(isPossibleSpawnSpoint == null) 
        {
            PossibleLocationOfPackages.Add(pos);
            return true;
        }
        
        return false;
   }

}
