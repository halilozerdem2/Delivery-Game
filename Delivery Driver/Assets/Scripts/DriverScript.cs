using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed=25f;
    [SerializeField] float slowSpeed=15f;
    [SerializeField] float boostSpeed=40f;
    private bool moving;
    public static Vector2 PlayerPosition;
   

    void Update()
    {
        PlayerPosition=this.transform.position;
        
        float steerAmount=Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount=Input.GetAxis("Vertical") * moveSpeed* Time.deltaTime;
        

        if(moveAmount==0) // Hareket halinde değilse dönme
            steerAmount=0;
        
        if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)&&moveAmount<0)

            transform.Rotate(0,0,steerAmount);
        else
            transform.Rotate(0,0,-steerAmount);
        
        transform.Translate(0,moveAmount,0);

        
    }
   


        
    

    void OnCollisionEnter2D(Collision2D other) {
     moveSpeed=slowSpeed;
   }
    void OnTriggerEnter2D(Collider2D other) {
    if(other.tag=="SpeedUp")
        moveSpeed=boostSpeed;
   }
}
