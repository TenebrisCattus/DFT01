using UnityEngine;

public class ArmsScript : MonoBehaviour
{
    [SerializeField] private ArmsPivotScript Arms_moth;
    [SerializeField] private EnemyBaseScript MotherEnemy;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Arms_moth.GetDir().y > 0)
        {
            spriteRenderer.sortingOrder = 99;
            MotherEnemy.ChooseSideLookUpTrue(true);
        }
        else
        {
            spriteRenderer.sortingOrder = 101;
            MotherEnemy.ChooseSideLookUpTrue(false);
        }
    }
}
