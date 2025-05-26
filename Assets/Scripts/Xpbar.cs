using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public WeaponEvolution weaponEvolution; // WeaponEvolution 스크립트를 참조
    public Slider xpSlider;                // 경험치 표시용 슬라이더

    void Start()
    {
        if (weaponEvolution == null)
        {
            Debug.LogError("WeaponEvolution 참조가 없습니다.");
            return;
        }

        if (xpSlider == null)
        {
            Debug.LogError("XP Slider가 설정되지 않았습니다.");
            return;
        }

        xpSlider.maxValue = weaponEvolution.expPerLevel;
        xpSlider.value = weaponEvolution.currentExp;
    }

    void Update()
    {
        // 현재 경험치 반영
        xpSlider.maxValue = weaponEvolution.expPerLevel;
        xpSlider.value = weaponEvolution.currentExp;
    }
}
