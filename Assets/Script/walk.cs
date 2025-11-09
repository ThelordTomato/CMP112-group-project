using UnityEngine;
using UnityEngine.InputSystem;

public class walk : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput;
    public float moveSpeed = 5f;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent <Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = movementInput * moveSpeed;

    
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);
        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("lastInputX", movementInput.x);
            animator.SetFloat("lastInputY", movementInput.y);

        }
        movementInput = context.ReadValue<Vector2>();
        animator.SetFloat("inputX", movementInput.x);
        animator.SetFloat("inputY", movementInput.y);

    }


    //lets the walls and anything tagged "outoffbounds" be unable to pass through
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "outoffbounds")
        {
            rb.linearVelocity = -(rb.linearVelocity);
        }
    }
}

