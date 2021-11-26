using System;
using UnityEngine;
using System.Text.RegularExpressions;

namespace Shooty.Core
{
    public class PersistentData
    {
        private static PersistentData _instance;
        public static PersistentData Instance { get { return _instance; } }

        /*
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
        */

        // **** END SINGLETON STUFF ****

        private static string _playerName = "";
        public static string PlayerName { get { return _playerName; } }
        private const string REG_NAME = @"^[A-Za-z][A-Za-z0-9 ]*$";

        public enum TargetType
        {
            Sphere,
            Cube
        }

        public static string SavePath { get { return Application.persistentDataPath + "/shootySavefile.json"; } }
        public static string PrefsSavePath { get { return Application.persistentDataPath + "/shootyPrefsfile.json"; } }
        private static TargetType _chosenType;
        public static TargetType ChosenTargetType { get { return _chosenType; } }

        private static int _score;
        public static int Score { get { return _score; } }

        private static int _missed;
        public static int Missed { get { return _missed; } }

        private static bool _hasPlayedBefore;
        public static bool HasPlayedBefore { get { return _hasPlayedBefore; } }

        public delegate void OnStatsChanged(object sender, EventArgs e);
        public static event OnStatsChanged StatsChanged;

        public delegate void OnGameOver(object sender, EventArgs e);
        public static event OnGameOver GameOver;

        public static float ScalePercentage
        {
            get
            {
                return 1f - (Score / 1.01f / 100f);
            }
        }

        public static float CurrentScale
        {
            get
            {
                return 1.5f * ScalePercentage;
            }
        }

        public static void ResetScore()
        {
            _score = 0;
            _missed = 0;
            StatsChanged?.Invoke(Instance, EventArgs.Empty);
        }

        public static void IncrementScore()
        {
            _score += 1;
            StatsChanged?.Invoke(Instance, EventArgs.Empty);
        }

        public static void IncrementMissed()
        {
            _missed += 1;
            StatsChanged?.Invoke(Instance, EventArgs.Empty);
            if (_missed >= 5)
            {
                GameOver?.Invoke(Instance, EventArgs.Empty);
            }
        }
        
        public static void ForceGameOver()
        {
            GameOver?.Invoke(Instance, EventArgs.Empty);
        }

        public static void SetPlayerName(string name)
        {
            _playerName = "";
            if (IsValidAsPlayerName(name))
            {
                _playerName = name;
            }
        }
        
        public static void ClearPlayerName()
        {
            _playerName = "";
        }

        public static bool IsPlayerNameValid()
        {
            return IsValidAsPlayerName(_playerName);
        }

        public static bool IsValidAsPlayerName(string input)
        {
            if (input == "") return false;
            if (input.Length > 16) return false;
            Regex rx = new Regex(REG_NAME);
            if (rx.Match(input).Success) return true;
            return false;
        }

        public static void SetChosenTargetType(TargetType type)
        {
            _chosenType = type;
        }
        public static void SetTutorialSeen()
        {
            _hasPlayedBefore = true;
        }
    }
}
