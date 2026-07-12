using UnityEngine;

public class ArmsScript : MonoBehaviour
{
    [SerializeField] private ArmsPivotScript Arms_moth;

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
        }
        else
        {
            spriteRenderer.sortingOrder = 101;
        }
    }
}
