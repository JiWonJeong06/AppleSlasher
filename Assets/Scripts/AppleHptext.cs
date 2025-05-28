using UnityEngine;
using UnityEngine.UI;

public class AppleHptext : MonoBehaviour
{
    public GameObject Apple_Spawner;       // Apple_Spawner 오브젝트 참조
    public Text applehptext;               // UI 텍스트 컴포넌트 참조

    private Apple_Spawner appleSpawnerScript; // Apple_Spawner 스크립트 캐싱

    void Start()
    {
        // Apple_Spawner 스크립트를 미리 가져와 캐싱
        if (Apple_Spawner != null)
        {
            appleSpawnerScript = Apple_Spawner.GetComponent<Apple_Spawner>();
        }

        if (applehptext == null)
        {
            Debug.LogWarning("AppleHptext: applehptext(UI Text)가 설정되지 않았습니다.");
        }
    }

    void Update()
    {
        if (appleSpawnerScript != null && applehptext != null)
        {
            float current = appleSpawnerScript.Current_Hp;
            float max = appleSpawnerScript.Max_Hp;
            if (current <= 0f)
            {
                current = 0f;
            }
            // 형식: 75 / 100 또는 퍼센트: 75%
            applehptext.text = $"{current:F1}/{max:F1}";
          
        }
    }
}
