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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyMelee"))
        {
            collision.gameObject.GetComponent<EnemyBaseScript>().DamageDeal(0.5f);
        }
        Destroy(gameObject, 0.01f);
    }
}
