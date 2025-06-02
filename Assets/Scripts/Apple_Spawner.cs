using UnityEngine;
using System.Collections;

public class Apple_Spawner : MonoBehaviour
{
    public GameObject apple_prefab;
    public GameObject apple_inst;

    public GameObject Diamond;

    public float Apple_Hp_Bar;       // 현재 사과 체력
    public float Current_Hp;         // UI 표시용 현재 체력

    public float Max_Hp;             // 일반 스테이지 최대 체력
    public float Boss_Hp;            // 보스 스테이지 최대 체력

    public GameObject gameManager;
    public AppleDestructionEffect ade;

    private float lastNormalStageHp = 50f; // 일반 스테이지 기본 시작 체력

    void Start()
    {
        lastNormalStageHp = 50f; // 초기 체력 세팅
        Apple_Spawn();

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    public void Apple_Spawn()
    {
        apple_inst = Instantiate(apple_prefab, new Vector3(0, 0.5f, 0), Quaternion.identity);

        int stageLevel = gameManager.GetComponent<GameManager>().stagelevel;

        if (stageLevel % 5 == 0 && stageLevel != 0) // 보스 스테이지 (stageLevel 0 예외 처리)
        {
            Boss_Hp = lastNormalStageHp + 15f;
            Apple_Hp_Bar = Boss_Hp;
        }
        else
        {
            Max_Hp = lastNormalStageHp;
            Apple_Hp_Bar = Max_Hp;
        }

        Current_Hp = Apple_Hp_Bar;
    }

    public void Damage_Apple(float Damage)
    {
        Apple_Hp_Bar -= Damage;
    }

    void Update()
    {
        if (apple_inst != null)
        {
            Current_Hp = Apple_Hp_Bar;

            if (Apple_Hp_Bar <= 0)
            {
                Destroy(apple_inst);
                ade.PlayDestructionEffect();
                int stageLevel = gameManager.GetComponent<GameManager>().stagelevel;
                Diamond.GetComponent<Diamond>().AddDiamondsForStageClear(stageLevel);
                // 다음 스테이지가 보스가 아니면 lastNormalStageHp 증가
                if ((stageLevel + 1) % 5 != 0)
                {
                    lastNormalStageHp += 5f;
                }
                gameManager.GetComponent<GameManager>().stagelevel += 1;

                StartCoroutine(Next_Round());
            }
        }
    }
    IEnumerator Waittime(float time)
    {
        yield return new WaitForSeconds(time);
    }
    IEnumerator Next_Round()
    {
        yield return Waittime(0.5f);
        Apple_Spawn();
    }
}
