using UnityEngine;
using UnityEngine.UI;

public class Infotext : MonoBehaviour
{


    public Text leveltext;

    public Text raredamagetext;

    public Text  xptext;

    public WeaponEvolution wp;


    void Update()
    {
            raredamagetext.text = "칼: " + wp.WeaponName() +  "\n공격력: " + wp.Damage();
            xptext.text = wp.currentExp.ToString("F0") + "xp /" + wp.expPerLevel.ToString("F0") + "xp";
            leveltext.text = "Lv. " + wp.currentLevel.ToString("F0");
    }
}
