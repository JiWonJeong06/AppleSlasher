using UnityEngine;
using UnityEngine.UI;

public class Infotext : MonoBehaviour
{

    public bool level;
    public bool raredamage;
    public bool xp;

    Text leveltext;

    Text raredamagetext;

    Text  xptext;

    public WeaponEvolution wp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leveltext = GetComponent<Text>();
        raredamagetext = GetComponent<Text>();
        xptext = GetComponent<Text>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if (raredamage)
        {
            raredamagetext.text = "칼: " + wp.WeaponName() +  "\n공격력: " + wp.Damage();
        }
        if (xp)
        {
            xptext.text = wp.currentExp.ToString("F0") + "xp /" + wp.expPerLevel.ToString("F0") + "xp";
        }
        if (level)
        {
            leveltext.text = "Lv. " + wp.currentLevel.ToString("F0");
        }

    }
}
