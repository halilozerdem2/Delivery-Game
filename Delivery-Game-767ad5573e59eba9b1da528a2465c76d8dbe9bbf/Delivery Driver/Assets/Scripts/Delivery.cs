using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Delivery : MonoBehaviour
{
    [SerializeField] GameObject package;
    [SerializeField] GameObject customer;
    [SerializeField] Text remainText;
    [SerializeField] ObjectPool objectPool;
    [SerializeField] Color32 hasPackageColor =new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor =new Color32(1,1,1,1);

    SpriteRenderer spriteRenderer;
    public Package packageObject;

    public static int Counter=0;
     
    bool hasPackage;
   
     private void Start() 
     {      
        AddNewPackage();
    
        spriteRenderer=GetComponent<SpriteRenderer>();
     }
   
    private void Update() 
    {
        remainText.text= (5-Counter).ToString() + " Packages Remain !";
    }
   
    private void OnTriggerEnter2D(Collider2D other) {
      
        if(other.tag=="Package"&& !hasPackage)
            {
                Debug.Log("Package Picked Up!!");
                hasPackage=true;
                spriteRenderer.color=hasPackageColor;
            } 

        if(other.tag=="Customer"&& hasPackage)
            {
                hasPackage=false;
                Debug.Log("Package Deliverd");
                
                spriteRenderer.color=noPackageColor;

                objectPool.Deactivate(package);
                Counter++;
                AddNewPackage();        
            }

        else if(other.tag=="Customer"&& !hasPackage)
        {
            Debug.Log("You don't have package! Take the package");
        }
       
    }
    
    private void AddNewPackage()
    {
        var obj=objectPool.ObjectActivate();
        obj.transform.position=packageObject.AssignThePackageLocation();
    }

}
