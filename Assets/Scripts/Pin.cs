using UnityEngine;
using System.Collections;

// 핀핀
public class Pin : MonoBehaviour
{
    [SerializeField]
    private Transform hitEffectSpawnPoint;
    [SerializeField]
    private GameObject hitEffectPrefab;

    private Movement2D movement2D;

    public GameObject Apple_Spawner;
    public GameObject gameManager;
    public GameObject weaponEvolution;
    public GameObject PinSpawner;
    public GameObject SoundManager;

    public float damage;
    public float add_value = 10f;
    public bool isStuck = false;

    private void Start()
    {
        // Start에서 movement2D 캐싱
        movement2D = GetComponent<Movement2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pin"))
        {
            Pin otherPin = collision.GetComponent<Pin>();

            if (otherPin != null && otherPin.isStuck && !this.isStuck)
            {   
                SoundManager.GetComponent<SoundManager>().Knife.Play();
                movement2D.MoveTo(new Vector3(-1f, -1f, 0f));
                PinSpawner.GetComponent<PinSpawner>().enablepin = false;
                StartCoroutine(DelayedGameOver(0.5f));
            }
        }
        else if (collision.CompareTag("Target"))
        {
            // 💡 충돌 지점 계산
            Vector2 collisionPoint = collision.ClosestPoint(transform.position);

            // 💡 방향 벡터: 사과 중심 → 칼 위치
            Vector2 direction = ((Vector2)transform.position - (Vector2)collision.transform.position).normalized;

            // 💡 겹침 방지를 위한 미세 위치 보정
            float offset = 0.4f;
            Vector2 adjustedPosition = collisionPoint + direction * offset;

            // 💡 위치 이동
            transform.position = adjustedPosition;

            // 💡 움직임 정지
            movement2D.MoveTo(Vector3.zero);

            isStuck = true;
            transform.SetParent(collision.transform);
            collision.GetComponent<Target>().Hit();
            weaponEvolution.GetComponent<WeaponEvolution>().GainExp(10f);

            Instantiate(hitEffectPrefab, hitEffectSpawnPoint.position, hitEffectSpawnPoint.rotation);

            collision.GetComponent<Target>().ShakeApple();
            Apple_Spawner.GetComponent<Apple_Spawner>().Damage_Apple(weaponEvolution.GetComponent<WeaponEvolution>().Damage());
            SoundManager.GetComponent<SoundManager>().Shoot.Play();
        }
    }

    private IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.GetComponent<GameManager>().GameOver();
    }
}
