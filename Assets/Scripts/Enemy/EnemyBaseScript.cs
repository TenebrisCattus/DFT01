using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{
    [SerializeField] float HP;

    void Start()
    {
        
    }

    void Update()
    {
        if (HP <= 0) {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet")) {
            HP -= 0.5f;
        }
    }

    void Death() { 
        Destroy(gameObject);
    }
}
