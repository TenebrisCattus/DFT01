using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GunPivotScript Gun_moth;
    [SerializeField] private Sprite Gun_pistol;
    [SerializeField] private Sprite Gun_rifle;
    [SerializeField] private Sprite Gun_shotgun;

    private SpriteRenderer spriteRenderer;
    private string weapon;
    private string prevweapon;

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
        weapon = Gun_moth.GetWeaponName();
        if (weapon != prevweapon) {
            ChooseSprite(weapon);
            prevweapon = weapon;
        }
    }

    private void ChooseSprite(string weapon) {
        switch (weapon) {
            case "wpn_pistol":
                spriteRenderer.sprite = Gun_pistol;
                break;
            case "wpn_rifle":
                spriteRenderer.sprite = Gun_rifle;
                break;
            case "wpn_shotgun":
                spriteRenderer.sprite = Gun_shotgun;
                break;
        }
    }
}
