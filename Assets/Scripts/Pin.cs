using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pin : MonoBehaviour
{
    [SerializeField]
    private Transform hitEffectSpawnPoint;
    [SerializeField]
    private GameObject hitEffectPrefab;

    private Movement2D movement2D;

    public GameObject Apple_Spawner;

    public GameObject gameManager;

    public GameObject weaponEvolution;


    public float damage;

    public float add_value = 10f;




    private void Update()

    {
        movement2D = GetComponent<Movement2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Pin"))
        {

            
            gameManager.GetComponent<GameManager>().GameOver();

        }


        else if (collision.CompareTag("Target"))
        {
            movement2D.MoveTo(Vector3.zero);

            transform.SetParent(collision.transform);
            collision.GetComponent<Target>().Hit();
            weaponEvolution.GetComponent<WeaponEvolution>().GainExp(10f);

            Instantiate(hitEffectPrefab, hitEffectSpawnPoint.position, hitEffectSpawnPoint.rotation);
        
            collision.GetComponent<Target>().ShakeApple();
            Apple_Spawner.GetComponent<Apple_Spawner>().Damage_Apple(weaponEvolution.GetComponent<WeaponEvolution>().Damage());
            
        }
    }
}
