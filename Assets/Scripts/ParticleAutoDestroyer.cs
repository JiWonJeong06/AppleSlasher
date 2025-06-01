using UnityEngine;
//파티클클
public class ParticleAutoDestroyer : MonoBehaviour
{
	private	ParticleSystem	particle;

	private void Awake()
	{
		particle = GetComponent<ParticleSystem>();
	}

	private void Update()
	{
		if ( particle.isPlaying == false )
		{
			Destroy(gameObject);
		}
	}
}
