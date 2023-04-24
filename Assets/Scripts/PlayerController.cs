
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // velocidade do jogador

    // Variáveis para controle de movimento nas 8 direções
    private Vector2 direction = Vector2.zero;
    private bool isMoving = false;

    public float maxHealth;
    public float currentHealth;
    void Start() {

        currentHealth = maxHealth;
    }

    // Update é chamado a cada quadro
    void Update()
    {
        // Verifica se o jogador está em movimento
        if (!isMoving)
        {
            // Obtem a entrada de direção do jogador
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            // Verifica se o jogador está se movendo nas 8 direções
            if (direction != Vector2.zero)
            {
                // Verifica a direção do movimento e ajusta a rotação do jogador
                if (direction.x > 0)
                    transform.eulerAngles = new Vector3(0, 0, 270);
                else if (direction.x < 0)
                    transform.eulerAngles = new Vector3(0, 0, 90);
                else if (direction.y > 0)
                    transform.eulerAngles = new Vector3(0, 0, 0);
                else if (direction.y < 0)
                    transform.eulerAngles = new Vector3(0, 0, 180);

                // Inicia a movimentação do jogador
                StartCoroutine(MovePlayer());
            }
        }
    }

    // Coroutine para movimentação do jogador
    IEnumerator MovePlayer()
    {
        isMoving = true;

        // Calcula a posição final do movimento
        Vector3 endPosition = transform.position + new Vector3(direction.x, direction.y, 0f);

        // Executa a movimentação do jogador
        while (transform.position != endPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            yield return null;
        }

     
        isMoving = false;
    }

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


