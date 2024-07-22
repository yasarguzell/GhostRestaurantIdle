using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class AudioElement
    {
        public string name;
        public AudioClip audioClip;
        public float volume;
        public float pitch;
        [Range(0.0f, 1.0f)] public float pitchRandomness;
        public bool isLooping;

        [HideInInspector]
        public Transform audioSourceTransform;
        [HideInInspector]
        public AudioSource audioSource;
    }

    [Header("Audio Elements")]
    [SerializeField] List<AudioElement> audioElementList = new List<AudioElement>();
    [Header("Audio Source Prefab")]
    [SerializeField] Transform audioSourcePrefab;

    private Dictionary<string, AudioElement> audioElementDictionary = new Dictionary<string, AudioElement>();

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < audioElementList.Count; i++)
        {
            AudioElement tempAudioSourceElement = audioElementList[i];
            Transform newAudioTransform= GameObject.Instantiate(audioSourcePrefab, this.transform);
            AudioSource newAudioSource = newAudioTransform.GetComponent<AudioSource>();

            tempAudioSourceElement.audioSourceTransform = newAudioTransform;
            tempAudioSourceElement.audioSource = newAudioSource;

            newAudioSource.clip = tempAudioSourceElement.audioClip;
            newAudioSource.volume = tempAudioSourceElement.volume;
            newAudioSource.pitch = tempAudioSourceElement.pitch + tempAudioSourceElement.pitch * Random.Range(-tempAudioSourceElement.pitchRandomness, tempAudioSourceElement.pitchRandomness);
            newAudioSource.loop = tempAudioSourceElement.isLooping;
            newAudioSource.playOnAwake = tempAudioSourceElement.isLooping;
            if (tempAudioSourceElement.isLooping)
            {
                newAudioSource.Play();
            }
            
            audioElementDictionary.Add(tempAudioSourceElement.name, tempAudioSourceElement);
        }
    }

    public void PlaySound(string name)
    {
        AudioElement tempAudioElement = audioElementDictionary[name];

        if (tempAudioElement != null)
        {
            AudioSource tempAudioSource = tempAudioElement.audioSource;

            if (tempAudioSource.isPlaying)
            {
                RestartAudioSource(tempAudioSource);
            }
            else
            {
                tempAudioSource.Play(); 
            }
        }
    }

    private void RestartAudioSource(AudioSource aS)
    {
        aS.Stop();
        aS.Play();
    }
}
