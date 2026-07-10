using UnityEngine;

public class GunPivotScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireDelay;

    private Camera mainCamera;
    private float nextFireTime;

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
        if (Input.GetAxis("Fire1") > 0 && Time.time >= nextFireTime) {
            Fire(dir);
            nextFireTime = Time.time + fireDelay;
        }
    }
    private void Fire(Vector2 dir) {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
