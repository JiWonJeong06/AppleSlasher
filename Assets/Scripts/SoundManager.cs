using UnityEngine;

public class SoundManager : MonoBehaviour
{
   //배경음음
    public AudioSource BGM; //배경음악

    //효과음
    public AudioSource Boom; //터지는 사운드
    public AudioSource Shoot; //피격 사운드
    public AudioSource Knife; //칼 부딪히는 소리
    public AudioSource Uitouch; //ui터치소리리


    void Start()
    {
        BGM.Play();
    }
}
