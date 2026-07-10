using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMainScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        if (moveInput.sqrMagnitude > 1)
        {
            moveInput.Normalize();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity += moveInput * moveSpeed;
    }
}
