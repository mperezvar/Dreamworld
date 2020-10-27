using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad;
    public Animator animator;
    Rigidbody2D rb;
    Vector2 movimiento;

    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        movimiento = new Vector2(
           x,
           y
           );
        rb.MovePosition(rb.position + movimiento * velocidad * Time.deltaTime);
        animacion(x, y);
    }
    void animacion(float x, float y)
    {
        switch (y)
        {
            case 1.0f:
                animator.SetFloat("MovY", 2.0f);
                break;
            case -1.0f:
                animator.SetFloat("MovY", -2.0f);
                break;
            case 0.0f:
                animator.SetFloat("MovY", 0.0f);
                break;
            default:
                animator.SetFloat("MovY", 0.0f);
                break;
        }
        switch (x)
        {
            case 1.0f:
                animator.SetFloat("MovX", 2.0f);
                break;
            case -1.0f:
                animator.SetFloat("MovX", -2.0f);
                break;
            case 0.0f:
                animator.SetFloat("MovX", 0.0f);
                break;
            default:
                animator.SetFloat("MovX", 0.0f);
                break;
        }
    }
    public float GetVelocidad()
    {
        return velocidad;
    }
    public void SetVelocidad(float v)
    {
        velocidad = v;
    }

}
