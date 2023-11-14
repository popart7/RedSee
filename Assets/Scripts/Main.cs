using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject imageToFade, commentObj_1, commentObj_2, commentObj_3;
    public GameObject mapIntroObj, CommentariesObj, OpeningTimelineObj, IntroTimelineObj, CommentaryObj_1, CommentaryObj_2, CommentaryObj_3, PlayBtn, PauseBtn, whenInPlay, whenInPause, sea,playGlow,pauseGlow;
    public List<GameObject> MapIntroActivedObj, MapIntroDeavtivatedObj, CommentariesActivedObj, CommentariesDeavtivatedObj;
    public PlayableDirector OpeningTimeline, IntroTimeline, Commentary_1, Commentary_2, Commentary_3;
    public bool firstExodousClickFlag = false, secondExodousClickFlag = false;
    float glowWait = 0.25f;
    public GameObject commenteryLight;
    // Start is called before the first frame update

    private static Main _instance;

    public static Main Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MapIntroStartingState()
    {
        foreach (GameObject obj in MapIntroActivedObj)
        {

            obj.SetActive(true);
        }

        foreach (GameObject obj in MapIntroDeavtivatedObj)
        {
            obj.SetActive(false);
        }
    }

    public void CommentariesStartingState()
    {
        foreach (GameObject obj in CommentariesActivedObj)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in CommentariesDeavtivatedObj)
        {
            obj.SetActive(false);
        }
    }

    public void stopingTimlinesOnTargetLost()
    {

        firstExodousClickFlag = false;
        secondExodousClickFlag = false;
        OpeningTimeline.time = 0;
        OpeningTimeline.Play();

        IntroTimeline.time = 0;
        Commentary_1.time = 0;
        Commentary_2.time = 0;
        Commentary_3.time = 0;

        IntroTimeline.Play();
        Commentary_1.Play();
        Commentary_2.Play();
        Commentary_3.Play();
        StartCoroutine(stopingTimelines());
    }

    IEnumerator stopingTimelines()
    {
        yield return new WaitForSeconds(0.1f);
        OpeningTimeline.Stop();
        IntroTimeline.Stop();
        Commentary_1.Stop();
        Commentary_2.Stop();
        Commentary_3.Stop();
        OpeningTimelineObj.SetActive(false);
        IntroTimelineObj.SetActive(false);
        CommentaryObj_1.SetActive(false);
        CommentaryObj_2.SetActive(false);
        CommentaryObj_3.SetActive(false);
    }

    public void onPlayClick(bool flag)
    {
        Debug.Log("Play Btn Working");

        StartCoroutine(playClickRoutine(flag));


    }

    public void onPauseClick()
    {
        Debug.Log("Pause Btn Working");

        StartCoroutine(pauseClickRoutine());

    }

    public void onFirstLearMoreClick()
    {
        
        fadingEffect();
        if (IntroTimeline.state == PlayState.Playing)
        {
            onPauseClick();
        }


        StartCoroutine(FirstLearMoreRoutine());

    }
    public void onSecondLearMoreClick()
    {
       
        if (IntroTimeline.state == PlayState.Playing)
        {
            onPauseClick();
        }

        StartCoroutine(SecondLearMoreRoutine());
    }
    public void onThirdLearMoreClick()
    {
        
        if (IntroTimeline.state == PlayState.Playing)
        {
            onPauseClick();
        }


        StartCoroutine(ThirdLearMoreRoutine());
    }
    IEnumerator FirstLearMoreRoutine()
    {
       
        
        commentObj_1.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
        yield return new WaitForSeconds(glowWait);
        commentObj_1.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

        fadingEffect();
        yield return new WaitForSeconds(2f);
        mapIntroObj.SetActive(false);
        CommentariesStartingState();
        CommentariesObj.SetActive(true);
        CommentaryObj_1.SetActive(true);

        yield return new WaitForSeconds(2.7f);
        // Commentary_1.Play();

        while (/**Commentary_1.state == PlayState.Playing &&**/ Commentary_1.time < 50f)
        {
            yield return null;

        }
        fadingEffect();


        yield return new WaitForSeconds(2f);

        Commentary_1.time = 0;
        Commentary_1.Play();
        yield return new WaitForSeconds(0.1f);
        Commentary_1.Stop();
        CommentaryObj_1.SetActive(false);


        mapIntroObj.SetActive(true);
        CommentariesObj.SetActive(false);
        CommentaryObj_1.SetActive(false);
        IntroTimeline.Play();
        yield return new WaitForSeconds(0.01f);
        IntroTimeline.Pause();


    }

    IEnumerator SecondLearMoreRoutine()
    {
        
      
        commentObj_2.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
        yield return new WaitForSeconds(glowWait);
        commentObj_2.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

        fadingEffect();
        yield return new WaitForSeconds(2f);
        mapIntroObj.SetActive(false);
        CommentariesStartingState();
        CommentariesObj.SetActive(true);
        CommentaryObj_2.SetActive(true);

        yield return new WaitForSeconds(2.7f);
       
        //Commentary_2.Play();


        while (/**Commentary_2.state == PlayState.Playing   && * */Commentary_2.time < 35f)
        {
            yield return null;
        }

        fadingEffect();
        yield return new WaitForSeconds(2f);
        mapIntroObj.SetActive(true);
        CommentariesObj.SetActive(false);
        CommentaryObj_2.SetActive(false);
        IntroTimeline.Play();
        yield return new WaitForSeconds(0.001f);
        IntroTimeline.Pause();

    }

    IEnumerator ThirdLearMoreRoutine()
    {
       
     
        commentObj_3.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
        yield return new WaitForSeconds(glowWait);
        commentObj_3.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

        fadingEffect();
        yield return new WaitForSeconds(2f);
        mapIntroObj.SetActive(false);
         CommentariesStartingState();
        CommentariesObj.SetActive(true);
        CommentaryObj_3.SetActive(true);

        yield return new WaitForSeconds(2.5f);
     


        while (/**Commentary_3.state == PlayState.Playing && **/ Commentary_3.time < 50f)
        {
            yield return null;
        }
        fadingEffect();
        yield return new WaitForSeconds(2f);
        mapIntroObj.SetActive(true);
        CommentariesObj.SetActive(false);
        CommentaryObj_3.SetActive(false);
        IntroTimeline.Play();
        yield return new WaitForSeconds(0.001f);
        IntroTimeline.Pause();
    }

    IEnumerator playClickRoutine(bool flag)
    {

        playGlow.SetActive(true);

        yield return new WaitForSeconds(glowWait);
        playGlow.SetActive(false);

        PlayBtn.SetActive(false);
        PauseBtn.SetActive(true);
        whenInPlay.SetActive(true);
        whenInPause.SetActive(false);

        if (IntroTimeline.state == PlayState.Paused && IntroTimelineObj.activeSelf)
        {
            IntroTimeline.Resume();
        }
        else if(flag)
        {
            MapIntroStartingState();
            mapIntroObj.SetActive(true);
            IntroTimelineObj.SetActive(true);
            IntroTimeline.time = 0;
            IntroTimeline.Play();
        }
        else
        {
            IntroTimelineObj.SetActive(true);
            IntroTimeline.Play();
        }
        while (IntroTimeline.state == PlayState.Playing && IntroTimeline.time < 175f)
        {
            Debug.Log("Playing");
            yield return null;
        }
        Debug.Log("Done Playing");
        if (IntroTimeline.state != PlayState.Paused)
        {

            Debug.Log(" After Done Playing");
            PauseBtn.SetActive(false);
            PlayBtn.SetActive(true);
            whenInPlay.SetActive(false);
            whenInPause.SetActive(true);
           // sea.SetActive(false);
            //yield return new WaitForSeconds(0.1f);
           // sea.SetActive(true);
            IntroTimeline.Stop();
            IntroTimeline.time = 0;
            IntroTimelineObj.SetActive(false);
            
           // StartCoroutine(playClickRoutine());
             onPlayClick(false);
           
            //  yield return new WaitForSeconds(0.0001f);
            //IntroTimeline.Stop();
           
        }
    }

    IEnumerator pauseClickRoutine()
    {
        pauseGlow.SetActive(true);

        yield return new WaitForSeconds(glowWait);
        pauseGlow.SetActive(false);

        PauseBtn.SetActive(false);
        PlayBtn.SetActive(true);
        whenInPlay.SetActive(false);
        whenInPause.SetActive(true);


        IntroTimeline.Pause();
    }
    public void onFirstExodusClick()
    {
        firstExodousClickFlag = true;
    }
    public void onSecondExodusClick()
    {
        secondExodousClickFlag = true;
    }

    public void fadeIn()
    {
        imageToFade.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
        imageToFade.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
    }

    public void fadeOut()
    {
        imageToFade.GetComponent<Image>().canvasRenderer.SetAlpha(1.0f);
        imageToFade.GetComponent<Image>().CrossFadeAlpha(0, 2, false);

    }

    public void fadingEffect()
    {
        StartCoroutine(startFadingEffect());
    }
    
    IEnumerator startFadingEffect()
    {
        imageToFade.SetActive(true);
        fadeIn();
        yield return new WaitForSeconds(3f);
        fadeOut();
        yield return new WaitForSeconds(2f);
        imageToFade.SetActive(false);
    }

    

}
