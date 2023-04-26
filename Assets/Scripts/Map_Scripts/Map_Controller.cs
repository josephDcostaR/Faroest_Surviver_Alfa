using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Map_Controller : MonoBehaviour
{


    public List<GameObject> terrainCunks;
    public GameObject Player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerController pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        chunkChecker();
    }

    void chunkChecker()
    {
       if (pm.moveDir.x > 0 && pm.moveDir.y == 0) //Rigth
       {
            if(!Physics2D.OverlapCircle(Player.transform.position + Vector3(20,0,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + Vector3(20,0,0);
                spawChunk();
            }
       }

       else if (pm.moveDir.x < 0 && pm.moveDir.y == 0) //Left
       {
            if(!Physics2D.OverlapCircle(Player.transform.position + Vector3(-20,0,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + Vector3(-20,0,0);
                spawChunk();
            }
       }

        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0) //up
       {
            if(!Physics2D.OverlapCircle(Player.transform.position + Vector3(0,20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + Vector3(0,20,0);
                spawChunk();
            }
       }

        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0) //down
       {
            if(!Physics2D.OverlapCircle(Player.transform.position + Vector3(0,-20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + Vector3(0,-20,0);
                spawChunk();
            }
       }

        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0) //Rigth up
       {
            if(!Physics2D.OverlapCircle(Player.transform.position + Vector3(20,20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + Vector3(20,20,0);
                spawChunk();
            }
       }

        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0) //Rigth down
       {
            if(!Physics2D.OverlapCircle(Player.transform.position + Vector3(20,-20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + Vector3(20,-20,0);
                spawChunk();
            }
       }

        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0) //Left up
       {
            if(!Physics2D.OverlapCircle(Player.transform.position + Vector3(-20,0,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + Vector3(-20,20,0);
                spawChunk();
            }
       }

        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0) //Left doen
       {
            if(!Physics2D.OverlapCircle(Player.transform.position + Vector3(-20,-20,0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + Vector3(-20,-20,0);
                spawChunk();
            }
       }
    }

    void spawChunk()
    {

     int rand = Random.Range(0, terrainCunks.Count);
     Instantiate(terrainCunks[rand], noTerrainPosition, Quaternion.identity);

    }

    private Vector3 Vector3(int v1, int v2, int v3)
    {
        throw new NotImplementedException();
    }
}

