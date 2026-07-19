using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseScript : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float PathUpdateRate;
    [SerializeField] private GameObject Eyes;
    [SerializeField] private Sprite LookUp;
    [SerializeField] private Sprite LookDown;
    [SerializeField] private SpriteRenderer rbSprite;

    private NavMeshAgent agent;
    private float nextUpdateTime;
    private Animator mainAnim;
    private Rigidbody2D rb;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        mainAnim = rbSprite.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        if (agent.velocity.magnitude > 0)
        {
            mainAnim.SetBool("Walk", true);
        }
        else 
        {
            mainAnim.SetBool("Walk", false);
        }

    }

    public void DamageDeal(float damage)
    {
        HP -= damage;
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
