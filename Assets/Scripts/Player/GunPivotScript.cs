using UnityEngine;

public class GunPivotScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float ReloadDelay = 1;
    [SerializeField] private GunScript armsScript;
    // Pistol
    [SerializeField] private float PistolFireDelay = 0.4f;
    [SerializeField] static private int PistolMagazineMax = 8;
    // Rifle
    [SerializeField] private float RifleFireDelay = 0.2f;
    [SerializeField] static private int RifleMagazineMax = 30;

    //Inventory
    [SerializeField] private int RifleAmmo = 90;
    [SerializeField] private int PistolAmmo = 16;
    [SerializeField] private string Weapon = "wpn_pistol";

    private Camera mainCamera;
    private float nextFireTime;
    private float nextReloadTime;
    private int PistolMagazine = PistolMagazineMax;
    private int RifleMagazine = RifleMagazineMax;
    private Vector2 dir;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Техническое
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1 - 90;
        
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
            PlayerMainScript.Game_player.ChooseReverX(false);
        }
        else {
            transform.rotation = Quaternion.Euler(0, 180, 180-angle);
            PlayerMainScript.Game_player.ChooseReverX(true);
        }
        // Выбор оружия
        if (Input.GetAxis("Select1") > 0)
        {
            Weapon = "wpn_pistol";
        }
        else if (Input.GetAxis("Select2") > 0)
        {
            Weapon = "wpn_rifle";
        }
        else if (Input.GetAxis("Select3") > 0)
        {
            Weapon = "wpn_shotgun";
        }
        armsScript.ChooseSprite(Weapon);

        //Оружие  
        if (Weapon == "wpn_pistol")
        {
            if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
            {
                FirePistol(dir);
                nextFireTime = Time.time + PistolFireDelay;
            }
        }
        else if ((Weapon == "wpn_rifle") && (Input.GetAxis("Fire1") > 0) && (Time.time >= nextFireTime))
        {
            FireRifle(dir);
            nextFireTime = Time.time + RifleFireDelay;
        }

        if (Input.GetAxis("Reload") > 0)
        {   
            if(Weapon == "wpn_pistol" && Time.time >= nextReloadTime)
            {
                ReloadPistol(dir);
                nextReloadTime = Time.time + ReloadDelay;
            }
            else if(Weapon == "wpn_rifle" && Time.time >= nextReloadTime)
            {
                ReloadRifle(dir);
                nextReloadTime = Time.time + ReloadDelay;
            }
                     
        }
        Debug.Log("Текущее оружие: " + Weapon);
        Debug.Log("Патроны пистолет: " + PistolMagazine);
        Debug.Log("Патроны автомат: " + RifleMagazine);
    }
    private void FirePistol(Vector2 dir) {
        if (PistolMagazine > 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            PistolMagazine = PistolMagazine - 1;

        }
        

    }
    private void ReloadPistol(Vector2 dir)
    {
        int AmmoToReload = PistolMagazineMax - PistolMagazine;
        if((PistolAmmo - AmmoToReload) > 0)
        {
            PistolMagazine += AmmoToReload;
            PistolAmmo -= AmmoToReload;
        }
        else if(AmmoToReload >= PistolAmmo)
        {
            PistolMagazine += PistolAmmo;
            PistolAmmo = 0;
        }
        

    }

    private void FireRifle(Vector2 dir)
    {
        if (RifleMagazine > 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            RifleMagazine = RifleMagazine - 1;
        }
    }

    private void ReloadRifle(Vector2 dir)
    {
        int AmmoToReload = RifleMagazineMax - RifleMagazine;
        if ((RifleAmmo - AmmoToReload) > 0)
        {
            RifleMagazine += AmmoToReload;
            RifleAmmo -= AmmoToReload;
        }
        else if (AmmoToReload >= RifleAmmo)
        {
            RifleMagazine += RifleAmmo;
            RifleAmmo = 0;
        }
    }

    public Vector2 GetDir() {
        return dir;
    }
}
