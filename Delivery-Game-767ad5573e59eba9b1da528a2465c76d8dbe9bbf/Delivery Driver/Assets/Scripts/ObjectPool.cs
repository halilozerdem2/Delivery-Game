using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> pooledObjects;
   
    [SerializeField] private GameObject objectPrefab;
    
    [SerializeField] private int poolsize;
    

    public void Awake() 
    {
        pooledObjects=new Queue<GameObject>();
        

        for (int i = 0; i < poolsize; i++)
        {
            GameObject obj=Instantiate(objectPrefab);
            obj.SetActive(false);
            obj.transform.SetParent(this.transform); //oluşturulan objeyi object poolun alt objeleri haline getirir.

            pooledObjects.Enqueue(obj);

        }
    }
    public GameObject ObjectActivate()
    {    
        
         var obj= pooledObjects.Peek();
         obj.SetActive(true);

       return obj;
    }
    
    public GameObject Deactivate(GameObject aObject)
    {   
        
        aObject=pooledObjects.Dequeue();
        aObject.SetActive(false);

        pooledObjects.Enqueue(aObject);

        return aObject;
    }
   
   
}
