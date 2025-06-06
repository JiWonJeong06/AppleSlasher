using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource Boom;
    public AudioSource Shoot;
    public AudioSource Knife;
    public AudioSource Uitouch;

    public Slider Bgmslider;
    public Slider EftSlider;
    public Text Bgmtext;
    public Text Efttext;

    void Start()
    {
        // 저장된 볼륨 값을 불러옴, 없으면 1.0f
        float savedBgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        float savedEftVolume = PlayerPrefs.GetFloat("EFTVolume", 1.0f);

        // 슬라이더 초기값 설정
        Bgmslider.value = savedBgmVolume;
        EftSlider.value = savedEftVolume;

        // 사운드 볼륨 적용
        BGM.volume = savedBgmVolume;
        Boom.volume = savedEftVolume;
        Shoot.volume = savedEftVolume;
        Knife.volume = savedEftVolume;
        Uitouch.volume = savedEftVolume;

        // 텍스트 갱신
        Bgmtext.text = (savedBgmVolume * 100).ToString("F0");
        Efttext.text = (savedEftVolume * 100).ToString("F0");

        BGM.Play();
    }

    void Update()
    {
        // 실시간 볼륨 조정
        BGM.volume = Bgmslider.value;
        Boom.volume = EftSlider.value;
        Shoot.volume = EftSlider.value;
        Knife.volume = EftSlider.value;
        Uitouch.volume = EftSlider.value;

        // 텍스트 갱신
        Bgmtext.text = (Bgmslider.value * 100).ToString("F0");
        Efttext.text = (EftSlider.value * 100).ToString("F0");

        // 볼륨 값 저장
        PlayerPrefs.SetFloat("BGMVolume", Bgmslider.value);
        PlayerPrefs.SetFloat("EFTVolume", EftSlider.value);
    }
}
