using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class AudioManager : Manager
{
    [SerializeField]
    private AudioSource _musicSource;
    [SerializeField]
    private List<AudioSource> _sfxSources;

    [SerializeField]
    private MyDictionary<string, AudioClip> _musics;

    public override void ManagerPreAwake()
    {
        base.ManagerPreAwake();
    }

    public override void ManagerOnEachSceneStart(Scene scene)
    {
        base.ManagerOnEachSceneStart(scene);
    }

    public void LoadMusic(string musicName)
    {
        var tryGetMusic = _musics[musicName];
        if (tryGetMusic != null) 
        { 
            if(tryGetMusic == _musicSource.clip)
            {
                return;
            }
            _musicSource.clip = tryGetMusic;
            _musicSource.Play();
        }
    }
}
