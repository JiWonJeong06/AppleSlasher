using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM; //배경음악
    public AudioSource Boom; //터지는 사운드
    public AudioSource Shoot; //피격 사운드


    void Start()
    {
        BGM.Play();
    }
}
