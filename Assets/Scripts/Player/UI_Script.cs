using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    [SerializeField] private GunPivotScript GunSystem;
    public TextMeshProUGUI HPText;
    public int HP;
    
    void Start()
    {
    }

    public void Update()
    {
        // Çהמנמגüו
        HP = PlayerMainScript.Game_player.HP;
        HPText.text = HP.ToString();
    }
}
