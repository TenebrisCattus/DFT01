using UnityEngine;

public class RifleAmmoScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !(PlayerMainScript.Game_player.FullRifle))
        {
            PlayerMainScript.Game_player.RifleAmmoPickup();
            Destroy(gameObject);
        }
    }
}
