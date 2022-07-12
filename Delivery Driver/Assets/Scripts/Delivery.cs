using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] GameObject Package;
    [SerializeField] GameObject Customer;
    [SerializeField] Color32 hasPackageColor =new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor =new Color32(1,1,1,1);
    
    SpriteRenderer spriteRenderer;
    
    bool hasPackage;

     private void Start() 
     {
        spriteRenderer=GetComponent<SpriteRenderer>();
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
                Debug.Log("Package Deliverd");
                Package.transform.position=Customer.transform.position-new Vector3(1,2,0);
                spriteRenderer.color=noPackageColor;
                //spriteRenderer.isVisible=true;
                Destroy(Package.gameObject,0.75f);
                
            }
        else if(other.tag=="Customer"&& !hasPackage)
            Debug.Log("You don't have package! Take the package");
       
    }
}
