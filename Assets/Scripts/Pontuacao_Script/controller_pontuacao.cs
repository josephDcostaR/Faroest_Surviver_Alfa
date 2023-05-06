using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class controller_pontuacao 
{

    private static int pontucao;

    public static int Pontucao
    {
        get{
            return pontucao;
        }
        set {
            pontucao = value;
            if (pontucao < 0)
            {
                pontucao = 0;
            }
            Debug.Log("Pontuação: " + Pontucao);
        }
    }
   
}
