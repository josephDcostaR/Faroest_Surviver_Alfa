using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Behaviour : Projectile_Weapon_Behaviour
{


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * weaponData.Speed  * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir) {
    direction = dir.normalized;
}

}
