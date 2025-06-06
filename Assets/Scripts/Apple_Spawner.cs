using UnityEngine;
using System.Collections;

public class Apple_Spawner : MonoBehaviour
{
    public GameObject apple_prefab;
    public GameObject apple_inst;

    public GameObject Diamond;
    public GameObject pinspawner;

    public float Apple_Hp_Bar;
    public float Current_Hp;

    public float Max_Hp;
    public float Boss_Hp;

    public GameObject gameManager;
    public AppleDestructionEffect ade;

    public GameObject SoundManager;

    private float lastNormalStageHp = 50f;

    void Start()
    {
        lastNormalStageHp = 50f;
        pinspawner.GetComponent<PinSpawner>().enablepin = false; // 시작 시 비활성화
        StartCoroutine(SpawnFirstApple());
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    IEnumerator SpawnFirstApple()
    {
        Apple_Spawn(); // 사과 생성
        yield return StartCoroutine(ScaleUpApple(apple_inst)); // 스케일 애니메이션
        yield return new WaitForSeconds(0.1f); // 약간의 텀
        pinspawner.GetComponent<PinSpawner>().enablepin = true; // 그 후 핀 활성화
    }

    public void Apple_Spawn()
    {
        apple_inst = Instantiate(apple_prefab, new Vector3(0, 0.5f, 0), Quaternion.identity);
        apple_inst.transform.localScale = Vector3.zero;

        int stageLevel = gameManager.GetComponent<GameManager>().stagelevel;

        if (stageLevel % 5 == 0 && stageLevel != 0)
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

    IEnumerator ScaleUpApple(GameObject apple)
    {
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = new Vector3(4f, 4f, 0f);
        float duration = 0.4f;
        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;
            t = Mathf.SmoothStep(0, 1, t);
            apple.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            time += Time.deltaTime;
            yield return null;
        }

        apple.transform.localScale = endScale;
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
                pinspawner.GetComponent<PinSpawner>().enablepin = false;
                SoundManager.GetComponent<SoundManager>().Boom.Play();
                Destroy(apple_inst);
                ade.PlayDestructionEffect();

                int stageLevel = gameManager.GetComponent<GameManager>().stagelevel;
                Diamond.GetComponent<Diamond>().AddDiamondsForStageClear(stageLevel);

                if ((stageLevel + 1) % 5 != 0)
                {
                    lastNormalStageHp += 5f;
                }

                gameManager.GetComponent<GameManager>().stagelevel += 1;
                StartCoroutine(Next_Round());
            }
        }
    }

    IEnumerator Next_Round()
    {
        yield return new WaitForSeconds(0.1f);
        Apple_Spawn();
        yield return StartCoroutine(ScaleUpApple(apple_inst));
        yield return new WaitForSeconds(0.1f);
        pinspawner.GetComponent<PinSpawner>().enablepin = true;
    }
}
