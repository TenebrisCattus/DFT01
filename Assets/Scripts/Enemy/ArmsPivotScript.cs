using UnityEngine;

public class ArmsPivotScript : MonoBehaviour
{
    private Vector2 dir;
    void Start()
    {

    }

    void Update()
    {
        Vector2 playerPos = PlayerMainScript.Game_player.transform.position;
        dir = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y).normalized;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1 - 90;
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 180 - angle);
        }
    }

    public Vector2 GetDir()
    {
        return dir;
    }
}
