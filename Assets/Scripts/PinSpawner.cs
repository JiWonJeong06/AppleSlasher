using UnityEngine;
using UnityEngine.InputSystem;
//핀 스포너너
public class PinSpawner : MonoBehaviour
{
	[SerializeField]
	public GameObject pinPrefab;
	public GameObject Apple_Spawner;
	public GameObject gameManager;
	public GameObject inst_pin;
	public GameObject weaponEvolution;
    public GameObject pinspawner;
    public GameObject soundManager;
    public AudioClip shoot;
	public GameObject[] KnifeList;
	public SpriteRenderer sprite;
	public Sprite[] KnifeSprite;
	public string Name;

    public bool enablepin = true;

    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame &&
            Apple_Spawner.GetComponent<Apple_Spawner>().apple_inst != null &&
            enablepin)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();

            // 화면 높이의 하단 1/3만 유효한 영역으로 지정
            float screenHeight = Screen.height;
            if (touchPos.y <= screenHeight / 3f)
            {
                UpdatePinByRarity();
                inst_pin = Instantiate(pinPrefab, transform.position, Quaternion.identity);
                inst_pin.GetComponent<Pin>().Apple_Spawner = Apple_Spawner;
                inst_pin.GetComponent<Pin>().gameManager = gameManager;
                inst_pin.GetComponent<Pin>().weaponEvolution = weaponEvolution;
                inst_pin.GetComponent<Pin>().PinSpawner = pinspawner;
                inst_pin.GetComponent<Pin>().SoundManager = soundManager;
            }
        }
    }

	 private void UpdatePinByRarity()
    {
		Name = weaponEvolution.GetComponent<WeaponEvolution>().WeaponName();
        int index;

        switch (Name)
        {
            case "기본 칼":
                index = 0;
                break;
            case "희귀 칼":
                index = 1;
                break;
            case "영웅 칼":
                index = 2;
                break;
            case "전설 칼":
                index = 3;
                break;
            default:
                Debug.LogWarning("알 수 없는 희귀도: " + Name);
                return;
        }

        pinPrefab = KnifeList[index];
 
        sprite.sprite = KnifeSprite[index];
        
    }
}
