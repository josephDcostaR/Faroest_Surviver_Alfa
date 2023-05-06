using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Weapon_Behaviour : MonoBehaviour
{

    public Weapons_Sciptable_Objects weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;

    //Curent status
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected float currentPierce;

     void Awake()    
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // public void DirectionChecker(Vector3 dir)
    // {
    //     direction = dir;

    //     float dirx = direction.x;
    //     float diry = direction.y;

    //     Vector3 scale = transform.localScale;
    //     Vector3 rotation = transform.rotation.eulerAngles;

    //     if (dirx < 0 && diry == 0) //left
    //     {
    //         scale.x = scale.x * 1;
    //         scale.y = scale.y * -1;
    //     }
    //     else if (dirx == 0 && diry < 0) //down
    //     {
    //         scale.y = scale.y * -1;
    //     }
    //     else if (dirx == 0 && diry > 0) //up
    //     {
    //         scale.x = scale.x * -1;
    //     }
    //     else if (dirx > 0 && diry > 0) //right up
    //     {
    //         rotation.z = 0f;
    //     }
    //     else if (dirx > 0 && diry < 0) //right down
    //     {
    //         rotation.z = 90f;
    //     }
    //     else if (dirx > 0 && diry > 0) // left up
    //     {
    //         scale.x = scale.x * -1;
    //         scale.y = scale.y * -1;
    //         rotation.z = -90f;
    //     }
    //     else if (dirx < 0 && diry < 0) //left down
    //     {
    //         scale.x = scale.x * -1;
    //         scale.y = scale.y * -1;
    //         rotation.z = 0f;
    //     }

    //     transform.localScale = scale;
    //     transform.rotation = Quaternion.Euler(rotation);
    // }

    public void DirectionChecker(Vector3 dir)
{
    direction = dir;

    Vector3 scale = transform.localScale;
    Vector3 rotation = transform.rotation.eulerAngles;

    if (dir.x < 0) // left
    {
        scale.x = Mathf.Abs(scale.x) * -1f;
    }
    else if (dir.x > 0) // right
    {
        scale.x = Mathf.Abs(scale.x) * 1f;
    }

    if (dir.y < 0) // down
    {
        rotation.z = 90f;
        scale.y = Mathf.Abs(scale.y) * -1f;
    }
    else if (dir.y > 0) // up
    {
        rotation.z = -90f;
        scale.y = Mathf.Abs(scale.y) * 1f;
    }

    transform.localScale = scale;
    transform.rotation = Quaternion.Euler(rotation);
}


   protected virtual void OnTriggerEnter2D(Collider2D col) 
{
    if (col.CompareTag("Enemy"))
    {
        col.GetComponent<Enemy_Stalker>().TakeDamage(currentDamage);
        Enemy_Stalker enemy = col.GetComponent<Enemy_Stalker>();
        enemy.Die();
        reducePierce();
    }
}

    void reducePierce()
    {
        currentPierce--;

        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }

}
