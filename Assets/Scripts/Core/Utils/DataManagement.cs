using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Shooty.Core
{
    public class DataManagement
    {
        public const string SAVE_FILE_NAME = "/ShootySaveData.json";
        public static string SaveFilePath { get { return Application.persistentDataPath + SAVE_FILE_NAME; } }

        public static SaveFileData SaveDataFromFile()
        {
            if (!File.Exists(SaveFilePath)) return new SaveFileData(Game.DEFAULT_PLAYER_NAME, Game.DEFAULT_VOLUME);
            string rawText = File.ReadAllText(SaveFilePath);
            SaveFileData fileData = JsonUtility.FromJson<SaveFileData>(rawText);
            if (fileData != null && ValidateSaveFile(fileData))
            {
                return fileData;
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
            Debug.Log(rawText);
            File.WriteAllText(SaveFilePath, rawText);
        }
    }

    [Serializable]
    public class SaveFileData
    {
        public HighScoreData HighScores;
        public PrefsData Prefs;

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
        public List<HighScoreSlot> Slots = new List<HighScoreSlot>();

        public void AddScore(string playerName, float finalScale)
        {
            HighScoreSlot slot = new HighScoreSlot(playerName, finalScale);
            Slots.Add(slot);
            Slots.Sort((x, y) => y.FinalScale.CompareTo(x.FinalScale));
            Slots = Slots.GetRange(0, 5);
        }
    }

    [Serializable]
    public class HighScoreSlot
    {
        public string PlayerName;
        public float FinalScale;

        public HighScoreSlot(string name, float scale)
        {
            PlayerName = name;
            FinalScale = scale;
        }
    }

    [Serializable]
    public class PrefsData
    {
        public string PlayerName;
        public bool SeenInstructions;
        public float SFXVolume;
        public float MusicVolume;

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
