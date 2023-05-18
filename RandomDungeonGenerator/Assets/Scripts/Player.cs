using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerRigidBody;
    Transform playerSprite;

    [SerializeField] float runSpeed = 0.01f; 
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody  = GetComponent<Rigidbody2D>();
        playerSprite = GetComponentInChildren<SpriteRenderer>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput =value.Get<Vector2>();
    }

    void Run()
    {
        //FlipSprite();
        Vector2 moveVelocity = new Vector2(moveInput.x * runSpeed, moveInput.y * runSpeed);
        playerRigidBody.velocity = moveVelocity;
    }

    void FlipSprite()
    {
        bool playerHorizontalSpeed = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHorizontalSpeed)
        {
            playerSprite.localScale = new Vector2(-Mathf.Sign(playerRigidBody.velocity.x), 1f);
        }
    }
}
