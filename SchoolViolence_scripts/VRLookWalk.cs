using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class VRLookWalk : MonoBehaviour
{

    public VR_SchoolViolence VR_SchoolViolence;

   
    public Transform vrCamera;
    public GameObject[] My;
    public float toggleAngle = 10.0f;
    public float RightAngle = 165.0f;
    public float LeftAngle = 10.0f;
    public float speed = 6.0f;
    public static bool moveforward;
    public static bool move_Stop = false;
    public static bool Car_Check = false;
    private CharacterController cc; //기본적으로 제공되는 character controller
    public static bool Right_Check = false, Left_Check = false, Right_Check2 = false, Left_Check2 = false, Road_CK = false, Road_CK2 = false, Road2_CK = false, Road2_CK2 = false; //횡단보도를 건널시 z축기준 오른쪽, 왼쪽 방향을 일정각도 이상 바라보는것을 체크
    public static bool Car_CK = false, Car_CK2 = false, Car_CK3 = false, Inside_Walk = false, Police_CK = false, Anim_CK = false, EQ_Tri = false, Bag_CK = false, Quake_CK = false, FireWater_CK = false;
    public static bool FireEnd_CK = false, Firetag_CK = false;
    float Timer = 0.0f;
    float a = 0.5f, b = 0.1f;
    public GameObject[] Scene_Fade;
    public GameObject[] Car_C;
    public GameObject[] Road_Arrow;
    int Road_Cnt = 0, Car_Cnt = 0, Arrow_Cnt = -1, Message_Cnt = 0;
    public GameObject Map;
    public static int Cross_Cnt = 0, Police_Cnt = 0, Drop_Cnt = 0, Bag_Cnt = 0, Fire_Cnt = 0, Road_End = 0, 
        Road_End2 = 0, SchoolQ_Cnt = 0, FireEnd_Cnt = 0, FireDie_Cnt = 0, Elv_Cnt = 0, Line_Cnt = 0, RoadFire_Cnt = 0;
    public float gravity;
    private Vector3 MoveDir;
    public GameObject fader;
    public Image faderI;
    public GameObject past_waterline;
    public GameObject water_line; 
    

   

    
    void Start()
    {
        gravity = 0.2f;
        MoveDir = Vector3.zero;
        cc = GetComponent<CharacterController>();   // 현재 프로그램에서의 캐릭터 컨트롤 정보 받아옴.
        //Scene_Fade[4].gameObject.SetActive(true);
        Append_Start();
        
    }

    void Update()
    {
        All_SC();
        Car_Find();
        
       



        if (SceneManager.GetActiveScene().name == "Ship_Scene")
        {
            if (cc.isGrounded)
            {
                MoveDir = transform.TransformDirection(MoveDir);
            }

            MoveDir.y -= gravity * Time.deltaTime;
            cc.Move(MoveDir * Time.deltaTime);
        }
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("target1"))
        {
            StartCoroutine(fadeOut());
        }
        if (col.CompareTag("teleport_2"))
        {
            StartCoroutine(fadeOut_1());
        }
        if (col.CompareTag("teleport_3"))
        {
            StartCoroutine(fadeOut_2());
        }

        if (col.CompareTag("Road_TG"))
        {
            Road_CK = true;
            //Debug.Log(Road_CK);
            //Life[3].gameObject.SetActive(true);
            Message_Cnt++;
            if(Message_Cnt == 1)
            {
                Scene_Fade[5].gameObject.SetActive(false);
                Invoke("Off_UI", 3);
            }
        }

        else if (col.CompareTag("Road_TG2"))
        {
            Road_CK2 = true;
        }

        else if(col.CompareTag("Road2_TG"))
        {
            Road2_CK = true;
            Road_CK2 = false;
            RoadFire_Cnt++;
            //Life[3].gameObject.SetActive(false);
        }

        else if(col.CompareTag("Road2_TG2"))
        {
            Road2_CK2 = true;
        }

        else if(col.CompareTag("Road_End"))
        {
            Road_End++;
            Road_End2++;
        }

        else if (col.CompareTag("Goal"))
        {
            if(Inside_Walk == true)
            {
                Police_CK = true;
                //Police_Cnt++;
            }
            else
            {
                SceneManager.LoadScene(6);
            }
            //SceneManager.LoadScene(0);
        }

        else if (col.CompareTag("Car"))
        {
            Car_CK = true;
            Car_Cnt += 1;
            //SceneManager.LoadScene(2);
            Scene_Fade[1].gameObject.SetActive(true);
            /*
            Scene_Fade[0].gameObject.SetActive(true);
            Scene_Fade[1].gameObject.SetActive(true);
            */
        }

        else if (col.CompareTag("Car2"))
        {
            Car_CK2 = true;
            Car_Cnt += 1;
            SceneManager.LoadScene(6);
            /*
            Scene_Fade[0].gameObject.SetActive(true);
            Scene_Fade[1].gameObject.SetActive(true);
            */
        }
        
        else if(col.CompareTag("Warning"))   ////////////지진시 잘못된선택 End
        {
            Inside_Walk = true;
            //Police_Cnt = 1;
            //Scene_Fade[2].gameObject.SetActive(true);
            if(SceneManager.GetActiveScene().name == "School_EarthQuake")
            {
                EQ_Tri = true;
                Drop_Cnt++;
                if((Drop_Cnt == 1 && ObjTF.E_Cnt == 0) || (Bag_CK == false && Bag_Cnt == 0) || (ObjTF.E_Cnt >= 1 && Bag_CK == false))
                {
                    //Scene_Fade[1].gameObject.SetActive(true);
                    Quake_CK = true;
                    Map.gameObject.SetActive(true);
                   
                }

                else
                {
                    Elv_Cnt++;
                }
            }
            
            else if(SceneManager.GetActiveScene().name == "School_Fire")
            {
                EQ_Tri = true;
               
                Drop_Cnt++;
                if ((Drop_Cnt == 1 && ObjTF.E_Cnt == 0) || (Bag_Cnt == 0 || FireWater_CK == false))
                {
                    Quake_CK = true;
                    FireDie_Cnt++;
                }
            }
        }

        else if(col.CompareTag("School_End"))
        {
            SchoolQ_Cnt++;
        }
        
        else if(col.CompareTag("Fade_Dog"))
        {
            Road2_CK2 = false;
        }

        else if(col.CompareTag("Finish"))
        {
            StartCoroutine(fadeOut());
            Line_Cnt++;
        }

        else if(col.CompareTag("Bag"))
        {
            StartCoroutine(SoundManager._instance.Play_SE("item"));
            if (SceneManager.GetActiveScene().name == "School_Fire")
            {
                past_waterline = GameObject.FindGameObjectWithTag("line");
                past_waterline.SetActive(false);
                Invoke("voice", 1.5f);
            }
            Bag_CK = true;
            Bag_Cnt++;
            My[2].gameObject.SetActive(false);
            My[3].gameObject.SetActive(false);
        }

      
        

        else if(col.CompareTag("Untagged"))
        {
            Road_CK = false;
            Road_CK2 = false;
            Car_CK = false;
        }

        else if(col.CompareTag("FireWater"))
        {
          
          

            FireWater_CK = true;
            StartCoroutine(SoundManager._instance.Play_SE("wet"));
           
            //FireDie_Cnt++;
        }

        else if(col.CompareTag("EditorOnly"))
        {
            teleport2();
        }

        else if(col.CompareTag("Fire"))
        {
            Fire_Cnt++;
            Firetag_CK = true;
        }

        else if(col.CompareTag("Fire_End"))
        {
            if(SceneManager.GetActiveScene().name == "School_Fire")
            {
                FireEnd_CK = true;
                FireEnd_Cnt++;
            }
        }

        else if (col.CompareTag("Water"))
        {
            move_Stop = true;
        }
    }

    
    

    void All_SC()
    {
        if ((vrCamera.eulerAngles.x) >= toggleAngle && vrCamera.eulerAngles.x <= 50.0f && move_Stop == false && Fire_Cnt != 2 && Quake_CK == false && Firetag_CK == false)
        {    //카메라의 앵글을 비교해줌
           
            moveforward = true;
            //StartCoroutine(SoundManager._instance.Play_SE("walk"));


        }
        
        else
        {
            moveforward = false;
        }

        if (TrafficLightController.rbCheck == true && Road_CK == true)
        {
            if (vrCamera.eulerAngles.y >= 255.0f && vrCamera.eulerAngles.y <= 275.0f)
            {
                Right_Check = true;
                //Debug.Log("Right");
            }

            if (vrCamera.eulerAngles.y >= 75.0f && vrCamera.eulerAngles.y <= 95.0f)
            {
                Left_Check = true;
                //Debug.Log("Left");
            }
        }

        if (Traffic2.rbCheck2 == true && Road2_CK == true)
        {
            if (vrCamera.eulerAngles.y >= 165.0f && vrCamera.eulerAngles.y <= 185.0f)
            {
                Right_Check2 = true;
                //Debug.Log("Right");
            }

            if (vrCamera.eulerAngles.y >= 5.0f && vrCamera.eulerAngles.y <= 25.0f)
            {
                Left_Check2 = true;
                //Debug.Log("Left");
            }
        }

        if (TrafficLightController.rbCheck == false)
        {
            Right_Check = false;
            Left_Check = false;
        }

        if(Traffic2.rbCheck2 == false)
        {
            Right_Check2 = false;
            Left_Check2 = false;
        }


        if (moveforward)    //카메라 움직이는 속도 조절.
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }

        if (Car_CK == true && Car_Cnt == 1)
        {
            Timer += Time.deltaTime;
            //this.transform.Translate(new Vector3(0, 0, a));

            if (Timer <= 1.0f && Timer >= 0.0f)
            {
                this.transform.Translate(new Vector3(a, 0, 0));
            }
        }

        else if (Car_CK2 == true && Car_Cnt == 1)
        {
            Timer += Time.deltaTime;
            //this.transform.Translate(new Vector3(0, 0, a));

            if (Timer <= 1.0f && Timer >= 0.0f)
            {
                this.transform.Translate(new Vector3(b, 0, -a));
            }
        }
        
        else if (Car_CK3 == true && Car_Cnt == 1)
        {
            Timer += Time.deltaTime;
            //this.transform.Translate(new Vector3(0, 0, a));

            if (Timer <= 1.0f && Timer >= 0.0f)
            {
                this.transform.Translate(new Vector3(-a, 0, 0));
            }
        }

        /////////////////////무단횡단 UI////////////////////
        
        if(Police_CK == true)
        {
            Police_Cnt++;
        }

        if (Road_Cnt == 3)
        {
            Road_Change();
        }

        if(See_Point.Gaze_Check == true)
        {
            Scene_Fade[6].gameObject.SetActive(true);
            Invoke("Off_UI", 3);
        }

        if(ObjTF.E_Cnt == 1 || ObjTF.E_Cnt == 2 || ObjTF.E_Cnt == 3 )
        {
            if (SceneManager.GetActiveScene().name == "School_EarthQuake")
            {
                teleport2();
                Invoke("teleport3", 11);
            }
        }
    }

    void Car_Find() //횡단보도에서 무단횡단하거나 초록불일때 양쪽을 안보고 가면 일어나는 이벤트체크
    {
        if ((Right_Check == false || Left_Check == false) && TrafficLightController.rbCheck == true && Road_CK2 == true)
        {
            Car_Check = true;
            Car_C[0].gameObject.SetActive(true);
            Cross_Cnt++;
        }

        else if (TrafficLightController.rbCheck == false && Road_CK2 == true)
        {
            Car_Check = true;
            Car_C[0].gameObject.SetActive(true);
            Cross_Cnt++;
        }
        /*
        else
        {
            Car_Check = false;
            Car_C[0].gameObject.SetActive(false);
        }
        */

        if(Traffic2.rbCheck2 == false && Road2_CK2 == true)
        {
            Car_C[1].gameObject.SetActive(true);
            Car_Check = true;
            Cross_Cnt++;
        }

        else if((Right_Check2 == false && Left_Check2 == false) && Traffic2.rbCheck2 == true && Road2_CK2 == true)
        {
            Car_C[1].gameObject.SetActive(true);
            Car_Check = true;
            Cross_Cnt++;
        }
        
    }

    void Road_Change()
    {
        Scene_Fade[0].gameObject.SetActive(true);
        Scene_Fade[1].gameObject.SetActive(true);
    }

    void TIP_UI()
    {
        Scene_Fade[4].gameObject.SetActive(false);
       // Scene_Fade[7].gameObject.SetActive(false);
    }

    void TIP_UI_01()
    {
        Scene_Fade[7].gameObject.SetActive(false);

    }
    void Off_UI()
    {
        See_Point.Gaze_Check = false;
        Scene_Fade[6].gameObject.SetActive(false);
        Scene_Fade[5].gameObject.SetActive(false);
    }

    void Car_See()
    {
        Car_C[2].gameObject.SetActive(true);
    }
    
    void Append_Start()
    {
        if (SceneManager.GetActiveScene().name == "SchoolViolence")
        {
            Invoke("TIP_UI", 30);
        }
        else
        {
            Invoke("TIP_UI", 24);
            Car_C[0].gameObject.SetActive(false);
            Car_C[1].gameObject.SetActive(false);
            Road_CK2 = false;
            Car_Check = false;
            Inside_Walk = false;
            Police_CK = false;
            Cross_Cnt = 0;
            Police_Cnt = 0;
            Invoke("Car_See", 10);
            Right_Check = false;
            Right_Check2 = false;
            Left_Check = false;
            Left_Check2 = false;
            Anim_CK = false;
            EQ_Tri = false;
            Drop_Cnt = 0;
            Bag_CK = false;
            Bag_Cnt = 0;
            Fire_Cnt = 0;
            Road_End = 0;
            Road_End2 = 0;
            SchoolQ_Cnt = 0;
            FireEnd_Cnt = 0;
            FireDie_Cnt = 0;
            Elv_Cnt = 0;
            Line_Cnt = 0;
            RoadFire_Cnt = 0;
            move_Stop = false;
            Quake_CK = false;
            FireWater_CK = false;
            FireEnd_CK = false;
            Firetag_CK = false;
        }
    }

    void teleport()
    {
        if (SceneManager.GetActiveScene().name == "SchoolViolence")
        {
            Vector3 originPoint = new Vector3();
            originPoint.x = 5.63f;
            originPoint.y = 8.56f;
            originPoint.z = 28.17f;
            My[0].transform.position = originPoint;
            originPoint.x = 6.20f;
            originPoint.y = 7.56f;
            originPoint.z = 29.55f;
            My[5].transform.position = originPoint;
            originPoint.x = 5.20f;
            originPoint.y = 7.56f;
            originPoint.z = 29.55f;
            My[6].transform.position = originPoint;
            Invoke("TIP_UI_01",40);

        }

        if (SceneManager.GetActiveScene().name == "Ship_Scene")
        {
            Vector3 originPoint = new Vector3();
            originPoint.x = 52.1973f;
            originPoint.y = 11.7387f;
            originPoint.z = -25.97512f;
            My[0].transform.position = originPoint;
        }

        else if (SceneManager.GetActiveScene().name == "School_EarthQuake" || SceneManager.GetActiveScene().name == "School_Fire")
        {
            Vector3 originPoint = new Vector3();
            originPoint.x = -17.6f;
            originPoint.y = -4f;
            originPoint.z = 9f;

            My[0].transform.position = originPoint;
        }
    }

    void teleport2()
    {
        if (SceneManager.GetActiveScene().name == "School_EarthQuake")
        {
            Vector3 originPoint = new Vector3();
            originPoint.x = -0.585f;
            originPoint.y = 0.467945f;
            originPoint.z = -4.566f;

            My[0].transform.position = originPoint;
            ObjTF.E_Cnt++;
        }

        if(SceneManager.GetActiveScene().name == "Ship_Scene")
        {
            Vector3 originPoint = new Vector3();
            originPoint.x = -16.26f;
            originPoint.y = 1.45994f;
            originPoint.z = -31.71f;

            My[0].transform.position = originPoint;
        }
    }

    void teleport3()
    {
        Vector3 originPoint = new Vector3();
        originPoint.x = -0.22f;
        originPoint.y = 1.165945f;
        originPoint.z = -5.73f;

        My[0].transform.position = originPoint;
        Anim_CK = true;
        My[3].gameObject.SetActive(true);
    }

    void teleport4()
    {
       
        Vector3 originPoint = new Vector3();
        originPoint.x = -1.508518f;
        originPoint.y = -2.886894f;
        originPoint.z = 15.69428f;
        My[0].transform.position = originPoint;
        
        StartCoroutine(SoundManager._instance.Play_SE("hidden"));
        if (VR_SchoolViolence.status == 25)
        {
           
            VR_SchoolViolence.status = 26;
          
            VR_SchoolViolence.PlayStory(VR_SchoolViolence.status);
            
        }
    }

    void teleport5()
    {

        Vector3 originPoint = new Vector3();
        originPoint.x = 1.91f;
        originPoint.y = 0.82f;
        originPoint.z = -4.5f;
        My[0].transform.position = originPoint;

       
        originPoint.x = -3.43f;
        originPoint.y = -0.55f;
        originPoint.z = -6.91f;
        My[5].transform.position = originPoint;
       
        originPoint.x = -3.56f;
        originPoint.y = -0.55f;
        originPoint.z = -4.29f;
        My[6].transform.position = originPoint;
      
        originPoint.x = -3.49f;
        originPoint.y = 0.25f;
        originPoint.z = -5.61f;
        My[7].transform.position = originPoint;

        StartCoroutine(SoundManager._instance.Play_SE("hidden"));
        if (VR_SchoolViolence.status == 28)
        {

            VR_SchoolViolence.status = 29;

            VR_SchoolViolence.PlayStory(VR_SchoolViolence.status);

        }
    }

    IEnumerator fadeOut()
    {
        if (SceneManager.GetActiveScene().name == "SchoolViolence")
        {
            fader.SetActive(true);   //fader를 켜준다
            faderI.DOFade(1.0f, 0.5f);   //0.5초만에 꺼매짐
            yield return new WaitForSeconds(0.5f); //0.5초 기다림
            teleport();
            StartCoroutine(fadeIn());
        }
        else {
            fader.SetActive(true);   //fader를 켜준다
            faderI.DOFade(1.0f, 0.5f);   //0.5초만에 꺼매짐
            yield return new WaitForSeconds(0.5f); //0.5초 기다림
            teleport();
            StartCoroutine(fadeIn());
            My[1].gameObject.SetActive(false);
        My[4].gameObject.SetActive(true);
        StartCoroutine(fadeIn());
        }
    }

    IEnumerator fadeOut_1()
    {
        fader.SetActive(true);   //fader를 켜준다
            faderI.DOFade(1.0f, 0.5f);   //0.5초만에 꺼매짐
            yield return new WaitForSeconds(0.5f); //0.5초 기다림
            teleport4();
            
            StartCoroutine(fadeIn());
        
      
    }

    IEnumerator fadeOut_2()
    {
        fader.SetActive(true);   //fader를 켜준다
        faderI.DOFade(1.0f, 0.5f);   //0.5초만에 꺼매짐
        yield return new WaitForSeconds(0.5f); //0.5초 기다림

        teleport5();

        StartCoroutine(fadeIn());


    }

    IEnumerator fadeIn()
    {
        faderI.DOFade(0.0f, 0.5f);   //0.5초만에 투명해짐
        yield return new WaitForSeconds(0.5f); //0.5초 기다림
        fader.SetActive(false);      //fader 없애준다.
    }


   
    
        public void voice()
    {
        
        SoundManager._instance.Play_Voice("fire3");
        water_line.SetActive(true);
        
    }

    void SceneTg()
    {
        SceneManager.LoadScene(5);
    }

}


