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
    public Package PackageObject;

    private int Counter=10;
    
    bool hasPackage;
   
     private void Start() 
     {      
        AddNewPackage();
    
        spriteRenderer=GetComponent<SpriteRenderer>();
     }
   
    private void Update() 
    {
        if(Counter==15)
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
        var obj=objectPool.ObjectActivate();
        obj.transform.position=PackageObject.AssignThePackageLocation(obj);
    }

}
