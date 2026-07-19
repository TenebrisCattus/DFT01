using System.IO;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.GraphicsBuffer;

public class ArmsPivotScript : MonoBehaviour
{
    [SerializeField] private EnemyBaseScript MotherEnemy;
    [SerializeField] private bool isshield;
    private Vector2 dir;
    private float angle;
    private float targetangle;

    void Start()
    {
        if (isshield)
        {
            Invoke("GetAngle", 1f);
        }
    }

    void Update()
    {
        if (isshield)
        {
            angle = Mathf.Lerp(angle, targetangle, 2f);
        }
        else
        {
            GetAngle();
        }
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
            MotherEnemy.ChooseReverX(false);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 180 - angle);
            MotherEnemy.ChooseReverX(true);
        }
    }

    public Vector2 GetDir()
    {
        return dir;
    }

    public void GetAngle() {
        Vector2 playerPos = PlayerMainScript.Game_player.transform.position;
        dir = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y).normalized;
        if (isshield) {
            targetangle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1 - 90;
            Invoke("GetAngle", 1f);
        }
        else
        {
            angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1 - 90;
        }
    }
}
