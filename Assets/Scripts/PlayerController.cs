/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimentação
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement; // Vetor de direção de movimento

    void Update()
    {
        // Captura a entrada do jogador (em cada frame)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Atualiza imediatamente os parâmetros de animação
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);  // Atualiza a "velocidade" da animação com base no movimento
    }

    void FixedUpdate()
    {
        // Aplica o movimento ao Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    private Vector2 moveInput;
    public Animator animator;

    public Rigidbody2D rigidBody;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed, 0f);

        
        //----------------------------
        // Atualiza imediatamente os parâmetros de animação
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);  // Atualiza a "velocidade" da animação com base no movimento
        //----------------------------

        rigidBody.velocity = moveInput * moveSpeed;
    }

        void FixedUpdate()
    {
        // Aplica o movimento ao Rigidbody2D
        rigidBody.MovePosition(rigidBody.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}

