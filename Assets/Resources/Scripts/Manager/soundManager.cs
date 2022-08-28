using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : Singletone<soundManager>
{
    [SerializeField]
    public Dictionary<string, AudioClip[]> soundEffects = new Dictionary<string, AudioClip[]>();

    [SerializeField]
    public Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    protected override void init()
    {
        base.init();
        
        soundEffects.Add("mudra",
            resourceManager.instance.resourceLoadAll<AudioClip>("SoundEffect/Mudra"));
        soundEffects.Add("ninjutsu",
            resourceManager.instance.resourceLoadAll<AudioClip>("SoundEffect/Ninjutsu"));
        soundEffects.Add("spell",
            resourceManager.instance.resourceLoadAll<AudioClip>("SoundEffect/Spell"));

        audioSources.Add("mudra", GameObject.Find("audioSourceMudra").GetComponent<AudioSource>());
        audioSources.Add("ninjutsu", GameObject.Find("audioSourceNinjutsu").GetComponent<AudioSource>());
        audioSources.Add("spell", GameObject.Find("audioSourceSpell").GetComponent<AudioSource>());

    }

    public override void setInfo()
    {
        base.setInfo();
    }

    public void playClip(string category, string effectName, int index)
    {
        if (!soundEffects.TryGetValue(effectName, out AudioClip[] clips) || 
            clips == null || clips.Length == 0)
            return ;
        if (!audioSources.TryGetValue(category, out AudioSource audioSource) ||
            audioSource == null)
            return ;
        audioSource.clip = clips[index];
        audioSource.Play();
    }

    public int clipLength(string name)
    {
        if (!soundEffects.TryGetValue(name, out AudioClip[] clips) ||
            clips == null || clips.Length == 0)
            return 0;
        return clips.Length;
    }


}
