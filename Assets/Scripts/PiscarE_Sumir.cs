using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscarESumir : MonoBehaviour
{
    [Header("Configurações do Piscar")]
    public float tempoLigado = 0.5f;   // Tempo visível
    public float tempoDesligado = 0.5f; // Tempo invisível
    public float tempoTotalVida = 5f;   // Tempo total antes de sumir

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Pega o componente visual do sprite
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("O objeto " + gameObject.name + " precisa de um componente SpriteRenderer!");
        }
        else
        {
            // Inicia a rotina de piscar
            StartCoroutine(CicloPiscarESumir());
        }
    }

    IEnumerator CicloPiscarESumir()
    {
        float tempoDecorrido = 0f;

        while (tempoDecorrido < tempoTotalVida)
        {
            // Liga o visual
            if (spriteRenderer != null) spriteRenderer.enabled = true;
            yield return new WaitForSeconds(tempoLigado);
            tempoDecorrido += tempoLigado;

            if (tempoDecorrido >= tempoTotalVida) break;

            // Desliga o visual
            if (spriteRenderer != null) spriteRenderer.enabled = false;
            yield return new WaitForSeconds(tempoDesligado);
            tempoDecorrido += tempoDesligado;
        }

        // Quando o tempo acaba, some definitivamente
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }
}