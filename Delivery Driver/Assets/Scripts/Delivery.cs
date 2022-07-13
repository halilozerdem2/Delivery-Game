using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Delivery : MonoBehaviour
{
    [SerializeField] GameObject Package;
    [SerializeField] GameObject Customer;
    [SerializeField] ObjectPool objectPool;
    
    [SerializeField] Color32 hasPackageColor =new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor =new Color32(1,1,1,1);

    
    
    SpriteRenderer spriteRenderer;
    public Vector2 LocationOfThePackageToSpawn;
    public int Xint;
    private int Counter=10;
    public int Yint;

    
    bool hasPackage;

   
     private void Start() 
     {      
        AddNewPackage();
    
        spriteRenderer=GetComponent<SpriteRenderer>();
     }
   
    private void Update() 
    {
        if(Counter==objectPool.poolCounter)
            {
                Debug.Log("Oyun Bitti");
                Application.Quit();
            }
    }
   

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag=="Package"&& !hasPackage)
       {
        Debug.Log("Package Picked Up!!");
        hasPackage=true;
        spriteRenderer.color=hasPackageColor;

       
        
       } 
        else if (other.tag=="Package"&& hasPackage)
            Debug.Log("You already have a package. Deliever it!");
        
        
        if(other.tag=="Customer"&& hasPackage)
            {
                hasPackage=false;
                Debug.Log("Package Deliverd");
                
                
                spriteRenderer.color=noPackageColor;

                objectPool.Deactivate(Package);
                 AddNewPackage();
            }
        else if(other.tag=="Customer"&& !hasPackage)
            Debug.Log("You don't have package! Take the package");
       
    }
    
    private void AddNewPackage()
    {
        Xint=Random.Range(-50,50);
        Yint=Random.Range(-50,50);   
        
        LocationOfThePackageToSpawn=new Vector2(Xint,Yint);
        
        var obj=objectPool.ObjectActivate();
        obj.transform.position=LocationOfThePackageToSpawn;
        
        
    }
    
}
