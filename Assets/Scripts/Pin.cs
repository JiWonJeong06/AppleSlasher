using UnityEngine;
using System.Collections;

//핀핀
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
    private Rigidbody2D rb;

    public float damage;

    public float add_value = 10f;


    public bool isStuck = false;

    private void Update()

    {

        movement2D = GetComponent<Movement2D>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Pin"))
        {
            // 충돌한 칼의 Pin 스크립트 가져오기
            Pin otherPin = collision.GetComponent<Pin>();

            // 만약 상대 칼이 박힌 상태면, 현재 칼이 박힌 상태가 아니어야 튕겨 나가게 하자
            if (otherPin != null && otherPin.isStuck && !this.isStuck)
            {
                movement2D.MoveTo(new Vector3(-1f, -1f, 0f));
                StartCoroutine(DelayedGameOver(0.5f));
            }
        }
        else if (collision.CompareTag("Target"))
        {
            movement2D.MoveTo(Vector3.zero);

            // 박힌 상태 true 설정
            isStuck = true;

            transform.SetParent(collision.transform);
            collision.GetComponent<Target>().Hit();
            weaponEvolution.GetComponent<WeaponEvolution>().GainExp(10f);

            Instantiate(hitEffectPrefab, hitEffectSpawnPoint.position, hitEffectSpawnPoint.rotation);

            collision.GetComponent<Target>().ShakeApple();
            Apple_Spawner.GetComponent<Apple_Spawner>().Damage_Apple(weaponEvolution.GetComponent<WeaponEvolution>().Damage());
        }
    }
    private IEnumerator DelayedGameOver(float delay)
{
    yield return new WaitForSeconds(delay);
    gameManager.GetComponent<GameManager>().GameOver();
}
}