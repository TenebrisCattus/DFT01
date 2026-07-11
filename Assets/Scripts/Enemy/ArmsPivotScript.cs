using UnityEngine;

public class ArmsPivotScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        Vector2 playerPos = PlayerMainScript.Game_player.transform.position;
        Vector2 dir = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y).normalized;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1 - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
