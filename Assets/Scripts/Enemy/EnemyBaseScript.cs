using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseScript : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float PathUpdateRate;

    private NavMeshAgent agent;
    private float nextUpdateTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (HP <= 0) {
            Death();
        }
        if (Time.time >= nextUpdateTime && PlayerMainScript.Game_player != null) {
            FindTheWayToPlayer();
            nextUpdateTime = Time.time + PathUpdateRate;
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

    void FindTheWayToPlayer() {
        agent.SetDestination(PlayerMainScript.Game_player.transform.position);
    }
}
