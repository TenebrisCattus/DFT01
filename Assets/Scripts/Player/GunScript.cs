using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GunPivotScript Gun_moth;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Gun_moth.GetDir().y > 0)
        {
            spriteRenderer.sortingOrder = 99;
            PlayerMainScript.Game_player.ChooseSideLookUpTrue(true);
        }
        else {
            spriteRenderer.sortingOrder = 101;
            PlayerMainScript.Game_player.ChooseSideLookUpTrue(false);
        }
    }
}
