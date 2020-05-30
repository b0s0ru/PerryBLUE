using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _Instance = null;

    public static SoundManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }

    }

    void Awake()
    {
        _Instance = this;
    }


    public int audioSourceCount = 10;

    [SerializeField]
    [Header("clips"), Tooltip("BGMClip")]
    public AudioClip[] BGMs = new AudioClip[10];
    public AudioClip[] SFXs = new AudioClip[10];


    private AudioSource BGMsource;
    private AudioSource[] SFXsource;

    

    void OnEnable()
    {
        float volume = PlayerPrefs.GetFloat("volumeBGM", 1);

        BGMsource = gameObject.AddComponent<AudioSource>();
        BGMsource.volume = volume;
        BGMsource.playOnAwake = false;
        BGMsource.loop = true;

        //sfx 소스 초기화
        SFXsource = new AudioSource[audioSourceCount];

        volume = PlayerPrefs.GetFloat("volumeSFX", 1);

        for (int i = 0; i < SFXsource.Length; i++)
        {
            SFXsource[i] = gameObject.AddComponent<AudioSource>();
            SFXsource[i].playOnAwake = false;
            SFXsource[i].volume = volume;
        }


     
    }

    /**********SFX***********/

    public void PlaySFX(string name, bool loop = false, float pitch = 1)//효과음 재생
    {
        for (int i = 0; i < SFXs.Length; i++)
        {
            if (SFXs[i].name == name)
            {
                AudioSource a = GetEmptySource();
                a.loop = loop;
                a.pitch = pitch;
                a.clip = SFXs[i];
                a.Play();
                return;
            }
        }
    }

    public void StopSFXByName(string name)
    {
        for (int i = 0; i < SFXsource.Length; i++)
        {
            if (SFXsource[i].clip.name == name)
                SFXsource[i].Stop();
        }
    }

    private AudioSource GetEmptySource()//비어있는 오디오 소스 반환
    {
        int lageindex = 0;
        float lageProgress = 0;
        for (int i = 0; i < SFXsource.Length; i++)
        {
            if (!SFXsource[i].isPlaying)
            {
                return SFXsource[i];
            }

            //만약 비어있는 오디오 소스를 못찿으면 가장 진행도가 높은 오디오 소스 반환(루프중인건 스킵)

            float progress = SFXsource[i].time / SFXsource[i].clip.length;
            if (progress > lageProgress && !SFXsource[i].loop)
            {
                lageindex = i;
                lageProgress = progress;
            }
        }
        return SFXsource[lageindex];
    }

    /**********BGM***********/

    private AudioClip changeClip;//바뀌는 클립
    private bool isChanging = false;
    private float startTime;


    

    public void ChangeBGM(string name )
    { 

        changeClip = null;

        for (int i = 0; i < BGMs.Length; i++)//브금 클립 탐색
        {

            if (BGMs[i].name == name)
            {
                changeClip = BGMs[i];
            }
        }

        if (changeClip == null)//없으면 탈주
            return;

        
            BGMsource.clip = changeClip;
            BGMsource.Play();
        

    }

    private void Update()
    {
        if (!isChanging) return;

       

    }

    public void StopBGM()
    {
        BGMsource.Stop();
    }

    public void SetPitch(float pitch)
    {
        BGMsource.pitch = pitch;
    }


   
    //볼륨

    public void changeBGMVolume(float volume)
    {
        PlayerPrefs.SetFloat("volumeBGM", volume);
        BGMsource.volume = volume;
    }


    public void changeSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("volumeSFX", volume);
        for (int i = 0; i < SFXsource.Length; i++)
        {
            SFXsource[i].volume = volume;
        }
    }
}


