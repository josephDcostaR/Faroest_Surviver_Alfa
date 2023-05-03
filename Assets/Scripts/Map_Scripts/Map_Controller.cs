using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random = UnityEngine.Random;

public class Map_Controller : MonoBehaviour
{
    public List<GameObject> terrainCunks;
    public GameObject Player;
    public float checkerRadius;
    public Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerController pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist;
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        chunkChecker();
        chunkOptimizer();
    }

    void chunkChecker()
    {

        if(!currentChunk)
        {
            return;
        }

       if (pm.moveDir.x > 0 && pm.moveDir.y == 0) //Rigth
       {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Rigth").position, checkerRadius, terrainMask))
            {
                noTerrainPosition =currentChunk.transform.Find("Rigth").position;
                spawChunk();
            }
       }

       else if (pm.moveDir.x < 0 && pm.moveDir.y == 0) //Left
       {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                spawChunk();
            }
       }

        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0) //up
       {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                spawChunk();
            }
       }

        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0) //down
       {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                spawChunk();
            }
       }

        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0) //Rigth up
       {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Rigth Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Rigth Up").position;
                spawChunk();
            }
       }

        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0) //Rigth down
       {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Rigth Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Rigth Down").position;
                spawChunk();
            }
       }

        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0) //Left up
       {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Up").position;
                spawChunk();
            }
       }

        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0) //Left down
       {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position;
                spawChunk();
            }
       }
    }

    void spawChunk()
    { 
     int rand = UnityEngine.Random.Range(0, terrainCunks.Count);
    latestChunk = Instantiate(terrainCunks[rand], noTerrainPosition, Quaternion.identity);
    spawnedChunks.Add(latestChunk);
    }

    void chunkOptimizer()
    {
         if (Player == null)
       {
        return;
       }

        optimizerCooldown -= Time.deltaTime;

        if(optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(Player.transform.position, chunk.transform.position);
            if(opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}

