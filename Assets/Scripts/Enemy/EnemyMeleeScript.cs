using UnityEngine;

public class EnemyMeleeScript : MonoBehaviour
{
    private float nextHitTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time >= nextHitTime)
        {
            PlayerMainScript.Game_player.HP -= 35;
            nextHitTime = Time.time + 0.7f;
        }
    }
}
