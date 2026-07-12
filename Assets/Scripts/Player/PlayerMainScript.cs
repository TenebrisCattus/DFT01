using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMainScript : MonoBehaviour
{
    [SerializeField] private GameObject Eyes;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Sprite LookUp;
    [SerializeField] private Sprite LookDown;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer rbSprite;

    public static PlayerMainScript Game_player { get; private set; }

    private void Awake()
    {
        if (Game_player == null)
        {
            Game_player = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
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

    public void ChooseSideLookUpTrue(bool lookup) {
        if (lookup)
        {
            rbSprite.sprite = LookUp;
            Eyes.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            rbSprite.sprite = LookDown;
            Eyes.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void ChooseReverX(bool rever) {
        rbSprite.flipX = rever;
        if (rever)
        {
            Eyes.transform.localPosition = new Vector3(0.164f, Eyes.transform.localPosition.y, 0);
        }
        else {
            Eyes.transform.localPosition = new Vector3(-0.148f, Eyes.transform.localPosition.y, 0);
        }
    }
}
