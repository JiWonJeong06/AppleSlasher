using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class SwordStartEffect : MonoBehaviour
{
    public Vector3 knifeendPosition;
    public Vector3 sshendPosition;
    public Vector3 DiauiendPosition;
    public Vector3 TitleendPosition;
    public Vector3 TouchPosition;
    public float sdtdropspeed;
    public float dropSpeed;

    private bool isDropping = false;
    private bool hasStartedGame = false;
    private bool isTopDropping = false;

    public GameObject Knife;
    public GameObject Ssh;
    public GameObject Diaui;
    public GameObject Title;
    public GameObject Touch;

    public GameObject gamemanager;

    // 게임 시작한 후 떨어지는 오브젝트들
    public GameObject Top;
    public GameObject TopRight;
    public GameObject TopLeft;
    public Vector3 Topvec;
    public Vector3 Topvec2;
    public Vector3 Topvec3;

    public GameObject Soundmanager;

    public void StartDrop()
    {
        if (!isDropping)
        {
            isDropping = true;
        }
    }

    public void Update()
    {
        if (isDropping && !hasStartedGame)
        {
            // 초기 UI 오브젝트 이동
            Knife.transform.position = Vector3.MoveTowards(Knife.transform.position, knifeendPosition, Time.deltaTime * dropSpeed);
            Ssh.transform.position = Vector3.MoveTowards(Ssh.transform.position, sshendPosition, Time.deltaTime * sdtdropspeed);
            Diaui.transform.position = Vector3.MoveTowards(Diaui.transform.position, DiauiendPosition, Time.deltaTime * sdtdropspeed);
            Title.transform.position = Vector3.MoveTowards(Title.transform.position, TitleendPosition, Time.deltaTime * sdtdropspeed);
            Touch.transform.position = Vector3.MoveTowards(Touch.transform.position, TouchPosition, Time.deltaTime * sdtdropspeed);

            // 모든 UI가 위치에 도달하면 다음 단계로 넘어감
            if (Vector3.Distance(Knife.transform.position, knifeendPosition) < 0.01f &&
                Vector3.Distance(Ssh.transform.position, sshendPosition) < 0.01f &&
                Vector3.Distance(Diaui.transform.position, DiauiendPosition) < 0.01f &&
                Vector3.Distance(Title.transform.position, TitleendPosition) < 0.01f &&
                Vector3.Distance(Touch.transform.position, TouchPosition) < 1.01f)
            {
                hasStartedGame = true;
                isTopDropping = true;
                StartCoroutine(Delayed(0.25f));
            }
        }

        // Top 오브젝트들 이동 처리
        if (isTopDropping)
        {
            Top.transform.position = Vector3.MoveTowards(Top.transform.position, Topvec, Time.deltaTime * sdtdropspeed);
            TopLeft.transform.position = Vector3.MoveTowards(TopLeft.transform.position, Topvec2, Time.deltaTime * sdtdropspeed);
            TopRight.transform.position = Vector3.MoveTowards(TopRight.transform.position, Topvec3, Time.deltaTime * sdtdropspeed);

        }
    }

    private IEnumerator Delayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        Soundmanager.GetComponent<SoundManager>().BGM.volume = 0.01f;
        gamemanager.GetComponent<GameManager>().Start.SetActive(false);
        gamemanager.GetComponent<GameManager>().InGame.SetActive(true);
    }
}
