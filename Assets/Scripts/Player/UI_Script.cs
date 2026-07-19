using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    [SerializeField] private GunPivotScript GunSystem;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public int HP;
    
    void Start()
    {
    }

    public void Update()
    {
        // Çהמנמגüו
        HP = PlayerMainScript.Game_player.HP;
        HPText.text = HP.ToString();
        switch (PlayerMainScript.Game_player.wea)
        {
            case "wpn_pistol":
                AmmoText.text = PlayerMainScript.Game_player.pimag.ToString() + " / " + PlayerMainScript.Game_player.piall.ToString();
                break;
            case "wpn_rifle":
                AmmoText.text = PlayerMainScript.Game_player.rimag.ToString() + " / " + PlayerMainScript.Game_player.riall.ToString();
                break;
            case "wpn_shotgun":
                AmmoText.text = PlayerMainScript.Game_player.shmag.ToString() + " / " + PlayerMainScript.Game_player.shall.ToString();
                break;
        }
        ScoreText.text = PlayerMainScript.Game_player.score.ToString();
        HighScoreText.text = PlayerMainScript.Game_player.highscore.ToString();

    }
}
