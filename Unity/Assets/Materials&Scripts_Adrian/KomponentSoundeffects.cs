using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomponentSoundeffects : MonoBehaviour
{
    public enum ComponentSoundeffects { SirensAlarm, buttonPressed, crankPulled, nrOfElements}

    public AudioSource myAudioSource = null;
    public List<AudioClip> componentSoundEffectList;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void preLoadAudioSources()
    {
        for (int i = 0; i < (int)ComponentSoundeffects.nrOfElements; i++)
        {
            componentSoundEffectList.Add((AudioClip)Resources.Load(switchComponentSoundEffects((ComponentSoundeffects)i)));
        }
    }

    public void setComponentSoundEffects(ComponentSoundeffects incomingEnum)
    {
        myAudioSource.clip = componentSoundEffectList[(int)incomingEnum];
        myAudioSource.Play();
    }

    public string switchComponentSoundEffects(ComponentSoundeffects incomingEnum)
    {
        string convertedString = "";
        switch (incomingEnum)
        {
            case ComponentSoundeffects.SirensAlarm:
                convertedString = "Audio/Components/" + "SirensAlarm";
                return convertedString;
            case ComponentSoundeffects.buttonPressed:
                convertedString = "Audio/Components/" + "buttonPressed";
                return convertedString;
            case ComponentSoundeffects.crankPulled:
                convertedString = "Audio/Components/" + "crankPulled";
                return convertedString;
        }
        return convertedString;
    }
}
