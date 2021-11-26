using System;
using System.IO;
using UnityEngine;

namespace Shooty.Core
{
    public class VolumeController : MonoBehaviour
    {
        private static VolumeController _instance;
        public static VolumeController Instance { get { return _instance; } }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }


        [SerializeField] public float defaultVolume;
        [SerializeField] private AudioClip testClip;

        private static AudioSource musicPlayer;
        private static AudioSource sfxPlayer;

        private static float _defaultVolume { get; set; }
        public static float GetMusicVolume { get { return musicPlayer.volume; } }
        public static float GetSFXVolume { get { return sfxPlayer.volume; } }

        private void Start()
        {
            musicPlayer = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
            sfxPlayer = GameObject.Find("SFXPlayer").GetComponent<AudioSource>();
            sfxPlayer.volume = Game.Data.Prefs.SFXVolume;
            musicPlayer.volume = Game.Data.Prefs.MusicVolume;
            // TryLoadPrefs();
        }

        public static void SetMusicVolume(float volume)
        {
            musicPlayer.volume = volume;
        }

        public static void SetSFXVolume(float volume)
        {
            sfxPlayer.volume = volume;
            if (!sfxPlayer.isPlaying)
            {
                sfxPlayer.PlayOneShot(Instance.testClip);
            }
        }
    }
}
