using UnityEngine;

public class Soundmanager : MonoBehaviour
{

    public static Soundmanager instance;

    public AudioClip audioClip;
    public AudioClip audioBGMClip;
    private AudioSource audioSource;
    private AudioSource audioSourceBGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceBGM = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayBGMSound()
    {
        audioSourceBGM.clip = audioBGMClip;
        audioSourceBGM.loop = true;
        audioSourceBGM.Play();
    }

    public void OnOffBGM(bool isOn)
    {
        if(isOn)
        {
            audioSourceBGM.volume = 1;
        }
        else
        {
            audioSourceBGM.volume = 0;
        }
    }

    public void OnOffFx(bool isOn)
    {
        if (isOn)
        {
            audioSource.volume = 1;
        }
        else
        {
            audioSource.volume = 0;
        }
    }

    public void ChangeBGMVolume(float volume)
    {
        audioSourceBGM.volume = volume;
    }

    public void ChangeFxVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
