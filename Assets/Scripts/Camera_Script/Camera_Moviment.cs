using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Moviment : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
  
   
    void Update() {
    if(target != null) { // verifique se o target não é nulo
        transform.position = target.position + offset; // agora é seguro acessar a posição do target
    }
  }
}
