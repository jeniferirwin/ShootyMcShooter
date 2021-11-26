using System;
using System.IO;
using UnityEngine;
using Shooty.Audio;
using Shooty.Core;

namespace Shooty.UI
{
    public class UserPrefs
    {
        public static bool LoadPrefs(out PlayerPrefs prefs)
        {
            if (File.Exists(PersistentData.PrefsSavePath))
            {
                var prefsRaw = File.ReadAllText(PersistentData.PrefsSavePath);
                prefs = JsonUtility.FromJson<Shooty.UI.PlayerPrefs>(prefsRaw);
                return true;
            }
            else
            {
                prefs = null;
                return false;
            }
        }

        public static void SavePrefs()
        {
            Debug.Log("Saving prefs.");
            var sfxVolume = VolumeController.GetSFXVolume;
            var musicVolume = VolumeController.GetMusicVolume;
            var hasSeenTutorial = PersistentData.HasPlayedBefore;
            string userName = "";
            if (PersistentData.IsPlayerNameValid())
            {
                userName = PersistentData.PlayerName;
            }
            PlayerPrefs prefs = new PlayerPrefs(userName, sfxVolume, musicVolume, hasSeenTutorial);
            Debug.Log(prefs.musicVolume);
            string json = JsonUtility.ToJson(prefs);
            Debug.Log(json);
            File.WriteAllText(PersistentData.PrefsSavePath, json);
        }
        
        public static void ClearAllData()
        {
            var scoreFile = PersistentData.SavePath;
            var prefsFile = PersistentData.PrefsSavePath;
            if (File.Exists(scoreFile))
            {
                File.Delete(scoreFile);
            }
            if (File.Exists(prefsFile))
            {
                File.Delete(prefsFile);
            }
            PersistentData.ClearPlayerName();
            VolumeController.SetSFXVolume(VolumeController.Instance.defaultVolume);
            VolumeController.SetMusicVolume(VolumeController.Instance.defaultVolume);
            PopulateHighScores.ClearScoreData();
        }
    }

    [Serializable]
    public class PlayerPrefs
    {
        public float sfxVolume;
        public float musicVolume;
        public string playerName;
        public bool hasSeenTutorial;

        public PlayerPrefs(string userName, float sfx, float music, bool seenTutorial)
        {
            playerName = userName;
            sfxVolume = sfx;
            musicVolume = music;
            hasSeenTutorial = seenTutorial;
        }
    }
}
