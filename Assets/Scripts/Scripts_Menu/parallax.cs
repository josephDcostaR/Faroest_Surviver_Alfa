using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parallax : MonoBehaviour
{
    


    private Renderer myRender;
    private Material myMaterial;
    private float offset;
    [SerializeField] private float increase;
    [SerializeField] private float speed;
    [SerializeField] private string  sortingLayer;
    [SerializeField] private int sortingOrder;



    void Start() {
         myRender = GetComponent<MeshRenderer>();
         myMaterial = myRender.material;

         myRender.sortingLayerName = sortingLayer;
         myRender.sortingOrder = sortingOrder;
    }

    private void FixedUpdate() {
        offset += increase;
        myMaterial.SetTextureOffset("_MainTex", new Vector2((offset * speed)/1000,0));
    }
   
}
