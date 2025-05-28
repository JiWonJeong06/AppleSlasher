using UnityEngine;
using System.Collections;

public class Apple_Spawner : MonoBehaviour
{
    public GameObject apple_prefab;
    public GameObject apple_inst;
    public float Max_Hp;
    public float Current_Hp;
    public float Boss_Hp = 105f;
    public GameObject gameManager;



    public AppleDestructionEffect ade;
    void Start()
    {
        Apple_Spawn();

    }
    public void Apple_Spawn()
    {
        apple_inst = Instantiate(apple_prefab, new Vector3(0, 0.5f, 0), Quaternion.identity);

        if (gameManager.GetComponent<GameManager>().stagelevel % 5 == 0)
        {
           apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar = Boss_Hp;
           
        }
        else
           apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar = Max_Hp;
        

    }

    public void Damage_Apple(float Damage)
    {
        apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar -= Damage;
    }

    void Update()
    {
        if (apple_inst != null)
        {
            Current_Hp = apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar;

            if (apple_inst.GetComponent<Apple_Hp>().Apple_Hp_Bar <= 0)
            {
                Destroy(apple_inst);
                ade.PlayDestructionEffect();

                if (gameManager.GetComponent<GameManager>().stagelevel % 5 == 0)
                    Boss_Hp += 10f;
                else
                    Max_Hp += 5f;

                gameManager.GetComponent<GameManager>().stagelevel += 1;
                StartCoroutine(Next_Round());
            }
        }
    }

    IEnumerator Waittime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    IEnumerator Next_Round()
    {
        yield return Waittime(0.5f);
        Apple_Spawn();
    }



}
