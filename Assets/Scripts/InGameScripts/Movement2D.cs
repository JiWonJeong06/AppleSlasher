using UnityEngine;

public class Movement2D : MonoBehaviour
{
	[SerializeField]
	private	float	moveSpeed = 20;
	[SerializeField]
	private	Vector3	moveDirection = Vector3.up;
	
	public GameManager gameManager;

	private void Update()
	{
		if (!gameManager.GetComponent<GameManager>().GameStart)
			return;
		transform.position += moveDirection * moveSpeed * Time.deltaTime;
	}

	public void MoveTo(Vector3 direction)
	{
		moveDirection = direction;
	}
}
