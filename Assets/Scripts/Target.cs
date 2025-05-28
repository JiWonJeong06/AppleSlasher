using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Target : MonoBehaviour
{
	private float rotateSpeed = 100;
	private Vector3 rotateAngle = Vector3.forward;

	private SpriteRenderer spriteRenderer;

	private IEnumerator Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		while (true)
		{
			int time = Random.Range(1, 5);

			yield return new WaitForSeconds(time);

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
	public void ShakeApple()
    {
        StartCoroutine(ShakeAppleCoroutine(this.transform)); 
    }	


	private IEnumerator ShakeAppleCoroutine(Transform appleTransform, float duration = 0.2f, float magnitude = 0.1f)
	{
		Vector3 originalPos = appleTransform.localPosition;
		float elapsed = 0f;

		while (elapsed < duration)
		{
			float offsetY = Mathf.Sin(Time.time * 50f) * magnitude;
			appleTransform.localPosition = originalPos + new Vector3(0, offsetY, 0);
			elapsed += Time.deltaTime;
			yield return null;
		}

		appleTransform.localPosition = originalPos;
	}

}
