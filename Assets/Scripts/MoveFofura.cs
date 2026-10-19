using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFofura : MonoBehaviour
{
    [Header("Efeitos de Vitória")]
    public GameObject efeitoCoracoes; // Arraste o objeto de corações aqui
    public GameObject balaoVitoria;   // Arraste o objeto do balão aqui

    private Rigidbody2D rb2d;
    private bool jogoFinalizado = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d == null)
        {
            Debug.LogError("O objeto " + gameObject.name + " precisa de um componente Rigidbody2D!");
        }

        // Garante que ambos comecem desativados quando a fase inicia
        if (efeitoCoracoes != null)
        {
            efeitoCoracoes.SetActive(false);
        }

        if (balaoVitoria != null)
        {
            balaoVitoria.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Se o Felpudo encostar nela e o jogo ainda não tiver acabado
        if (!jogoFinalizado && (collision.gameObject.CompareTag("Player") || collision.gameObject.name.Contains("Felpudo")))
        {
            jogoFinalizado = true;

            // Ativa o efeito de corações
            if (efeitoCoracoes != null)
            {
                efeitoCoracoes.SetActive(true);
            }

            // Faz o balão surgir na tela
            if (balaoVitoria != null)
            {
                balaoVitoria.SetActive(true);
            }
        }
    }
}