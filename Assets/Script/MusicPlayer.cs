using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Range(0f, 1f)] [SerializeField] float soundLevel = 1f;

    private void Awake()
    {
        //kan bruge GetType() istedet for MusicPlayer for at lave den mere generic.
        int musicPlayerCount = FindObjectsOfType<MusicPlayer>().Length;
        if (musicPlayerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = soundLevel;
    }
}
