using System.Collections;
using UnityEngine;

public class ReloadArmScript : MonoBehaviour
{
    [SerializeField] private GunScript Gun;
    [SerializeField] private Sprite PistolMag;
    [SerializeField] private Sprite RifleMag;
    [SerializeField] private Sprite ShotgunMag;
    [SerializeField] private Sprite EmptyArm;

    private SpriteRenderer sprt;
    private Animator anim;

    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sprt.enabled = false;
    }

    void Update()
    {
        
    }

    public void PistolReloadAnim(float lenght)
    {
        sprt.enabled = true;
        transform.SetLocalPositionAndRotation(new Vector3(-0.173f, -0.123f, 0), transform.rotation);
        sprt.sprite = PistolMag;
        anim.SetTrigger("Pistol");
        StartCoroutine(DelayBeforeHide(lenght));
    }

    public void RifleReloadAnim(float lenght)
    {
        Gun.ReloadRifle(lenght);
        sprt.enabled = true;
        transform.SetLocalPositionAndRotation(new Vector3(-0.173f, -0.123f, 0), transform.rotation);
        sprt.sprite = RifleMag;
        anim.SetTrigger("Pistol");
        StartCoroutine(DelayBeforeHide(lenght));
    }

    public void ShotgunReloadAnim(float lenght)
    {
        Gun.ReloadShotgun(lenght);
        sprt.enabled = true;
        transform.SetLocalPositionAndRotation(new Vector3(-0.173f, -0.123f, 0), transform.rotation);
        sprt.sprite = EmptyArm;
        anim.SetTrigger("Shotgun");
        Invoke("ChangeReloadSprite", lenght/2);
        StartCoroutine(DelayBeforeHide(lenght));
    }

    IEnumerator DelayBeforeHide(float delay)
    {
        yield return new WaitForSeconds(delay);
        sprt.enabled = false;
    }

    public void ChangeLayer(int layer)
    {
        sprt.sortingOrder = layer;
    }

    private void ChangeReloadSprite()
    {
        sprt.sprite = ShotgunMag;
    }
}
