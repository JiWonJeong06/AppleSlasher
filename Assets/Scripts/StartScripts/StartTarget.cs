using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class StartTarget : MonoBehaviour
{
	private float rotateSpeed = 100;
	private Vector3 rotateAngle = Vector3.forward;



	private SpriteRenderer spriteRenderer;

	private IEnumerator Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		while (true)
		{
			int speed = Random.Range(100, 300);
			int dir = Random.Range(0, 2);

			rotateSpeed = speed;
			rotateAngle = new Vector3(0, 0, dir * 2 - 1);
		}
	}
	private void Update()
	{
		transform.Rotate(rotateAngle * rotateSpeed * Time.deltaTime);
	}
	public void Hit()
	{
		StopCoroutine(OnHit());
		StartCoroutine(OnHit());
	}
	public IEnumerator OnHit()
	{
		yield return new WaitForSeconds(1f);
	}
}
