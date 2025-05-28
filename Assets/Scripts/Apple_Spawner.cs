using UnityEngine;

public class Apple_Spawner : MonoBehaviour
{
    public GameObject apple_prefab;
    public GameObject apple_inst;
    public float Max_Hp;
    public float Current_Hp;
    public GameObject gameManager;

    public AppleDestructionEffect ade;
    void Start()
    {
        Apple_Spawn();
       
    }
    public void Apple_Spawn()
    {
        apple_inst = Instantiate(apple_prefab, new Vector3(0, 0.5f, 0), Quaternion.identity);
        apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar = Max_Hp;
    }

    public void Damage_Apple(float Damage)
    {
        apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar -= Damage;
    }

    void Update()
    {
        Current_Hp = apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar;
        if (apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar <= 0)
        {
            Destroy(apple_inst);
            ade.PlayDestructionEffect();
            gameManager.GetComponent<GameManager>().stagelevel += 1;
            Max_Hp += 3.5f;
            Next_Round();
        }
    }
    void Next_Round()
    {
        print("다음 라운드");
        Apple_Spawn();
    }
}
