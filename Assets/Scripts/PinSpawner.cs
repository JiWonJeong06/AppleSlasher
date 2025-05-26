using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinSpawner : MonoBehaviour
{
	[SerializeField]
	public GameObject pinPrefab;
	public GameObject Apple_Spawner;
	public GameObject gameManager;
	public GameObject inst_pin;
	public GameObject weaponEvolution;
	public GameObject[] KnifeList;

	public SpriteRenderer sprite;
	public Sprite[] KnifeSprite;

	public string Name;


	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			UpdatePinByRarity();
			inst_pin = Instantiate(pinPrefab, transform.position, Quaternion.identity);
			inst_pin.GetComponent<Pin>().Apple_Spawner = Apple_Spawner;
			inst_pin.GetComponent<Pin>().gameManager = gameManager;
			inst_pin.GetComponent<Pin>().weaponEvolution = weaponEvolution;
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
