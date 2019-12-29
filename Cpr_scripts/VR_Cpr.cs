using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class VR_Cpr : MonoBehaviour       //폭력 VR
{
    public static int status = 0;
    public bool _sceneFinished = false;
    bool _statusCompleted = false;
    int selectedNumber;
    bool bPaused = false;

    //대화 상자
    public GameObject SharkBox;
    public GameObject HodolBox;
    public GameObject narrationBox;
    public GameObject AriBox;    
    public GameObject badboyBox;
    public GameObject badboySpeechBox;
    public Text badboyText;
    public Text narrationText;
    public GameObject QuestBox;
    public Text QuestText;
    public GameObject speechBox;
    public Text speechText;

    //대화상자 크기
    Vector3 AriBoxSize;
    Vector3 speechBoxSize;
    Vector3 badboyBoxSize;
    Vector3 badboySpeechBoxSize;

    //오브젝트
   

    public GameObject prison;
    public GameObject prison2;
   // public GameObject prison3;
    //public GameObject prison3_1;
    public GameObject prison3_2;
    public GameObject[] npcMove;
    public GameObject JJapari;
    public GameObject JJapari2;
    public GameObject JJapshark;
    public GameObject JJapshark2;
    public GameObject JJapari3;
    public GameObject JJapshark3;
    public GameObject arimove;
    public GameObject aricamera;
    public GameObject aricprimage;
    public GameObject aricamera2;
    public GameObject aricprimage2;
    public GameObject aricamera3;
    public GameObject aricprimage3;
    public GameObject Aed1;
    public GameObject Aed2;

    public GameObject aedPad1;
    public GameObject aedPad1_1;
    public GameObject aedPad2;
    public GameObject aedPad2_1;
    public GameObject aedPad3;
    public GameObject aedPad3_1;
    //캔버스
    public Image fader;
    public GameObject EndImage;

    //애니메이션
    public Animator[] npcAni;

    // public float T_Cnt = 0.0f;   

    private void Awake()
    {
        speechBoxSize = speechBox.transform.localScale;
        badboyBoxSize = badboyBox.transform.localScale;
        AriBoxSize = AriBox.transform.localScale;
        badboySpeechBoxSize = badboySpeechBox.transform.localScale;
        status = 0;
    }

    void Sta()
    {
        PlayStory(0);
    }

    void Start()
    {
        PlayStory(status);
    }

    public void BoxChange(int selectedNum)
    {
        selectedNumber = selectedNum;
        Narration_Script.Instance.inputAllowed = true;
        CutChange();
        status++;
        PlayStory(status);
    }

    public void PlayStory(int status)
    {
        _statusCompleted = false;
        if (_sceneFinished)
            return;
        switch (status)
        {
            case 0:
                StartCoroutine(Speech1());
                break;
            case 1:
                StartCoroutine(Speech2());
                break;
            case 2:
                StartCoroutine(Speech3());
                break;
            case 3:
                StartCoroutine(Speech4());
                break;
            case 4:
                StartCoroutine(Speech5());
                break;
            case 5:
                StartCoroutine(Speech6());
                break;
            case 6:
                StartCoroutine(Speech7());
                break;
            case 7:
                StartCoroutine(Quest1());
                break;
            case 8:
                StartCoroutine(Speech8());
                break;
            case 9:
                StartCoroutine(Speech9());
                break;
            case 10:
                StartCoroutine(Speech10());
                break;
            case 11:
                StartCoroutine(Speech11());
                break;
            case 12:
                StartCoroutine(Speech12());
                break;
            case 13:
                StartCoroutine(Speech13());
                break;
            case 14:
                StartCoroutine(Speech14());
                break;
            case 15:
                StartCoroutine(Speech15());
                break;
            case 16:
                StartCoroutine(Quest2());
                break;
            case 17:
                StartCoroutine(Speech16());
                break;
            case 18:
                StartCoroutine(Speech17());
                break;
            case 19:
                StartCoroutine(Speech18());
                break;
            case 20:
                StartCoroutine(Speech19());
                break;
            case 21:
                StartCoroutine(Speech20());
                break;
            case 22:
                StartCoroutine(Speech21());
                break;
            case 23:
                StartCoroutine(Quest3());
                break;
            case 24:
                StartCoroutine(Quest4());
                break;
            case 25:
                StartCoroutine(Speech22());
                break;
            case 26:
                StartCoroutine(Speech23());
                break;
            case 27:
                StartCoroutine(Speech24());
                break;
            case 28:
                StartCoroutine(Speech25());
                break;
            case 29:
                StartCoroutine(Speech26());
                break;
            case 30:
                StartCoroutine(Speech27());
                break;
            case 31:
                StartCoroutine(Speech28());
                break;
            case 32:
                StartCoroutine(End_1());
                break;
            case 33:
                StartCoroutine(End_2());
                break;

        }
    }

    public void CompleteAnimation(int status)
    {
        //DOTween.KillAll();
        StopAllCoroutines();
        switch (status)
        {
            case 0:              
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration1;
                break;
            case 1:               
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration2;
                break;
            case 2:               
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechBox.SetActive(true);
                HodolBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration3;
                break;
            case 3:
                HodolBox.SetActive(false);
                speechBox.SetActive(true);
                SharkBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration4;
                break;
            case 4:
                speechBox.SetActive(true);
                SharkBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration5;
                break;
            case 5:
                speechBox.SetActive(false);
                SharkBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration6;
                break;
            case 6:
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechBox.SetActive(true);
                HodolBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration7;
                break;
            case 7:
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[0];
                break;
            case 8:
                HodolBox.SetActive(false);
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration8;
                break;
            case 9:
                
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration9;
                break;
            case 10:
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration10;
                break;
            case 11:
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration11;
                break;
            case 12:
                AriBox.SetActive(false);
                HodolBox.SetActive(true);
                speechBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration12;
                break;
            case 13:
                HodolBox.SetActive(false);
                speechBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration13;
                break;
            case 14:               
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                HodolBox.SetActive(true);
                speechBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration14;
                break;
            case 15:
                HodolBox.SetActive(false);
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration15;
                break;
            case 16:
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[1];
                break;
            case 17:               
                narrationBox.SetActive(false);
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration16;
                break;
            case 18:              
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration17;
                break;
            case 19:
                AriBox.SetActive(false);
                HodolBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration18;
                break;
            case 20:
                HodolBox.SetActive(false);
                AriBox.SetActive(true);                
                speechText.text = Narration_Script.Instance.Narration19;
                break;
            case 21:               
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration20;
                break;
            case 22:
               
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration21;
                break;
            case 23:
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[2];
                break;
            case 24:               
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[3];
                break;
            case 25:
                narrationBox.SetActive(false);
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration22;
                break;
            case 26:                
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration23;
                break;
            case 27:
                AriBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration24;
                break;
            case 28:
                AriBox.SetActive(false);
                SharkBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration25;
                break;
            case 29:                
                SharkBox.SetActive(false);
                HodolBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration26;
                break;
            case 30:                
                HodolBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration27;
                break;
            case 31:
                SharkBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration28;
                break;
            case 32:
                SharkBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration_End1;
                break;
            case 33:              
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration_End2;
                break;
        }
     
        Narration_Script.Instance.inputAllowed = true;
        _statusCompleted = true;
    }

    //Todo: 나레이션 변경
    public void NarrationChange()
    {
        if (Narration_Script.Instance.inputAllowed == false)
            return;

        if (_statusCompleted == false)
        {
            CompleteAnimation(status);
        }
        else
        {
            if (status == 7)
            {
                StopAllCoroutines();
            }
            else if (status == 16)
            {
                StopAllCoroutines();
            }
            else if (status == 23)
            {
                StopAllCoroutines();
            }
            else if (status == 24)
            {
                StopAllCoroutines();
            }
            else
            {
                CutChange();
                status++;
                PlayStory(status);
            }
        }
    }

    IEnumerator Speech1()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechStartSet(badboyBox));
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        badboyText.DOText(Narration_Script.Instance.Narration1, 1.5f).SetEase(Ease.Linear);       
        Narration_Script.Instance.inputAllowed = true;       
        yield return new WaitForSeconds(1.6f);
        npcMove[1].transform.DOMove(new Vector3(0.478f, 0.233f, 1.616f), 0.7f).SetEase(Ease.Linear);
        npcMove[3].transform.DOMove(new Vector3(2.142f, 0.215f, 1.887f), 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        npcMove[2].transform.DOMove(new Vector3(1.838f, 0.168f, 0.713f), 0.88f).SetEase(Ease.Linear);         
        npcMove[0].transform.DORotate(new Vector3(0f, 179f, 0f), 1.0f).SetEase(Ease.Linear);
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech2()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        badboyText.DOText(Narration_Script.Instance.Narration2, 1.5f).SetEase(Ease.Linear);       
        yield return new WaitForSeconds(1.6f);       
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech3()
    {
        StartCoroutine(SpeechStartSet(HodolBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));
        speechText.DOText(Narration_Script.Instance.Narration3, 1.5f).SetEase(Ease.Linear);        
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech4()
    {
        StartCoroutine(SpeechStartSet(SharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration4, 1.5f).SetEase(Ease.Linear);       
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech5()
    {
        StartCoroutine(SpeechStartSet(SharkBox));
        yield return new WaitForSeconds(0.5f);
        npcMove[1].transform.DORotate(new Vector3(80.74953f, -89.44968f, 3.186682e-05f),1.0f).SetEase(Ease.Linear);
        npcMove[1].transform.DOMove(new Vector3(0.496f, 0.383f, 1.616f), 1.0f).SetEase(Ease.Linear);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration5, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SoundManager._instance.Play_SE("collapse"));
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech6()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        npcMove[0].transform.DORotate(new Vector3(0f, -157.6633f, 0f), 1.0f).SetEase(Ease.Linear);
        npcMove[2].transform.DORotate(new Vector3(0f, -61.07986f, 0f), 1.0f).SetEase(Ease.Linear);
        npcMove[3].transform.DORotate(new Vector3(0f, -101.1365f, 0f), 1.0f).SetEase(Ease.Linear);
        StartCoroutine(SoundManager._instance.Play_SE("scream2"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration6, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
       
        NarrationChange();
    }

    IEnumerator Speech7()
    {
        StartCoroutine(SpeechStartSet(HodolBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration7, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech8()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration8, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech9()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration9, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        npcMove[0].transform.DOMove(new Vector3(0.473f, 0.144f, 2.81f), 1.0f).SetEase(Ease.Linear);
        npcMove[0].transform.DORotate(new Vector3(0f, -175.3599f, 0f), 1.0f).SetEase(Ease.Linear);

        npcMove[2].transform.DOMove(new Vector3(1.04f, 0.168f, 1.102f), 1.0f).SetEase(Ease.Linear);
        npcMove[2].transform.DORotate(new Vector3(0f, -67.25027f, 0f), 1.0f).SetEase(Ease.Linear);

        npcMove[3].transform.DOMove(new Vector3(1.328f, 0.215f, 1.911f), 1.0f).SetEase(Ease.Linear);
        npcMove[3].transform.DORotate(new Vector3(0f, -108.0127f, 0f), 1.0f).SetEase(Ease.Linear);

       
       
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech10()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration10, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech11()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration11, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        npcMove[0].transform.DOMove(new Vector3(-0.014f,0.144f,2.638f),0.5f).SetEase(Ease.Linear);
        npcMove[2].transform.DOMove(new Vector3(0.466f, -0.003f, 1.049f), 0.5f).SetEase(Ease.Linear);
        npcMove[2].transform.DORotate(new Vector3(0f, -30.0f, 0f), 0.5f).SetEase(Ease.Linear);
        npcMove[3].transform.DOMove(new Vector3(0.599f, 0.215f, 1.91f), 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.6f);
        npcAni[0].SetBool("actTracking", true);
        npcAni[2].SetBool("actTracking", true);
        npcAni[3].SetBool("actTracking", true);
        yield return new WaitForSeconds(6.0f);
        npcMove[1].transform.DORotate(new Vector3(-83.72971f, -153.4494f, -103.4845f), 3.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(3.0f);
        //prison3.SetActive(true);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
     
    IEnumerator Speech12()
    {
        StartCoroutine(SpeechStartSet(HodolBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration12, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech13()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration13, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech14()
    {
        StartCoroutine(SpeechStartSet(HodolBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration14, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech15()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration15, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech16()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration16, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
      
        prison2.SetActive(true);
        aricamera.SetActive(true);
        aricprimage.SetActive(true);
        JJapari.SetActive(true);
        JJapshark.SetActive(true);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        StartCoroutine(SpeechEndSet());
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        aricamera.SetActive(false);
        aricprimage.SetActive(false);
        JJapari.SetActive(false);
        JJapshark.SetActive(false);
        StartCoroutine(SpeechEndSet());
        NarrationChange();

    }
    IEnumerator Speech17()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration17, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        aricamera2.SetActive(true);
        aricprimage2.SetActive(true);
        JJapari2.SetActive(true);
        JJapshark2.SetActive(true);
        JJapari2.transform.DOMove(new Vector3(26.861f, 0.439f, 2.126f), 1.0f);
        yield return new WaitForSeconds(2.0f);
        JJapari2.transform.DOMove(new Vector3(26.872f, 0.509f, 2.264f), 0.5f);
        yield return new WaitForSeconds(0.6f);
        JJapari2.transform.DOMove(new Vector3(26.861f, 0.439f, 2.126f), 1.0f);
        yield return new WaitForSeconds(2.0f);        
        aricamera2.SetActive(false);
        aricprimage2.SetActive(false);
        JJapari2.SetActive(false);
        JJapshark2.SetActive(false);                
        StartCoroutine(SpeechEndSet());               
        yield return new WaitForSeconds(1.0f);     
        NarrationChange();
    }

    IEnumerator Speech18()
    {
        StartCoroutine(SpeechStartSet(HodolBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration18, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech19()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration19, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech20()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration20, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech21()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration21, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech22()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration22, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);       
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech23()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration23, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);       
        aricamera3.SetActive(true);
        aricprimage3.SetActive(true);
        JJapari3.SetActive(true);
        JJapshark3.SetActive(true);
        Aed2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        aedPad3.SetActive(true);
        aedPad3_1.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        JJapari3.transform.DOMove(new Vector3(25.608f, 0.451f, 2.751f), 1.0f);
        yield return new WaitForSeconds(2.0f);
        aricamera3.SetActive(false);
        aricprimage3.SetActive(false);
        JJapari3.SetActive(false);
        JJapshark3.SetActive(false);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech24()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration24, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
       
        aricamera.SetActive(true);
        aricprimage.SetActive(true);
        JJapari.SetActive(true);
        JJapshark.SetActive(true);
        aedPad1.SetActive(true);
        aedPad1_1.SetActive(true);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        StartCoroutine(SpeechEndSet());
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.891f, 0.453f, 2.45f), 0.2f);
        yield return new WaitForSeconds(0.2f);
        arimove.transform.DOMove(new Vector3(29.907f, 0.322f, 2.451f), 0.2f);
        aricamera.SetActive(false);
        aricprimage.SetActive(false);
        JJapari.SetActive(false);
        JJapshark.SetActive(false);
        aedPad1.SetActive(false);
        aedPad1_1.SetActive(false);
        StartCoroutine(SpeechEndSet());
        NarrationChange();

    }
    IEnumerator Speech25()
    {
        aricamera2.SetActive(true);
        aricprimage2.SetActive(true);
        JJapari2.SetActive(true);
        JJapshark2.SetActive(true);
        aedPad2.SetActive(true);
        aedPad2_1.SetActive(true);
        JJapari2.transform.DOMove(new Vector3(26.861f, 0.439f, 2.126f), 1.0f);
        yield return new WaitForSeconds(1.5f);       
        JJapari2.transform.DOMove(new Vector3(26.872f, 0.509f, 2.264f), 0.5f);
        yield return new WaitForSeconds(0.6f);        
        JJapari2.transform.DOMove(new Vector3(26.861f, 0.439f, 2.126f), 1.0f);
        yield return new WaitForSeconds(2.0f);        
        aricamera2.SetActive(false);
        aricprimage2.SetActive(false);
        JJapari2.SetActive(false);
        JJapshark2.SetActive(false);        
        aedPad2.SetActive(false);
        aedPad2_1.SetActive(false);

        StartCoroutine(SpeechStartSet(SharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("choke"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration25, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        npcMove[1].transform.DORotate(new Vector3(0.3769203f, 76.8704f, -6.965942f), 1.0f).SetEase(Ease.Linear);
        npcMove[1].transform.DOMove(new Vector3(-0.245f, 0.013f, 1.741f), 1.0f).SetEase(Ease.Linear);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech26()
    {
        StartCoroutine(SpeechStartSet(HodolBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration26, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);      
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech27()
    {        
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration27, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);        
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech28()
    {
        npcAni[1].SetBool("actOK", true);
        StartCoroutine(SpeechStartSet(SharkBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration28, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        npcAni[1].SetBool("actOK", false);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }


    IEnumerator Quest1()
    {
        Narration_Script.Instance.inputAllowed = false;
        //yield return new WaitForSeconds(2f);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Quest[0], 1.5f).SetEase(Ease.Linear);
        Narration_Script.Instance.inputAllowed = true;
        yield return new WaitForSeconds(3.0f);                
        StartCoroutine(NarrationEndSet());
       // prison3_1.SetActive(true);
        prison3_2.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        prison.SetActive(false);
        NarrationChange();
    }

    IEnumerator Quest2()
    {
        Narration_Script.Instance.inputAllowed = false;
        //yield return new WaitForSeconds(2f);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Quest[1], 1.5f).SetEase(Ease.Linear);
        Narration_Script.Instance.inputAllowed = true;
        yield return new WaitForSeconds(1.6f);
        npcMove[0].transform.DOMove(new Vector3(1.204f, 0.144f, 2.488f), 0.5f).SetEase(Ease.Linear);
        npcMove[0].transform.DORotate(new Vector3(0f, -120.6633f, 0f), 1.0f).SetEase(Ease.Linear);
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Quest3()
    {
        Narration_Script.Instance.inputAllowed = false;
        //yield return new WaitForSeconds(2f);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Quest[2], 1.5f).SetEase(Ease.Linear);
        Narration_Script.Instance.inputAllowed = true;
        yield return new WaitForSeconds(1.6f);       
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Quest4()
    {
        StartCoroutine(SoundManager._instance.Play_SE("item"));
        Aed1.SetActive(false);
        yield return new WaitForSeconds(2f);
        Narration_Script.Instance.inputAllowed = false;
        //yield return new WaitForSeconds(2f);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));
        narrationText.DOText(Narration_Script.Instance.Quest[3], 1.5f).SetEase(Ease.Linear);
        Narration_Script.Instance.inputAllowed = true;
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }



    IEnumerator End_1()
    {
        
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));         //나레이션 소리
        narrationText.DOText(Narration_Script.Instance.Narration_End1, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(NarrationEndSet());
      
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator End_2()
    {
        NarrationStartSet();
        SoundManager._instance.Play_BGM("BGM_02", false);
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));         //나레이션 소리
        narrationText.DOText(Narration_Script.Instance.Narration_End2, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        SoundManager._instance.Play_Voice("goodjob");
        yield return new WaitForSeconds(1.9f);
        SoundManager._instance.StopBGM();
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        //  NarrationChange();
        SceneManager.LoadScene(0);
    }

    void NarrationStartSet()
    {
        narrationBox.SetActive(true);
        narrationText.text = "";
    }

    IEnumerator NarrationEndSet()
    {
        _statusCompleted = true;
        yield return new WaitForSeconds(2f);
        CompleteAnimation(status);
    }


    IEnumerator SpeechStartSet(GameObject characterBox)
    {
        narrationBox.SetActive(false);
        speechBox.SetActive(false);
        AriBox.SetActive(false);
      
        badboyBox.SetActive(false);
        HodolBox.SetActive(false);
        QuestBox.SetActive(false);
        badboySpeechBox.SetActive(false);
        Narration_Script.Instance.inputAllowed = false;

        if (characterBox == badboyBox)
        {
            badboySpeechBox.SetActive(true);
            badboySpeechBox.transform.localScale = new Vector3(0, 0, 0);
            badboyText.text = "";
            badboySpeechBox.transform.DOScale(badboySpeechBoxSize, 0.2f);
            badboyBox.SetActive(true);
            badboyBox.transform.localScale = new Vector3(0, 0, 0);
            characterBox.transform.DOScale(badboyBoxSize, 0.2f);
            yield return new WaitForSeconds(0.2f);
            badboySpeechBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            badboyBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            yield return new WaitForSeconds(0.3f);
        }
        else if (characterBox == AriBox)
        {
            speechBox.SetActive(true);
            speechBox.transform.localScale = new Vector3(0, 0, 0);
            speechText.text = "";
            speechBox.transform.DOScale(speechBoxSize, 0.2f);
            AriBox.SetActive(true);
            AriBox.transform.localScale = new Vector3(0, 0, 0);
            characterBox.transform.DOScale(AriBoxSize, 0.2f);
            yield return new WaitForSeconds(0.2f);
            speechBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            AriBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            yield return new WaitForSeconds(0.3f);
        }
        else if (characterBox == HodolBox)
        {
            speechBox.SetActive(true);
            speechBox.transform.localScale = new Vector3(0, 0, 0);
            speechText.text = "";
            speechBox.transform.DOScale(speechBoxSize, 0.2f);
            HodolBox.SetActive(true);
            HodolBox.transform.localScale = new Vector3(0, 0, 0);
            characterBox.transform.DOScale(AriBoxSize, 0.2f);
            yield return new WaitForSeconds(0.2f);
            speechBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            AriBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            yield return new WaitForSeconds(0.3f);
        }
        else if (characterBox == SharkBox)
        {
            speechBox.SetActive(true);
            speechBox.transform.localScale = new Vector3(0, 0, 0);
            speechText.text = "";
            speechBox.transform.DOScale(speechBoxSize, 0.2f);
            SharkBox.SetActive(true);
            SharkBox.transform.localScale = new Vector3(0, 0, 0);
            characterBox.transform.DOScale(AriBoxSize, 0.2f);
            yield return new WaitForSeconds(0.2f);
            speechBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            AriBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            yield return new WaitForSeconds(0.3f);
        }

        Narration_Script.Instance.inputAllowed = true;
    }

    IEnumerator SpeechEndSet()
    {
        _statusCompleted = true;
        badboyBox.SetActive(false);
        badboySpeechBox.SetActive(false);
        yield return new WaitForSeconds(2f);
        CompleteAnimation(status);
    }

    void SpeechRepeatSet(GameObject characterBox)
    {
        speechBox.SetActive(true);
        speechText.text = "";
        badboySpeechBox.SetActive(true);
        badboyText.text = "";
        characterBox.SetActive(true);
        HodolBox.SetActive(true);
        SharkBox.SetActive(true);
       
    }

    IEnumerator QuestEndSet()
    {
        _statusCompleted = true;
        yield return new WaitForSeconds(2f);
        CompleteAnimation(status);
    }

    void QuestStartSet()
    {
        badboyBox.SetActive(false);
        badboySpeechBox.SetActive(false);
        QuestBox.SetActive(true);
        QuestText.text = "";
    }

    public void RestartGame(bool _main)
    {
        if (_main)
        {

            fader.DOFade(1, 0.5f).OnComplete(MainScene);
        }
        else
        {
            fader.DOFade(1, 0.5f).OnComplete(NowScene);
        }
    }

    public void TrackedOut()
    {
        CutChange();
        DOTween.KillAll();
    }


    void CutChange()
    {
        StopAllCoroutines();
        _statusCompleted = false;

        narrationText.text = "";
        narrationBox.SetActive(false);

        QuestText.text = "";
        QuestBox.SetActive(false);

        speechText.text = "";
        speechBox.SetActive(false);


        HodolBox.SetActive(false);
        AriBox.SetActive(false);
      
        badboyText.text = "";
        badboyBox.SetActive(false);

        SharkBox.SetActive(false);

    }

  

    void MainScene()
    {
        SceneManager.LoadScene(0);
        //Debug.Log(SceneManager.GetActiveScene());
    }

    void NowScene()
    {
        SceneManager.LoadScene(5);
        // Debug.Log(SceneManager.GetActiveScene());
    }

    void SceneCh()
    {
        SceneManager.LoadScene(0);
    }

   

}