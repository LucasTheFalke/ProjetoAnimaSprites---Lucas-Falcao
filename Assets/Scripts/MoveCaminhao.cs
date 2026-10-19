using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCaminhao : MonoBehaviour
{
    [Header("Configuração de Movimento")]
    public float velocidade = 4f; 
    public float tempoParaSumir = 6f;

    void Start()
    {
        StartCoroutine(DesaparecerDepoisDoTempo());
    }

    void Update()
    {
        
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }

    IEnumerator DesaparecerDepoisDoTempo()
    {
        yield return new WaitForSeconds(tempoParaSumir);

        gameObject.SetActive(false);
    }
}