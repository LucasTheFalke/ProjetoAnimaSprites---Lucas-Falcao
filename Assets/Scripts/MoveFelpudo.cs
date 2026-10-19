using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveFelpudo : MonoBehaviour
{
    public float speedValue = 5f; 
    public float jumpForce = 7f; 
    public GameObject efeitoCoracoes; 
    [Header("Acessórios")]
    public SpriteRenderer spriteCapacete; 

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer; 
    private bool podeAndar = true;
    private bool noChao = true; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 

        if (rb2d == null)
        {
            Debug.LogError("O objeto " + gameObject.name + " precisa de um componente Rigidbody2D!");
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("O objeto " + gameObject.name + " precisa de um componente SpriteRenderer!");
        }

        if (efeitoCoracoes != null)
        {
            efeitoCoracoes.SetActive(false);
        }
    }

    void Update()
    {
        float moveHorizontal = 0f;

        if (podeAndar && Keyboard.current != null)
        {
            
            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            {
                moveHorizontal = -1f;
                           
                if (spriteRenderer != null) spriteRenderer.flipX = true; 
                if (spriteCapacete != null) spriteCapacete.flipX = true;
            }
           
            else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            {
                moveHorizontal = 1f;
             
                if (spriteRenderer != null) spriteRenderer.flipX = false; 
                if (spriteCapacete != null) spriteCapacete.flipX = false;
            }
           
            if (Keyboard.current.spaceKey.wasPressedThisFrame && noChao)
            {
                rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
                noChao = false; 
            }
        }

       
        if (rb2d != null)
        {
            rb2d.linearVelocity = new Vector2(moveHorizontal * speedValue, rb2d.linearVelocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = true;
        }

        if (collision.gameObject.CompareTag("ObjetivoFinal"))
        {
            podeAndar = false;

            if (rb2d != null)
            {
                rb2d.linearVelocity = Vector2.zero;
            }

            if (efeitoCoracoes != null)
            {
                efeitoCoracoes.SetActive(true);
            }
        }
    }
}