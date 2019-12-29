using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class VR_SchoolViolence : MonoBehaviour       //폭력 VR
{
    public static int status = 0;
    public bool _sceneFinished = false;
    bool _statusCompleted = false;
    int selectedNumber;
    bool bPaused = false;

    //대화 상자
    public GameObject GiraBox;
    public GameObject HodolBox;
    public GameObject narrationBox;
    public GameObject AriBox;
    public GameObject bad1;
    public GameObject bad2;
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
    public GameObject principal;
    public GameObject prison;
    public GameObject blood;
    public GameObject classroom;
    public GameObject teacher;
    public GameObject teleport;
    public GameObject teleport2;

    //캔버스
    public Image fader;
    public GameObject EndImage;

    //애니메이션
    public Animator[] npcmove;

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
                StartCoroutine(IntroCut());
                break;
            case 1:
                StartCoroutine(IntroCut2());
                break;
            case 2:
                StartCoroutine(Speech1());
                break;
            case 3:
                StartCoroutine(Speech2());
                break;
            case 4:
                StartCoroutine(Speech3());
                break;
            case 5:
                StartCoroutine(Speech4());
                break;
            case 6:
                StartCoroutine(Speech5());
                break;
            case 7:
                StartCoroutine(Quest1());
                break;
            case 8:
                StartCoroutine(Speech6());
                break;
            case 9:
                StartCoroutine(Speech7());
                break;
            case 10:
                StartCoroutine(Speech8());
                break;
            case 11:
                StartCoroutine(Speech9());
                break;
            case 12:
                StartCoroutine(Quest2());
                break;
            case 13:
                StartCoroutine(Speech10());
                break;
            case 14:
                StartCoroutine(Speech11());
                break;
            case 15:
                StartCoroutine(Speech12());
                break;
            case 16:
                StartCoroutine(Speech13());
                break;
            case 17:
                StartCoroutine(Quest3());
                break;
            case 18:
                StartCoroutine(Speech14());
                break;
            case 19:
                StartCoroutine(Speech15());
                break;
            case 20:
                StartCoroutine(Speech16());
                break;
            case 21:
                StartCoroutine(Speech17());
                break;
            case 22:
                StartCoroutine(Speech18());
                break;
            case 23:
                StartCoroutine(Speech19());
                break;
            case 24:
                StartCoroutine(Speech20());
                break;
            case 25:
                StartCoroutine(Quest4());
                break;
            case 26:
                StartCoroutine(Speech21());
                break;
            case 27:
                StartCoroutine(Speech22());
                break;
            case 28:
                StartCoroutine(Quest5());
                break;
            case 29:
                StartCoroutine(Speech23());
                break;
            case 30:
                StartCoroutine(Speech24());
                break;
            case 31:
                StartCoroutine(Speech25());
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
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration1;
                break;
            case 1:
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration2;
                break;
            case 2:
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration3;
                break;
            case 3:
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration4;
                break;
            case 4:
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration5;
                break;
            case 5:
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration6;
                break;
            case 6:

                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration7;
                break;
            case 7:

                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[0];
                break;

            case 8:

                speechBox.SetActive(true);
                AriBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration_Event;
                break;

            case 9:

                speechBox.SetActive(true);
                AriBox.SetActive(false);
                HodolBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration_Event2;
                break;
            case 10:

                speechBox.SetActive(true);
                AriBox.SetActive(true);
                HodolBox.SetActive(false);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration_Event3;
                break;

            case 11:

                speechBox.SetActive(true);
                AriBox.SetActive(false);
                HodolBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration_Event4;
                break;

            case 12:
                speechBox.SetActive(false);
                HodolBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[1];
                break;

            case 13:
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration_Event5;
                break;
            case 14:

                HodolBox.SetActive(false);
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration_Event6;
                break;
            case 15:

                HodolBox.SetActive(false);
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration_Event7;
                break;
            case 16:
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration_Event8;
                break;
            case 17:
                speechBox.SetActive(false);
                HodolBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[2];
                break;
            case 18:

                HodolBox.SetActive(false);
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration_Event9;
                break;
            case 19:

                HodolBox.SetActive(false);
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration8;
                break;
            case 20:
                speechBox.SetActive(true);
                AriBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration9;
                break;

            case 21:

                HodolBox.SetActive(false);
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration10;

                break;
            case 22:

                speechBox.SetActive(true);
                AriBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                badboyText.text = Narration_Script.Instance.Narration11;
                break;
            case 23:

                speechBox.SetActive(true);
                AriBox.SetActive(true);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration12;
                break;
            case 24:

                HodolBox.SetActive(false);
                speechBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                badboyText.text = Narration_Script.Instance.Narration13;
                break;
            case 25:
                speechBox.SetActive(false);
                HodolBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[4];
                break;
            case 26:

                speechBox.SetActive(true);
                GiraBox.SetActive(true);
                AriBox.SetActive(false);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration14;
                break;
            case 27:

                speechBox.SetActive(true);
                GiraBox.SetActive(true);
                AriBox.SetActive(false);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration15;
                break;

            case 28:
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Quest[5];
                break;
            case 29:

                speechBox.SetActive(true);
                GiraBox.SetActive(true);
                AriBox.SetActive(false);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration16;
                break;
            case 30:
                speechBox.SetActive(false);
                GiraBox.SetActive(false);
                AriBox.SetActive(false);
                badboyBox.SetActive(true);
                badboySpeechBox.SetActive(true);
                speechText.text = Narration_Script.Instance.Narration17;
                break;
            case 31:

                speechBox.SetActive(true);
                GiraBox.SetActive(true);
                AriBox.SetActive(false);
                badboyBox.SetActive(false);
                badboySpeechBox.SetActive(false);
                speechText.text = Narration_Script.Instance.Narration18;
                break;
            case 32:
                speechBox.SetActive(false);
                HodolBox.SetActive(false);
                narrationBox.SetActive(true);
                narrationText.text = Narration_Script.Instance.Narration_End1;
                break;
            case 33:
                speechBox.SetActive(false);
                HodolBox.SetActive(false);
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
            else if (status == 12)
            {
                StopAllCoroutines();
            }
            else if (status == 17)
            {
                StopAllCoroutines();
            }
            else if (status == 25)
            {
                StopAllCoroutines();
            }
            else if (status == 28)
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

    IEnumerator IntroCut()
    {
        Narration_Script.Instance.inputAllowed = false;
        teleport.SetActive(false);
        yield return new WaitForSeconds(2f);
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("schoolbell"));   //학교종소리
        //SoundManager._instance.AudioSource_clear();               // 오디오 클립 지울때.
        narrationText.DOText(Narration_Script.Instance.Narration1, 1.5f).SetEase(Ease.Linear);
        Narration_Script.Instance.inputAllowed = true;
        yield return new WaitForSeconds(1.6f);
        npcmove[0].SetBool("actWalk", true);
        npcmove[1].SetBool("actWalk", true);
        yield return new WaitForSeconds(0.1f);
        npcmove[0].transform.DOMove(new Vector3(5.694f, -0.7f, -8.736f), 3.3f).SetEase(Ease.Linear);
        npcmove[1].transform.DOMove(new Vector3(4.975f, -0.7f, -9.06f), 3.3f).SetEase(Ease.Linear);
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator IntroCut2()
    {
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));         //나레이션 소리
        narrationText.DOText(Narration_Script.Instance.Narration2, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech1()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        npcmove[0].SetBool("actWalk", false);
        npcmove[1].SetBool("actWalk", false);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        //  speechText.DOText(Narration_Script.Instance.Narration3, 2f).SetEase(Ease.Linear);
        badboyText.DOText(Narration_Script.Instance.Narration3, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech2()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration4, 2f).SetEase(Ease.Linear);
        // speechText.DOText(Narration_Script.Instance.Narration4, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech3()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration5, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech4()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        npcmove[0].SetBool("actPunch", true);
        npcmove[1].SetBool("actPunch", true);
        yield return new WaitForSeconds(0.1f);
        //불나는 소리
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration6, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        npcmove[0].SetBool("actPunch", false);
        npcmove[1].SetBool("actPunch", false);
        NarrationChange();
    }

    IEnumerator Speech5()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration7, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech6()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration_Event, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech7()
    {
        StartCoroutine(SpeechStartSet(HodolBox));
        npcmove[2].transform.DORotate(new Vector3(0f, 87.0f, 0f), 1.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration_Event2, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech8()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration_Event3, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }
    IEnumerator Speech9()
    {
        StartCoroutine(SpeechStartSet(HodolBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration_Event4, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech10()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration_Event5, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech11()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        npcmove[0].SetBool("actPunch", false);
        npcmove[1].SetBool("actPunch", false);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration_Event6, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech12()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration_Event7, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech13()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration_Event8, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech14()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        bad1.SetActive(true);
        bad2.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        StartCoroutine(SoundManager._instance.Play_SE("wind"));
        npcmove[0].transform.DORotate(new Vector3(0f, -157f, 0f), 0.3f).SetEase(Ease.Linear);
        npcmove[1].transform.DORotate(new Vector3(0f, 179f, 0f), 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration_Event9, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech15()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration8, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech16()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration9, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech17()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration10, 2f).SetEase(Ease.Linear);
        npcmove[0].SetBool("actPunch", true);
        npcmove[1].SetBool("actPunch", true);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        npcmove[0].SetBool("actPunch", false);
        npcmove[1].SetBool("actPunch", false);
        NarrationChange();
    }

    IEnumerator Speech18()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        yield return new WaitForSeconds(1.1f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration11, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.6f);
        npcmove[0].SetBool("actKick2", true);
        npcmove[1].SetBool("actKick3", true);
        yield return new WaitForSeconds(2.6f);
        StartCoroutine(SoundManager._instance.Play_SE("beat"));
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(SoundManager._instance.Play_SE("struggle"));
        blood.SetActive(true);
        npcmove[0].SetBool("actKick2", false);
        npcmove[1].SetBool("actKick3", false);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        npcmove[0].transform.DOMove(new Vector3(6.2f, 7.56f, 29.55f), 0.3f).SetEase(Ease.Linear);
        npcmove[1].transform.DOMove(new Vector3(5.2f, 7.56f, 29.55f), 0.3f).SetEase(Ease.Linear);
        NarrationChange();
    }

    IEnumerator Speech19()
    {
        StartCoroutine(SpeechStartSet(AriBox));
        npcmove[0].SetBool("actKick", true);
        yield return new WaitForSeconds(0.1f);
        npcmove[1].SetBool("actKick", true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration12, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.1f);
        StartCoroutine(SoundManager._instance.Play_SE("beatmassive"));
        yield return new WaitForSeconds(1.1f);
        npcmove[0].SetBool("actKick", false);
        npcmove[1].SetBool("actKick", false);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }


    IEnumerator Speech20()
    {
        StartCoroutine(SpeechStartSet(badboyBox));
        StartCoroutine(SoundManager._instance.Play_SE("laughat"));
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration13, 1.0f).SetEase(Ease.Linear);
        npcmove[0].transform.DORotate(new Vector3(0f, -90f, 0f), 1.3f).SetEase(Ease.Linear);
        npcmove[1].transform.DORotate(new Vector3(0f, -90f, 0f), 1.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.5f);
        npcmove[0].SetBool("actWalk", true);
        npcmove[1].SetBool("actWalk", true);
        npcmove[0].transform.DOMove(new Vector3(-16.69f, 6.21f, 37.27f), 8.3f).SetEase(Ease.Linear);
        npcmove[1].transform.DOMove(new Vector3(-15.35f, 6.21f, 37.27f), 8.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(7.5f);
        npcmove[0].SetBool("actWalk", false);
        npcmove[1].SetBool("actWalk", false);
        StartCoroutine(SpeechEndSet());
        bad1.SetActive(false);
        bad2.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech21()
    {
        blood.SetActive(false);
        npcmove[3].SetBool("actHear", true);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SpeechStartSet(GiraBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration14, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech22()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SpeechStartSet(GiraBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration15, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech23()
    {
        npcmove[3].SetBool("actHear", false);
        principal.SetActive(false);
        classroom.SetActive(true);
        bad1.SetActive(true);
        bad2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        npcmove[0].transform.DORotate(new Vector3(0f, 90f, 0f), 0.3f).SetEase(Ease.Linear);
        npcmove[1].transform.DORotate(new Vector3(0f, 90f, 0f), 0.3f).SetEase(Ease.Linear);
        npcmove[2].transform.DORotate(new Vector3(0f, -90f, 0f), 0.3f).SetEase(Ease.Linear);
        teacher.transform.DORotate(new Vector3(0f, 90f, 0f), 0.3f).SetEase(Ease.Linear);
        StartCoroutine(SpeechStartSet(GiraBox));
        yield return new WaitForSeconds(0.5f);
        npcmove[3].SetBool("actHear", true);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration16, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        npcmove[0].SetBool("actCry", true);
        npcmove[1].SetBool("actCry", true);
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech24()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SpeechStartSet(badboyBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        badboyText.DOText(Narration_Script.Instance.Narration17, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(SpeechEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Speech25()
    {
        npcmove[3].SetBool("actHear", false);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SpeechStartSet(GiraBox));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SoundManager._instance.Play_SE("speech"));       //대화창 소리
        speechText.DOText(Narration_Script.Instance.Narration18, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.5f);
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
        yield return new WaitForSeconds(1.6f);       
        SoundManager._instance.Play_Voice("violence1");
        npcmove[0].transform.DORotate(new Vector3(0f, 0f, 0f), 1.3f).SetEase(Ease.Linear);
        npcmove[1].transform.DORotate(new Vector3(0f, 0f, 0f), 1.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        npcmove[0].SetBool("actWalk", true);
        npcmove[1].SetBool("actWalk", true);
        yield return new WaitForSeconds(0.1f);
        npcmove[0].transform.DOMove(new Vector3(4.82f, -0.7f, 0.14f), 3.3f).SetEase(Ease.Linear);
        npcmove[1].transform.DOMove(new Vector3(4.76f, -0.7f, 0.91f), 3.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(3.3f);
        npcmove[0].SetBool("actWalk", false);
        npcmove[1].SetBool("actWalk", false);
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        npcmove[1].transform.DORotate(new Vector3(0f, 179f, 0f), 1.3f).SetEase(Ease.Linear);
        NarrationChange();
    }

    IEnumerator Quest2()
    {
        NarrationStartSet();
        npcmove[0].SetBool("actPunch", true);
        npcmove[1].SetBool("actPunch", true);
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));         //나레이션 소리
        narrationText.DOText(Narration_Script.Instance.Quest[1], 1.5f).SetEase(Ease.Linear);       
        yield return new WaitForSeconds(2.0f);
        
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Quest3()
    {
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));         //나레이션 소리
        narrationText.DOText(Narration_Script.Instance.Quest[2], 1.5f).SetEase(Ease.Linear);
        npcmove[0].transform.DORotate(new Vector3(0f, -100f, 0f), 0.5f).SetEase(Ease.Linear);
        npcmove[1].transform.DORotate(new Vector3(0f, -100f, 0f), 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        teleport.SetActive(true);
        npcmove[0].SetBool("actWalk", true);
        npcmove[1].SetBool("actWalk", true);
        yield return new WaitForSeconds(0.1f);
        npcmove[0].transform.DOMove(new Vector3(-0.28f, -0.7f, 1.25f), 1.7f).SetEase(Ease.Linear);
        npcmove[1].transform.DOMove(new Vector3(-1.084f, -0.7f, 1.008f), 1.7f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.3f);        
        SoundManager._instance.Play_Voice("violence2");
        npcmove[0].SetBool("actWalk", false);
        npcmove[1].SetBool("actWalk", false);
        bad1.SetActive(false);
        bad2.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(NarrationEndSet());
        prison.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Quest4()
    {
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));         //나레이션 소리
        narrationText.DOText(Narration_Script.Instance.Quest[3], 1.5f).SetEase(Ease.Linear);        
        yield return new WaitForSeconds(2.0f);
        SoundManager._instance.Play_Voice("violence3");
        StartCoroutine(NarrationEndSet());
        yield return new WaitForSeconds(1.0f);
        NarrationChange();
    }

    IEnumerator Quest5()
    {
        NarrationStartSet();
        StartCoroutine(SoundManager._instance.Play_SE("keyboard"));         //나레이션 소리
        narrationText.DOText(Narration_Script.Instance.Quest[4], 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(NarrationEndSet());
        teleport2.SetActive(false);
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
        GiraBox.SetActive(false);
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
        else if (characterBox == GiraBox)
        {
           
            speechBox.SetActive(true);
            
            speechBox.transform.localScale = new Vector3(0, 0, 0);
            speechText.text = "";
            speechBox.transform.DOScale(speechBoxSize, 0.2f);
            GiraBox.SetActive(true);
            GiraBox.transform.localScale = new Vector3(0, 0, 0);
            characterBox.transform.DOScale(AriBoxSize, 0.2f);
            yield return new WaitForSeconds(0.2f);
            speechBox.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f);
            GiraBox.transform.DOPunchScale(new Vector3(0.01f, 0.01f, 0.01f), 0.3f);
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
        GiraBox.SetActive(true);
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
        GiraBox.SetActive(false);
        badboyText.text = "";
        badboyBox.SetActive(false);

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

    void OnApplicationPause(bool pause)

    {
        if (pause)
        {
            bPaused = true;
            status = 0;
            // todo : 어플리케이션을 내리는 순간에 처리할 행동들 /
        }
        else
        {
            if (bPaused)
            {
                bPaused = false;
                status = 0;
                //todo : 내려놓은 어플리케이션을 다시 올리는 순간에 처리할 행동들 
            }
        }

    }
    void OnApplicationQuit()

    {
        status = 0;
        // todo : 어플리케이션을 종료하는 순간에 처리할 행동들

    }


}