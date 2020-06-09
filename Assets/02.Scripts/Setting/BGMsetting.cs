using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGMsetting : MonoBehaviour
{

    public float bgm;
    public float sfx;
    public Scrollbar bgms;
    public Scrollbar sfxs;
    // Start is called before the first frame update
    public void ON()
    {
        
        float volume = PlayerPrefs.GetFloat("volumeBGM", 1);
        bgms.value = volume;
        volume = PlayerPrefs.GetFloat("volumeSFX", 1);
        sfxs.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        bgm = bgms.value;
        sfx = sfxs.value;
    }
   
    public void Setting()
    {
        var sm = SoundManager.Instance;
        sm.changeBGMVolume(bgm);
        sm.changeSFXVolume(sfx);
    }
}
