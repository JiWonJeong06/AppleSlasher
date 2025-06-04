using UnityEngine;

// 칼 날라가기
public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 20;
    [SerializeField]
    private Vector3 moveDirection = Vector3.up;

    [SerializeField]
    public float rotateSpeed = 360f; // 초당 회전 속도 (도 단위)

    private bool isRotating = false;

    private void Update()
    {
        // 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 회전
        if (isRotating)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }

    // 이동 방향 설정
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }

    // 회전 시작
    public void StartRotate()
    {
        isRotating = true;
     
    }

    // 회전 멈춤 (선택사항)
    public void StopRotate()
    {
        isRotating = false;
    }
}
