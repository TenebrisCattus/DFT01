using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private int speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right*speed*-1);
        Destroy(gameObject, 3);
    }

    void Update()
    {
        
    }
}
