using UnityEngine;

public class GunPivotScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireDelay;
    [SerializeField] private float ReloadDelay;
    [SerializeField] private float LoadTime;
    [SerializeField] static private int PistolMagazineMax = 8;
    [SerializeField] private int PistolAmmo = 16;

    private Camera mainCamera;
    private float nextFireTime;
    private float nextReloadTime;
    int PistolMagazine = PistolMagazineMax;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1 - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Input.GetAxis("Fire1") > 0 && Time.time >= nextFireTime)
        {
            FirePistol(dir);
            nextFireTime = Time.time + fireDelay;
        }
        if (Input.GetAxis("Reload") > 0 && Time.time >= nextReloadTime)
        {   
            if(Time.time >= LoadTime)
            {
                ReloadPistol(dir);
                nextReloadTime = Time.time + ReloadDelay;
            }           
        }
        Debug.Log("Все патроны: " + PistolAmmo);
        Debug.Log("Магазин: " + PistolMagazine);
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
}
