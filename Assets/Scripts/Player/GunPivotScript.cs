using UnityEngine;

public class GunPivotScript : MonoBehaviour
{
    


    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private ReloadArmScript arm;
    // Pistol
    [SerializeField] private float PistolFireDelay = 0.4f;
    [SerializeField] static private int PistolMagazineMax = 8;
    // Rifle
    [SerializeField] private float RifleFireDelay = 0.2f;
    [SerializeField] static private int RifleMagazineMax = 30;
    // Shotgun
    [SerializeField] static private int ShotgunMagazineMax = 6;
    [SerializeField] private float ShotgunFireDelay = 0.6f;
    //Inventory
    [SerializeField] public static int RifleAmmoMax = 90;
    [SerializeField] public static int PistolAmmoMax = 24;
    [SerializeField] public static int ShotgunAmmoMax = 36;
    [SerializeField] public string Weapon = "wpn_pistol";

    //Sounds
    [SerializeField] private AudioClip FirePistolSound;
    [SerializeField] private AudioClip FireRifleSound;
    [SerializeField] private AudioClip FireShotgunSound;

    public static GunPivotScript Game_Gun { get; private set; }


    private Camera mainCamera;
    private AudioSource AudioSource;

    public int RifleAmmo = RifleAmmoMax;
    public int PistolAmmo = PistolAmmoMax;
    public int ShotgunAmmo = ShotgunAmmoMax;

    private float nextFireTime;
    private float nextReloadTime;
    public int PistolMagazine = PistolMagazineMax;
    public int RifleMagazine = RifleMagazineMax;
    public int ShotgunMagazine = ShotgunMagazineMax;
    private Vector2 dir;
    private Animator GunAnim;
    private float ToLoad;
    private bool IsBusy;
    private Sprite GunSprt;
    private GunScript GunScrip;
    //private bool NextAmmo = true;
    void Start()
    {
        mainCamera = Camera.main;
        AudioSource = GetComponent<AudioSource>();
        GunAnim = Gun.GetComponent<Animator>();
        GunScrip = Gun.GetComponent<GunScript>();
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
        if (Input.GetAxis("Select1") > 0 && !IsBusy)
        {
            Weapon = "wpn_pistol";
        }
        else if (Input.GetAxis("Select2") > 0 && !IsBusy)
        {
            Weapon = "wpn_rifle";
        }
        else if (Input.GetAxis("Select3") > 0 && !IsBusy)
        {
            Weapon = "wpn_shotgun";
        }

        //Оружие  
        if (Weapon == "wpn_pistol" && !IsBusy)
        {
            if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
            {
                FirePistol(dir);
                nextFireTime = Time.time + PistolFireDelay;
            }
        }
        else if ((Weapon == "wpn_rifle") && (Input.GetAxis("Fire1") > 0) && (Time.time >= nextFireTime) && !IsBusy)
        {
            FireRifle(dir);
            nextFireTime = Time.time + RifleFireDelay;
        }
        else if ((Weapon == "wpn_shotgun") && (Input.GetAxis("Fire1") > 0) && (Time.time >= nextFireTime) && !IsBusy)
        {
            FireShotgun(dir);
            nextFireTime = Time.time + ShotgunFireDelay;
        }

        if (Input.GetAxis("Reload") > 0 && !IsBusy)
        {
            
            if(Weapon == "wpn_pistol" && Time.time >= nextReloadTime && !IsBusy)
            {
                IsBusy = true;
                arm.PistolReloadAnim(1);
                ToLoad = 0.6f;
                Invoke("ReloadPistol", ToLoad);

            }
            else if(Weapon == "wpn_rifle" && Time.time >= nextReloadTime && !IsBusy)
            {
                IsBusy = true;
                arm.RifleReloadAnim(1);
                ToLoad = 0.9f;
                Invoke("ReloadRifle", ToLoad);
                
            }
            else if (Weapon == "wpn_shotgun" && Time.time >= nextReloadTime && !IsBusy && ShotgunAmmo > 0)
            {
                IsBusy = true;
                
                ReloadShotgun();
                
                
            }

        }

        //Debug.Log("Патроны Дробовик:" + ShotgunAmmo);
        //Debug.Log("Патроны Винтовка:" + RifleAmmo);
        //Debug.Log("Патроны Пистолет:" + PistolAmmo);

    }
    private void FirePistol(Vector2 dir) {
        if (PistolMagazine > 0)
        {
            GunScrip.StartShotPistol();
            Instantiate(bullet, transform.position, transform.rotation);
            PistolMagazine = PistolMagazine - 1;
            AudioSource.PlayOneShot(FirePistolSound);
            GunAnim.SetTrigger("Shoot");
        }
        

    }
    private void ReloadPistol()
    {
        int AmmoToReload = PistolMagazineMax - PistolMagazine;
        if((PistolAmmo - AmmoToReload) > 0)
        {
            PistolMagazine += AmmoToReload;
            PistolAmmo -= AmmoToReload;
            nextReloadTime = Time.time + 0.5f;
            IsBusy = false;
        }
        else if(AmmoToReload >= PistolAmmo)
        {
            PistolMagazine += PistolAmmo;
            PistolAmmo = 0;
            nextReloadTime = Time.time + 0.5f;
            IsBusy = false;
        }
    }

    private void FireRifle(Vector2 dir)
    {
        if (RifleMagazine > 0)
        {
            GunScrip.StartShotRifle();
            Instantiate(bullet, transform.position, transform.rotation);
            RifleMagazine = RifleMagazine - 1;
            AudioSource.PlayOneShot(FireRifleSound);
            GunAnim.SetTrigger("ShootRifle");
        }
    }

    private void ReloadRifle()
    {
        int AmmoToReload = RifleMagazineMax - RifleMagazine;
        if ((RifleAmmo - AmmoToReload) > 0)
        {
            RifleMagazine += AmmoToReload;
            RifleAmmo -= AmmoToReload;
            nextReloadTime = Time.time + 0.5f;
            IsBusy = false;
        }
        else if (AmmoToReload >= RifleAmmo)
        {
            RifleMagazine += RifleAmmo;
            RifleAmmo = 0;
            nextReloadTime = Time.time + 0.5f;
            IsBusy = false;
        }
    }
    private void FireShotgun(Vector2 dir)
    {
        if (ShotgunMagazine > 0)
        {
            GunScrip.StartShotShotgun();
            ShotgunMagazine -= 1;
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0,0,-10) );
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, 10));
            Instantiate(bullet, transform.position, transform.rotation);
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, -20));
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, 20));
            AudioSource.PlayOneShot(FireShotgunSound);
            GunAnim.SetTrigger("Shoot");
        }
    }


    public Vector2 GetDir() {
        return dir;
    }
    private void ReloadShotgun()
    {
        IsBusy = true;
        if (ShotgunMagazine < ShotgunMagazineMax && ShotgunAmmo > 0)
        {
            arm.ShotgunReloadAnim(0.2f);
            IsBusy = true;
            ShotgunMagazine += 1;
            ShotgunAmmo -= 1;
            Invoke("ReloadShotgun", 0.3f);
        }
        else
        {
            IsBusy=false;
        }
    }
    public string GetWeaponName() { return Weapon; }
}
