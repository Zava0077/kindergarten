using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;

    public List<AudioClip> clips = new List<AudioClip>();
    private AudioSource audioSource;
    public GameObject game;

    void Start()
    {
        audioSource = game.GetComponent<AudioSource>();
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySomeSounds()
    {
        int random = UnityEngine.Random.Range(0, clips.Count);
        audioSource.clip = clips[random];
        audioSource.Play();
    }
}
