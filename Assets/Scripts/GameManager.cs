using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int stagelevel = 1;

    public static GameObject gameoverui;

    public Slider slider;

    public GameObject Apple_Spawner;
    public GameObject Pin_Spawner;
    void Update()
    {

        slider.value = Apple_Spawner.GetComponent<Apple_Spawner>().Current_Hp / Apple_Spawner.GetComponent<Apple_Spawner>().Max_Hp;

    }
    public void GameOver()
    {
        stagelevel = 1;
        Apple_Spawner.GetComponent<Apple_Spawner>().Max_Hp = 80;
    }




}
