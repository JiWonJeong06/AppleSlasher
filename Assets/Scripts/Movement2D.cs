using UnityEngine;
//칼 날라가기
public class Movement2D : MonoBehaviour
{
	[SerializeField]
	private	float	moveSpeed = 20;
	[SerializeField]
	private	Vector3	moveDirection = Vector3.up;

	private void Update()
	{
		
		transform.position += moveDirection * moveSpeed * Time.deltaTime;
	}

	public void MoveTo(Vector3 direction)
	{
		moveDirection = direction;
	}
}
