
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f; 
 
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
     public Vector2 moveDir;
      [HideInInspector]
    public Vector2 lastMovedVector;

    Rigidbody2D rb;
 
    public float maxHealth;
    public float currentHealth;

    
     [Header("I-Frame")]
     public float invincibilityDuration;
     float invincibilityTimer;

     bool isInvicible;

   

    void Start() {

        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);

    }
    
    void Update()
    {
    if (invincibilityTimer > 0)
    {
        invincibilityTimer -= Time.deltaTime;
    }
    else if (isInvicible)
    {
        isInvicible = false;
        }

      InputManagement();
                    
    }

   void FixedUpdate() 
    {
        move();    
    }

    void InputManagement()
    {
         float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }

        if(moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }

    }

    void move()
    {
         rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }

    
     public void TakeDamage(float dmg)
    {
        if (!isInvicible)
        {
             currentHealth -= dmg;

             invincibilityTimer = invincibilityDuration;
             isInvicible = true;

            if (currentHealth <= 0)
            {
                Debug.Log("GAME OVER");
                Die();
            }
        }
       
    }

    public void Die(){
        Destroy(gameObject);
       
    }


    

   


}


