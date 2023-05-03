
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{

    public Image currentLifeImage; // Imagem da vida atual
    public Image maxLifeImage; // Imagem da vida máxima

    private PlayerController player; 

    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLifeImage.fillAmount = player.currentHealth / player.maxHealth;
    }
   
}


  