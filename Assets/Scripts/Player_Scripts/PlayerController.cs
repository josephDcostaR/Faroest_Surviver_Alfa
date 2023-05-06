
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    void FixedUpdate()
    {
        move();
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

    public void Die()
    {
       GoToMenuScene();

        Destroy(gameObject);
       
    }

    private void GoToMenuScene()
    {
        SceneManager.LoadScene(1);
    }

}


