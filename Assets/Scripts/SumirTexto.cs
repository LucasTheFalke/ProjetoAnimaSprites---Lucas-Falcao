using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Descomente a linha abaixo se usar TextMeshPro:
// using TMPro;

public class SumirTexto : MonoBehaviour
{
    [Header("Configuração de Tempo")]
    public float tempoNaTela = 4f; 

    void Start()
    {
        
        StartCoroutine(EsconderTextoDepoisDeTempo());
    }

    IEnumerator EsconderTextoDepoisDeTempo()
    {
        
        yield return new WaitForSeconds(tempoNaTela);

        
        gameObject.SetActive(false);

    }
}