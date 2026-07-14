using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private float standartY;
    [SerializeField] private GameObject GunOrArms;
    [SerializeField] private Sprite StandartSprite;
    [SerializeField] private Sprite BlinkSprite;
    [SerializeField] private Sprite DamageSprite;
    [SerializeField] private float MaxTimeBetwenBlink;
    [SerializeField] private float MinTimeBetwenBlink;
    [SerializeField] private float MaxBlinkTime;
    [SerializeField] private float MinBlinkTime;

    private Transform GAtrans;
    private float change;

    void Start()
    {
        GAtrans = GunOrArms.transform;
    }

    void Update()
    {
        if (GAtrans.rotation.eulerAngles.z <= 90) {
            change = 0.05f * GAtrans.rotation.eulerAngles.z / 90;
        }
        else
        {
            change = 0;
        }
        transform.localPosition = new Vector3(transform.localPosition.x, standartY - change, transform.localPosition.z);
        Debug.Log(GAtrans.rotation.eulerAngles.z);
    }
}
