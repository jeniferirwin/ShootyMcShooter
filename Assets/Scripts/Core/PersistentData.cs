using UnityEngine;

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
        
        private static string _playerName;
        public static string PlayerName { get { return _playerName; } } 
        
        public static void SetPlayerName(string name)
        {
            if (name.Length > 16)
            {
                _playerName = name.Substring(0,16);
            }
            else
            {
                _playerName = name;
            }
        }
    }
}
