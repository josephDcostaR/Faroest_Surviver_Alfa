
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stalker : MonoBehaviour
{

    [SerializeField]
    public Enemy_Scriptable_Object enemyData;
     float moveSpeed;
    float maxHealth;
    float currentHealth;
    float damage;
    private Transform playerTransform;




    void Start()
    {
         playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        moveSpeed = enemyData.MoveSpeed;
        maxHealth = enemyData.MaxHealth;
        currentHealth = maxHealth;
        damage = enemyData.Damage;
        
    }


    void Update()
    {
        fallowPlayer();    
    }

    private void fallowPlayer()
    {
        if(playerTransform != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, enemyData.MoveSpeed * Time.deltaTime);
        }
    }

   
 
    private void OnTriggerStay2D(Collider2D col)
    {

        if(col.gameObject.CompareTag("Player"))
        {
            
            col.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            
        }
        
    }

     public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death logic here
        Destroy(gameObject);
    }



   
}

