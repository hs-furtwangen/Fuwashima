using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAndAmbientSoundManager : MonoBehaviour
{
    public static UIAndAmbientSoundManager staticInstance;

    public enum allMainAudioSourcesEnum { UI, Background, Announcer, nrOfElements}

    public enum UISoundeffects { Confirm, Decline, NextElement, nrOfElements}

    public enum BackgroundMusic { TitleScreen, MinimalDamge, MediumDamage, HighDamage, nrOfElements}

    public enum AnnouncerClips { Welcome, Panic, VC1, nrOFElements}

    private AudioSource[] allMainAudioSources;
    private List<AudioClip> uiSoundClips = new List<AudioClip>();
    private List<AudioClip> backgroundSoundeffects = new List<AudioClip>();
    private List<AudioClip> announcerSoundeffects = new List<AudioClip>();


    // Start is called before the first frame update
    void Start()
    {
        //UI and Ambient Soundeffects can be called through this, without making an extra reference 
        staticInstance = this;

        //Gets all AudioComponents on this GameObject
        allMainAudioSources = GetComponents<AudioSource>();
        
        //Pre load all AudioClips and add them to their corresponding Lists 
        preLoadAllMainClips();
    }

    public void preLoadAllMainClips()
    {
        for (int i = 0; i < (int)UISoundeffects.nrOfElements; i++)
        {
            uiSoundClips.Add((AudioClip)Resources.Load(switchUISoundEffects((UISoundeffects)i)));
        }

        for (int i = 0; i < (int)BackgroundMusic.nrOfElements; i++)
        {
            backgroundSoundeffects.Add((AudioClip)Resources.Load(switchBackgroundSoundEffects((BackgroundMusic)i)));
        }

        for (int i = 0; i < (int)AnnouncerClips.nrOFElements; i++)
        {
            announcerSoundeffects.Add((AudioClip)Resources.Load(switchAnnouncerSoundeffects((AnnouncerClips)i)));
        }
    }

    /*
     Use the AudioEnum of the corrsponding function to play the sound file 
    */
    public void setUISoundEffects(UISoundeffects incomingEnum)
    {
        allMainAudioSources[(int)allMainAudioSourcesEnum.UI].clip = uiSoundClips[(int)incomingEnum];
        allMainAudioSources[(int)allMainAudioSourcesEnum.UI].Play();
    }

    public void setBackgroundMusic(BackgroundMusic incomingEnum)
    {
        allMainAudioSources[(int)allMainAudioSourcesEnum.Background].clip = backgroundSoundeffects[(int)incomingEnum];
        allMainAudioSources[(int)allMainAudioSourcesEnum.Background].Play();
    }

    public void setAnouncerVoiceClip(AnnouncerClips incomingEnum)
    {
        allMainAudioSources[(int)allMainAudioSourcesEnum.Announcer].clip = announcerSoundeffects[(int)incomingEnum];
        allMainAudioSources[(int)allMainAudioSourcesEnum.Announcer].Play();
    }

    /*
     Fill the switch case like this, so that we can preload the audio clips
    */

    public string switchUISoundEffects(UISoundeffects incomingEnum)
    {
        string convertedString = "";

        switch (incomingEnum)
        {
            case UISoundeffects.Confirm:
                convertedString = "Audio/UIMain/" + "Confirm";
                return convertedString; ;
            case UISoundeffects.Decline:
                convertedString = "Audio/UIMain/" + "Decline";
                return convertedString;
            case UISoundeffects.NextElement:
                convertedString = "Audio/UIMain/" + "NextElement";
                return convertedString;
        }
        return convertedString;
    }

    public string switchBackgroundSoundEffects(BackgroundMusic incomingEnum)
    {
        string convertedString = "";
        switch (incomingEnum)
        {
            case BackgroundMusic.TitleScreen:
                convertedString = "Audio/BackgroundMain/" + "TitleScreen";
                return convertedString;
            case BackgroundMusic.MinimalDamge:
                convertedString = "Audio/BackgroundMain/" + "MinimalDamage";
                return convertedString;
            case BackgroundMusic.MediumDamage:
                convertedString = "Audio/BackgroundMain/" + "MediumDamage";
                return convertedString;
            case BackgroundMusic.HighDamage:
                convertedString = "Audio/BackgroundMain/" + "HighDamage";
                return convertedString;
        }
        return convertedString;
    }

    public string switchAnnouncerSoundeffects(AnnouncerClips incomingEnum)
    {
        string convertedString = "";
        switch (incomingEnum)
        {
            case AnnouncerClips.Welcome:
                convertedString = "Audio/Announcer/" + "Welcome";
                return convertedString;
            case AnnouncerClips.VC1:
                convertedString = "Audio/Announcer/" + "VC1";
                return convertedString;
            case AnnouncerClips.Panic:
                convertedString = "Audio/Announcer/" + "Panic";
                return convertedString;
        }
        return convertedString;
    }

}
