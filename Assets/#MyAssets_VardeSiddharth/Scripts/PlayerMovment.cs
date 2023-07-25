using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10;
    [SerializeField]
    float jumpSpeed = 20;
    [SerializeField]
    Transform raycastFrom;

    Rigidbody2D playerRB;
    Animator playerAnimator;
    SpriteRenderer playerSpriteRenderer;
    float horInput;
    bool isJumping;
    float maxXVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        if(horInput < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
        else
        {
            playerSpriteRenderer.flipX = false;
        }
        Debug.DrawRay(raycastFrom.position, Vector2.down * 0.2f,Color.black);
        if (Physics2D.Raycast(raycastFrom.position, Vector2.down, 0.15f))
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                playerAnimator.SetBool("Jumping", true);
            }
            else
            {
                playerAnimator.SetBool("Jumping", false);
            }
        }
        else
        {
            playerAnimator.SetBool("Jumping", true);
        }

        maxXVelocity = Mathf.Clamp(playerRB.velocity.x, -5, 5);
        playerRB.velocity = new Vector2(maxXVelocity, playerRB.velocity.y);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        playerRB.AddForce(Vector3.right * horInput * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        playerAnimator.SetFloat("Moving", horInput);

        if (isJumping)
        {
            playerRB.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
