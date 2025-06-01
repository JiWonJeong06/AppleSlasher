using UnityEngine;
using UnityEngine.UI;
//경험치 바바
public class XpBar : MonoBehaviour
{
    public WeaponEvolution weaponEvolution; // WeaponEvolution 스크립트를 참조
    public Slider xpSlider;                // 경험치 표시용 슬라이더

    void Start()
    {
        xpSlider.maxValue = weaponEvolution.expPerLevel;
        xpSlider.value = weaponEvolution.currentExp;
    }

    void Update()
    {
        xpSlider.maxValue = weaponEvolution.expPerLevel;
        xpSlider.value = weaponEvolution.currentExp;
    }
}
