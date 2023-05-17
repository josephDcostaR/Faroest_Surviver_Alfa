
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{

    public Image maxLifeImage;

    public Image currentLifeImage; // Imagem da vida atual
    // Imagem da vida máxima

    private PlayerController player; 

    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       UpdateLifeBar();
    }

     void UpdateLifeBar()
    {
        float fillAmount = player.currentHealth / player.maxHealth;
        currentLifeImage.transform.localScale = new Vector3(fillAmount, 1f, 1f);
    }

    
}


  