using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseScript : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float PathUpdateRate;
    [SerializeField] private GameObject Eyes;
    [SerializeField] private Sprite LookUp;
    [SerializeField] private Sprite LookDown;

    private NavMeshAgent agent;
    private float nextUpdateTime;
    private SpriteRenderer rbSprite;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rbSprite = GetComponent<SpriteRenderer>();
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

    public void ChooseSideLookUpTrue(bool lookup)
    {
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

    public void ChooseReverX(bool rever)
    {
        rbSprite.flipX = rever;
        if (rever)
        {
            Eyes.transform.localPosition = new Vector3(0.164f, Eyes.transform.localPosition.y, 0);
        }
        else
        {
            Eyes.transform.localPosition = new Vector3(-0.148f, Eyes.transform.localPosition.y, 0);
        }
    }
}
