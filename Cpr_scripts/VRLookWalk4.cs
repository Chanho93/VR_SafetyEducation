using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class VRLookWalk4 : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle = 10.0f;
    public float speed = 6.0f;
    public static bool moveforward;
    private CharacterController cc; //기본적으로 제공되는 character controller  
    public float gravity;
    private Vector3 MoveDir;
    public GameObject fader;
    public Image fader1;           //FadeOut
    public GameObject Player;
       

    void Start()
    {
        gravity = 0.1f;
        MoveDir = Vector3.zero;
        cc = GetComponent<CharacterController>();   // 현재 프로그램에서의 캐릭터 컨트롤 정보 받아옴.
    }

    void Update()
    {
        Camera_Move();                       
    }

    void OnTriggerEnter(Collider col)
    {
      
    }

   
    void Camera_Move()
    {
        if ((vrCamera.eulerAngles.x) >= toggleAngle && vrCamera.eulerAngles.x <= 50.0f)
        {    //카메라의 앵글을 비교해줌
            moveforward = true;
        }
        else
        {
            moveforward = false;
        }
        if (moveforward)    //카메라 움직이는 속도 조절.
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }

    IEnumerator FadeOut()
    {
        Ship_Controller.Instance.water_CK = true;
        fader.SetActive(true);   //fader를 켜준다
        fader1.DOFade(1.0f, 0.5f);   //0.5초만에 꺼매짐
        yield return new WaitForSeconds(0.5f); //0.5초 기다림 
        
    }

    IEnumerator FadeIn()
    {
        fader1.DOFade(0.0f, 0.5f);   //0.5초만에 투명해짐
        yield return new WaitForSeconds(0.5f); //0.5초 기다림
        fader.SetActive(false);      //fader 없애준다.
    }
}


