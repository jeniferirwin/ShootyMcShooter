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
        
        public enum WeaponType
        {
            Pistol,
            Rifle
        }
        
        private static WeaponType _chosenType;
        public static WeaponType ChosenWeaponType { get { return _chosenType; } }
        
        private static int _score;
        public static int Score { get { return _score; } }
        
        private static int _missed;
        public static int Missed { get { return _missed; } }
        
        public delegate void OnStatsChanged(object sender, EventArgs e);
        public static event OnStatsChanged StatsChanged;
        
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
        }

        public static void SetPlayerName(string name)
        {
            _playerName = "";
            if (IsValidAsPlayerName(name))
            {
                _playerName = name;
            }
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
        
        public static void SetChosenWeaponType(WeaponType type)
        {
            _chosenType = type;
        }
    }
}
