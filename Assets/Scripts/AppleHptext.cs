using UnityEngine;
using UnityEngine.UI;
//사과 hp표시기기
public class AppleHptext : MonoBehaviour
{
    public GameObject Apple_Spawner;       // Apple_Spawner 오브젝트 참조
    public Text applehptext;               // UI 텍스트 컴포넌트 참조

    private Apple_Spawner appleSpawnerScript; // Apple_Spawner 스크립트 캐싱

    public GameManager gameManager;

    void Start()
    {
        if (Apple_Spawner != null)
        {
            appleSpawnerScript = Apple_Spawner.GetComponent<Apple_Spawner>();
        }
    }

    void Update()
    {
        if (appleSpawnerScript != null && applehptext != null)
        {
            float current = appleSpawnerScript.Current_Hp;
            float max = appleSpawnerScript.Max_Hp;
            float boss = appleSpawnerScript.Boss_Hp;
            if (current <= 0f)
            {
                current = 0f;
            }
            if (gameManager.GetComponent<GameManager>().stagelevel % 5 == 0)
            applehptext.text =  $"{current:F1}/{boss:F1}";
             else   applehptext.text = $"{current:F1}/{max:F1}";
          
        }
    }
}
