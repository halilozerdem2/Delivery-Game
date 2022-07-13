using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> pooledObjects;
    public GameObject obj;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolsize;

    private void Awake() 
    {
        pooledObjects=new Queue<GameObject>();

        for (int i = 0; i < poolsize; i++)
        {
            GameObject obj=Instantiate(objectPrefab);
            obj.SetActive(false);

            pooledObjects.Enqueue(obj);

        }
    }
    public GameObject ObjectActivate()
    {
        obj = pooledObjects.Dequeue();
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);

        return obj;
    }
   public GameObject ObjectDeactivate ()
   {    

        obj.SetActive(false);
        return obj;
   }
}
