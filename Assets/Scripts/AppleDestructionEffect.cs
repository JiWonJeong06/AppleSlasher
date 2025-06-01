using UnityEngine;
//사과 4등분 쪼깸 애니메이션션
public class AppleDestructionEffect : MonoBehaviour
{
    public GameObject[] appleParts;     // 4등분 사과 프리팹 배열
    public Transform spawnPoint;        // 분해 위치

    public void PlayDestructionEffect()
    {
        foreach (var part in appleParts)
        {
            // 파편 생성
            GameObject piece = Instantiate(part, spawnPoint.position, Quaternion.identity);

            // Rigidbody2D 컴포넌트 가져오기
            Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 임의 방향과 힘을 가함
                Vector3 force = new Vector3(Random.Range(-2f, 2f), 1f) * 300f;
                rb.AddForce(force);

                // 임의 토크(회전력) 적용
                float torque = Random.Range(-500f, 500f);
                rb.AddTorque(torque);
            }

            // 3초 후 파편 자동 파괴
            Destroy(piece, 2f);
        }
    }
}
