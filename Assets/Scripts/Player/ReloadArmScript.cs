using UnityEngine;

public class ReloadArmScript : MonoBehaviour
{
    [SerializeField] private Sprite PistolMag;
    [SerializeField] private Sprite RifleMag;
    [SerializeField] private Sprite ShotgunMag;

    private SpriteRenderer sprt;
    private Animator anim;

    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void PistolReloadAnim()
    {
        transform.SetLocalPositionAndRotation(new Vector3(-0.173f, -0.123f, 0), transform.rotation);
        sprt.sprite = PistolMag;
        anim.SetTrigger("Pistol");
    }

    public void RifleReloadAnim()
    {

    }

    public void ShoygunReloadAnim()
    {

    }
}
