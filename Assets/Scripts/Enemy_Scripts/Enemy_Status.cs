using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : MonoBehaviour
{

    public Enemy_Scriptable_Object enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

   void Awake()
   {
    currentMoveSpeed = enemyData.MoveSpeed;
    currentHealth = enemyData.MaxHealth;
    currentDamage = enemyData.Damage;
   }



 

}
