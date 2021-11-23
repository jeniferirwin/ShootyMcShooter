using UnityEngine;
using System.Text.RegularExpressions;

namespace Shooty.Core
{
    public class PersistentData : MonoBehaviour
    {
        private PersistentData _instance;
        public PersistentData Instance { get { return _instance; } }
        
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
        
        private static string _playerName = "";
        public static string PlayerName { get { return _playerName; } } 
        private const string REG_NAME = @"^[A-Za-z][A-Za-z0-9 ]*$";
        
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
    }
}
