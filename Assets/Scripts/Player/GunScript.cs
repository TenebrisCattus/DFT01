using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private Transform gun_trns;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (180-gun_trns.eulerAngles.z < 0)
        {
            spriteRenderer.sortingOrder = 99;
        }
        else {
            spriteRenderer.sortingOrder = 101;
        }
    }
}
