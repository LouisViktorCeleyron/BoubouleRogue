using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class AudioManager : Manager
{
    [SerializeField]
    private AudioSource _musicSource,_tempMusicSource;
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

    public void LoadSfx(AudioClip sfxClip)
    {
        var availableAS = _sfxSources.Find((AudioSource asource) => !asource.isPlaying);
        if (availableAS != null) 
        { 
            availableAS.clip = sfxClip;
            availableAS.time =0;
            availableAS?.Play();
        }
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


    public void LoadTempMusic(string musicName)
    {
        var tryGetMusic = _musics[musicName];
        if (tryGetMusic != null)
        {
            _tempMusicSource.clip = tryGetMusic;
            _musicSource.Pause();
            _tempMusicSource.Play();
        }
    }

    public void ContinueMusic()
    {
        if(_tempMusicSource.isPlaying)
        {
            _tempMusicSource.Stop();
            _musicSource.Play();
        }
    }

    public override void ManagerOnEachSceneLeft(Scene scene)
    {
        ContinueMusic();
    }
}
