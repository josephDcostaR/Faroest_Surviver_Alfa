using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Controller : MonoBehaviour
{
    [Header("weapon status")]
    public Weapons_Sciptable_Objects weaponData;

    float currentCooldownn;
    protected PlayerController pm;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerController>();
        currentCooldownn = weaponData.CooldownDuration;
    }

    // Update is called once per frame
     protected virtual void Update()
    {
        currentCooldownn -= Time.deltaTime; 
        if(currentCooldownn <= 0f)
        {
            Attack();
        }
    }

     protected virtual void Attack()
    {
        currentCooldownn = weaponData.CooldownDuration;
    }
}
