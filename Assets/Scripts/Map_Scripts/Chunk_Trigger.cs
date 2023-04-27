using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk_Trigger : MonoBehaviour
{
    Map_Controller mc;
    public GameObject targetMap;
    void Start()
    {
        mc = FindObjectOfType<Map_Controller>();
    }

   private void OnTriggerStay2D(Collider2D col)
   {
    if (col.CompareTag("Player"))
    {
        mc.currentChunk = targetMap; 
    }
        
   }

   private void OnTriggerExit2D(Collider2D col) 
   {
     if(col.CompareTag("Player"))
     {
        if(mc.currentChunk == targetMap)
        {
            mc.currentChunk = null;
        }
     }
    
   }
}
