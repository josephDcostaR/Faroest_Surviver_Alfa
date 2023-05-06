using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{

    public Text textoPontuacao;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        this.textoPontuacao.text = controller_pontuacao.Pontucao.ToString();
    }
}
