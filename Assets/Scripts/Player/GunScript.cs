using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GunPivotScript Gun_moth;
    [SerializeField] private ReloadArmScript ReloadArm;
    [SerializeField] private Sprite Gun_pistol;
    [SerializeField] private Sprite Gun_rifle;
    [SerializeField] private Sprite Gun_shotgun;
    [SerializeField] private Sprite Gun_pistol_shot;
    [SerializeField] private Sprite Gun_rifle_shot;
    [SerializeField] private Sprite Gun_shotgun_shot;
    [SerializeField] private Sprite RifleNoMag;
    [SerializeField] private Sprite ShotgunNoMag;
    [SerializeField] private Sprite Shotgun_ccl;


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
            ReloadArm.ChangeLayer(99);
        }
        else {
            spriteRenderer.sortingOrder = 102;
            PlayerMainScript.Game_player.ChooseSideLookUpTrue(false);
            ReloadArm.ChangeLayer(101);
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

    public void ReloadRifle(float lenght)
    {
        spriteRenderer.sprite = RifleNoMag;
        Invoke("StopReloadRifle", lenght);
    }

    private void StopReloadRifle()
    {
        spriteRenderer.sprite = Gun_rifle;
    }

    public void ReloadShotgun(float lenght)
    {
        spriteRenderer.sprite = ShotgunNoMag;
        Invoke("StopReloadShotgun", lenght);
    }

    private void StopReloadShotgun()
    {
        spriteRenderer.sprite = Gun_shotgun;
    }

    public void StartShotPistol() {
        spriteRenderer.sprite = Gun_pistol_shot;
        Invoke("StopShotPistol", 0.1f);
    }

    private void StopShotPistol()
    {
        spriteRenderer.sprite = Gun_pistol;
    }

    public void StartShotRifle()
    {
        spriteRenderer.sprite = Gun_rifle_shot;
        Invoke("StopShotRifle", 0.1f);
    }

    private void StopShotRifle()
    {
        spriteRenderer.sprite = Gun_rifle;
    }

    public void StartShotShotgun()
    {
        spriteRenderer.sprite = Gun_shotgun_shot;
        Invoke("StopShotShotgun", 0.1f);
    }
    private void StopShotShotgun()
    {
        spriteRenderer.sprite = Gun_shotgun;
        Invoke("LoadShotgun", 0.4f);
    }

    private void LoadShotgun()
    {
        spriteRenderer.sprite = Shotgun_ccl;
        Invoke("StopLoadShotgun", 0.2f);
    }
    private void StopLoadShotgun()
    {
        spriteRenderer.sprite = Gun_shotgun;
    }
}
