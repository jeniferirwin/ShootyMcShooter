using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Shooty.Core
{
    public class DataManagement
    {
        public const string SAVE_FILE_NAME = "/ShootySaveData.js";
        public static string SaveFilePath { get { return Application.persistentDataPath + SAVE_FILE_NAME; } }

        public static SaveFileData SaveDataFromFile()
        {
            if (File.Exists(SaveFilePath))
            {
                string rawText = File.ReadAllText(SaveFilePath);
                SaveFileData fileData = JsonUtility.FromJson<SaveFileData>(rawText);
                if (ValidateSaveFile(fileData))
                {
                    return fileData;
                }
            }
            return new SaveFileData(Game.DEFAULT_PLAYER_NAME, Game.DEFAULT_VOLUME);
        }
        
        public static bool ValidateSaveFile(SaveFileData data)
        {
            if (data.HighScores == null) return false;
            if (data.Prefs == null) return false;
            if (!NameValidation.IsValidAsPlayerName(data.Prefs.PlayerName)) return false;
            return true;
        }
        
        public static void SaveDataToFile(SaveFileData data)
        {
            string rawText = JsonUtility.ToJson(data);
            File.WriteAllText(SaveFilePath, rawText);
        }
    }

    [Serializable]
    public class SaveFileData
    {
        public HighScoreData HighScores { get; private set; }
        public PrefsData Prefs { get; private set; }
        
        public SaveFileData(string defaultPlayerName, float defaultVolume)
        {
            HighScores = new HighScoreData();
            Prefs = new PrefsData(defaultPlayerName, defaultVolume);
        }
        
        public void ErasePreferences()
        {
            Prefs = new PrefsData(Game.DEFAULT_PLAYER_NAME, Game.DEFAULT_VOLUME);
            Game.ApplyAudioSettings();
        }
        
        public void EraseHighScores()
        {
            HighScores = new HighScoreData();
        }
        
        public void EraseAllData()
        {
            ErasePreferences();
            EraseHighScores();
        }
    }

    [Serializable]
    public class HighScoreData
    {
        public List<HighScoreSlot> Slots { get; private set; } = new List<HighScoreSlot>();

        public void AddScore(string playerName, float finalScale)
        {
            HighScoreSlot slot = new HighScoreSlot(playerName, finalScale);
            Slots.Add(slot);
            Slots.Sort((x,y) => y.FinalScale.CompareTo(x.FinalScale));
            Slots = Slots.GetRange(0,5);
        }
    }
    
    [Serializable]
    public class HighScoreSlot
    {
        public string PlayerName { get; private set; }
        public float FinalScale { get; private set; }

        public HighScoreSlot(string name, float scale)
        {
            PlayerName = name;
            FinalScale = scale;
        }
    }

    [Serializable]
    public class PrefsData
    {
        public string PlayerName { get; private set; }
        public bool SeenInstructions { get; private set; }
        public float SFXVolume { get; private set; }
        public float MusicVolume { get; private set; }
        
        public PrefsData(string defaultPlayerName, float defaultVolume)
        {
            PlayerName = defaultPlayerName;
            SeenInstructions = false;
            SFXVolume = defaultVolume;
            MusicVolume = defaultVolume;
        }
        public void SetPlayerName(string name) => PlayerName = name;
        public void SetSeenInstructions(bool value) => SeenInstructions = value;
        public void SetSFXVolume(float value) => SFXVolume = value;
        public void SetMusicVolume(float value) => MusicVolume = value;
    }
}
