
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
  
//Movimentação
    public float speed = 5.0f;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 lastMovedVector;

    [HideInInspector]
    public Vector2 moveDir;
    Rigidbody2D rb;

//Vida
    public float currentHealth;//Vida Atual
    public float maxHealth;//vida total
    

//Invencibilidade
    [Header("I-Frame")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvicible;

//JoyStick-Virtual
    public VirtualJoyStick virtualJoyStick;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
        controller_pontuacao.Pontucao = 0;

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

//Movimentacao
    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        if (virtualJoyStick != null)
        {
            float moveX = virtualJoyStick.axis.x;
            float moveY = virtualJoyStick.axis.y;

            moveDir = new Vector2(moveX, moveY).normalized;

            if (moveDir.magnitude > 0) // Verifica se houve movimentação
            {
                lastMovedVector = moveDir; // Salva a última direção movimentada
            }
            if(moveDir.x != 0)
            {
                lastHorizontalVector = moveDir.x;
            }
             if(moveDir.x != 0)
            {
                lastVerticalVector = moveDir.y;
            }


        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);

    }

//Combate
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

//Morte
    public void Die()
    {
       GoToMenuScene();
        Destroy(gameObject);   
    }

    private void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
    }

}


