using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
  // Referência ao componente Animator
    public Animator animator;

    // Referência ao componente SpriteRenderer
    public SpriteRenderer spriteRenderer;

    // Referência ao componente PlayerController
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        // Inicialização das referências
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se houve movimentação
        if (playerController.moveDir.magnitude > 0)
        {
            // Ativa o parâmetro de animação "isMoving"
            animator.SetBool("Move", true);

            // Define a direção do sprite
            if (playerController.moveDir.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (playerController.moveDir.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            // Desativa o parâmetro de animação "isMoving"
            animator.SetBool("Move", false);
        }
    }
}
