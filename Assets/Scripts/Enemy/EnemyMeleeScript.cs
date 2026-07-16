using UnityEngine;

public class EnemyMeleeScript : MonoBehaviour
{
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
        Debug.LogError("SADASD");
        if (collision.gameObject.CompareTag("Player2"))
        {
            PlayerMainScript.Game_player.HP -= 35;
        }
    }
}
