using System;
using UnityEngine;

public class MoveNinja : MonoBehaviour
{
    [Header("Movimentação do ninja")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float velocity = 5;
    private float horizontalMove;
    [Header("Configuração do pulo ninja")]
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float gravityScale = 1;
    [SerializeField] private Transform detectGround;
    private bool isGround;
    [SerializeField] private LayerMask groundLayer;
    private bool isJumpButtonPressed;

    
    void Update()
    {
        rb.gravityScale = gravityScale;
        horizontalMove = Input.GetAxis("Horizontal");
        isJumpButtonPressed = Input.GetButtonDown("Jump");

        if(isGround && isJumpButtonPressed) {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate () {
        isGround = Physics2D.OverlapCircle(detectGround.position, 0.3f, groundLayer);
        rb.velocity = new Vector2(horizontalMove * velocity, rb.velocity.y);
    }
}
