using UnityEngine;

namespace Shooty.Core
{
    public class StaticCommander : MonoBehaviour
    {
        // Data Management Commands
        
        public static void DMErasePreferences()
        {
            Game.Data.ErasePreferences();
            DataManagement.SaveDataToFile(Game.Data);
        }
        
        public static void DMEraseHighScores()
        {
            Game.Data.EraseHighScores();
            DataManagement.SaveDataToFile(Game.Data);
        }
        
        public static void DMEraseAllData()
        {
            Game.Data.EraseAllData();
            DataManagement.SaveDataToFile(Game.Data);
        }
        
        public static void DMSaveData()
        {
            DataManagement.SaveDataToFile(Game.Data);
        }
    }
}