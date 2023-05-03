using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Controller : Weapons_Controller
{
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
  
    // protected override void Attack()
    // {
    //     base.Attack();
    //     GameObject spawnedKnife  = Instantiate(weaponData.Prefab);
    //     spawnedKnife.transform.position = transform.position;
    //     spawnedKnife.GetComponent<Knife_Behaviour>().DirectionChecker(pm.lastMovedVector);
    // }

    protected override void Attack()
    {
        base.Attack();

        GameObject spawnedKnife = Instantiate(weaponData.Prefab, transform.position, Quaternion.identity);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null) {
            spawnedKnife.GetComponent<Knife_Behaviour>().SetDirection(closestEnemy.transform.position - transform.position);
        }

        spawnedKnife.transform.position = transform.position;
    }

}
