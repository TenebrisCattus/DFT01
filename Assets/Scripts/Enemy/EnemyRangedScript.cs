using UnityEngine;

public class EnemyRangedScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireDelay;

    private Vector3 playPos;
    private float nextTick;

    void Start()
    {
        
    }

    void Update()
    {
        playPos = PlayerMainScript.Game_player.transform.position;
        if (Vector3.Distance(playPos, transform.position) <= 5 && Time.time >= nextTick)
        {
            Attack();
            nextTick = Time.time + fireDelay;
        }
    }

    private void Attack()
    {
        Vector2 dir = new Vector2(playPos.x - transform.position.x, playPos.y - transform.position.y).normalized;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1 - 90;
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
    }
}
