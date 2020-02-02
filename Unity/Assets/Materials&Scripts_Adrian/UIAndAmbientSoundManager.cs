using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAndAmbientSoundManager : MonoBehaviour
{
    public static UIAndAmbientSoundManager staticInstance;

    public enum allMainAudioSourcesEnum { UI, Background, Announcer, nrOfElements}

    public enum UISoundeffects { Confirm, Decline, NextElement, nrOfElements}

    public enum BackgroundMusic { TitleScreen, MinimalDamge, MediumDamage, HighDamage, nrOfElements}

    public enum AnnouncerClips { bestYouCanDo, cantSeeStats, champ, Concentrate, DontTouchAnything, faithInTheLight, fate, GoodLiar, greatLetsSee, honeyLate, howCanWeFixThis, huge, hungry, inCaseOfAMeltdown, karenTookTheCode, keepInMind, leverOrButton, makeSomeLight, NoneOfThemWereRight, nope, notAnExplosion, nothingCanGoWrong, NothingPersonalKaren, Numberpad, OnKarensBachelorParty, OutWithABang, pressAndPull, pressButtonToStart, RandomCode, RepairFunctionality, ThatDidntWorkEither, theyDidWhat, ThreeButtons, tryAgain, Whooo, worldOnFire, yesButNo, Yesyesyes, nrOFElements}

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
        //allMainAudioSources[(int)allMainAudioSourcesEnum.Announcer].Stop();
        //allMainAudioSources[(int)allMainAudioSourcesEnum.Announcer].clip = announcerSoundeffects[(int)incomingEnum];
        //allMainAudioSources[(int)allMainAudioSourcesEnum.Announcer].Play();
        allMainAudioSources[(int)allMainAudioSourcesEnum.Announcer].PlayOneShot(announcerSoundeffects[(int)incomingEnum]);
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
            case AnnouncerClips.bestYouCanDo:
                convertedString = "Audio/Announcer/" + "bestYouCanDo";
                return convertedString;
            case AnnouncerClips.cantSeeStats:
                convertedString = "Audio/Announcer/" + "cantSeeStats";
                return convertedString;
            case AnnouncerClips.champ:
                convertedString = "Audio/Announcer/" + "champ";
                return convertedString;
            case AnnouncerClips.Concentrate:
                convertedString = "Audio/Announcer/" + "Concentrate";
                return convertedString;
            case AnnouncerClips.DontTouchAnything:
                convertedString = "Audio/Announcer/" + "DontTouchAnything";
                return convertedString;
            case AnnouncerClips.faithInTheLight:
                convertedString = "Audio/Announcer/" + "faithInTheLight";
                return convertedString;
            case AnnouncerClips.fate:
                convertedString = "Audio/Announcer/" + "fate";
                return convertedString;
            case AnnouncerClips.GoodLiar:
                convertedString = "Audio/Announcer/" + "GoodLiar";
                return convertedString;
            case AnnouncerClips.greatLetsSee:
                convertedString = "Audio/Announcer/" + "greatLetsSee";
                return convertedString;
            case AnnouncerClips.honeyLate:
                convertedString = "Audio/Announcer/" + "honeyLate";
                return convertedString;
            case AnnouncerClips.howCanWeFixThis:
                convertedString = "Audio/Announcer/" + "howCanWeFixThis";
                return convertedString;
            case AnnouncerClips.huge:
                convertedString = "Audio/Announcer/" + "huge";
                return convertedString;
            case AnnouncerClips.hungry:
                convertedString = "Audio/Announcer/" + "hungry";
                return convertedString;
            case AnnouncerClips.inCaseOfAMeltdown:
                convertedString = "Audio/Announcer/" + "inCaseOfAMeltdown";
                return convertedString;
            case AnnouncerClips.karenTookTheCode:
                convertedString = "Audio/Announcer/" + "karenTookTheCode";
                return convertedString;
            case AnnouncerClips.keepInMind:
                convertedString = "Audio/Announcer/" + "keepInMind";
                return convertedString;
            case AnnouncerClips.leverOrButton:
                convertedString = "Audio/Announcer/" + "leverOrButton";
                return convertedString;
            case AnnouncerClips.makeSomeLight:
                convertedString = "Audio/Announcer/" + "makeSomeLight";
                return convertedString;
            case AnnouncerClips.NoneOfThemWereRight:
                convertedString = "Audio/Announcer/" + "NoneOfThemWereRight";
                return convertedString;
            case AnnouncerClips.nope:
                convertedString = "Audio/Announcer/" + "nope";
                return convertedString;
            case AnnouncerClips.notAnExplosion:
                convertedString = "Audio/Announcer/" + "notAnExplosion";
                return convertedString;
            case AnnouncerClips.nothingCanGoWrong:
                convertedString = "Audio/Announcer/" + "nothingCanGoWrong";
                return convertedString;
            case AnnouncerClips.NothingPersonalKaren:
                convertedString = "Audio/Announcer/" + "NothingPersonalKaren";
                return convertedString;
            case AnnouncerClips.Numberpad:
                convertedString = "Audio/Announcer/" + "Numberpad";
                return convertedString;
            case AnnouncerClips.OnKarensBachelorParty:
                convertedString = "Audio/Announcer/" + "OnKarensBachelorParty";
                return convertedString;
            case AnnouncerClips.OutWithABang:
                convertedString = "Audio/Announcer/" + "OutWithABang";
                return convertedString;
            case AnnouncerClips.pressAndPull:
                convertedString = "Audio/Announcer/" + "pressAndPull";
                return convertedString;
            case AnnouncerClips.pressButtonToStart:
                convertedString = "Audio/Announcer/" + "pressButtonToStart";
                return convertedString;
            case AnnouncerClips.RandomCode:
                convertedString = "Audio/Announcer/" + "RandomCode";
                return convertedString;
            case AnnouncerClips.RepairFunctionality:
                convertedString = "Audio/Announcer/" + "RepairFunctionality";
                return convertedString;
            case AnnouncerClips.ThatDidntWorkEither:
                convertedString = "Audio/Announcer/" + "ThatDidntWorkEither";
                return convertedString;
            case AnnouncerClips.theyDidWhat:
                convertedString = "Audio/Announcer/" + "theyDidWhat";
                return convertedString;
            case AnnouncerClips.ThreeButtons:
                convertedString = "Audio/Announcer/" + "ThreeButtons";
                return convertedString;
            case AnnouncerClips.tryAgain:
                convertedString = "Audio/Announcer/" + "tryAgain";
                return convertedString;
            case AnnouncerClips.Whooo:
                convertedString = "Audio/Announcer/" + "Whooo";
                return convertedString;
            case AnnouncerClips.worldOnFire:
                convertedString = "Audio/Announcer/" + "worldOnFire";
                return convertedString;
            case AnnouncerClips.yesButNo:
                convertedString = "Audio/Announcer/" + "yesButNo";
                return convertedString;
            case AnnouncerClips.Yesyesyes:
                convertedString = "Audio/Announcer/" + "Yesyesyes";
                return convertedString;

        }
        return convertedString;
    }

    public void PlaySound(int i)
    {
        Debug.Log("Playing sound " +i);
        staticInstance.setAnouncerVoiceClip((AnnouncerClips)i);
    }

}
