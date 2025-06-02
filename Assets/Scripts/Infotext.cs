using UnityEngine;
using UnityEngine.UI;

public class Infotext : MonoBehaviour
{

    public bool level;
    public bool raredamage;
    public bool xp;

    public bool dia;

    Text leveltext;

    Text raredamagetext;

    Text  xptext;
    Text DiaText; // UI 텍스트
    public WeaponEvolution wp;
    public Diamond diamond;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leveltext = GetComponent<Text>();
        raredamagetext = GetComponent<Text>();
        xptext = GetComponent<Text>();
        DiaText = GetComponent<Text>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if (raredamage)
        {
            raredamagetext.text = "칼: " + wp.WeaponName() + "\n공격력: " + wp.Damage();
        }
        if (xp)
        {
            xptext.text = wp.currentExp.ToString("F0") + "xp /" + wp.expPerLevel.ToString("F0") + "xp";
        }
        if (level)
        {
            leveltext.text = "Lv. " + wp.currentLevel.ToString("F0");
        }
        if (dia)
        {
            DiaText.text = diamond.Diamonds.ToString("F0");
        }

    }
}
