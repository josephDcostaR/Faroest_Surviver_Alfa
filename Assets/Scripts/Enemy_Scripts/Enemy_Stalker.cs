
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stalker : MonoBehaviour
{

    private Transform playerTransform;

    public float damage;
    public float moveSpeed;



    void Start()
    {
         playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }


    void Update()
    {
        fallowPlayer();    
    }

    private void fallowPlayer()
    {
        if(playerTransform != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
    }

 
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            
        }
        
    }




   
}

