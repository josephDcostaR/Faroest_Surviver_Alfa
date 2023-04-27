
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f; 
    public Rigidbody2D rb;
    public Vector2 moveDir;
   
    public float maxHealth;
    public float currentHealth;

    void Start() {

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    
    void Update()
    {

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

    }

    void move()
    {
         rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }

    // Coroutine para movimentação do jogador
    

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("GAME OVER");
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
       
    }


}


