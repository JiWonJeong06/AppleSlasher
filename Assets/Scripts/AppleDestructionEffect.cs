using UnityEngine;

public class AppleDestructionEffect : MonoBehaviour
{
    public GameObject[] appleParts;     // 4등분 사과 프리팹
    public GameObject knife;            // 박힌 칼
    public Transform spawnPoint;        // 분해 위치

    public void PlayDestructionEffect()
    {


        foreach (var part in appleParts)
        {
            GameObject piece = Instantiate(part, spawnPoint.position, Quaternion.identity);
            var rb = piece.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(new Vector2(Random.Range(-1f, 1f), 1f) * 300f);
                rb.AddTorque(Random.Range(-300f, 300f));
            }
        }

        // 칼 떨어뜨리기
    
    }
}
