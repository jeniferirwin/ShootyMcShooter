using UnityEngine;
using Shooty.Core;

namespace Shooty.UI
{
    public class NameInitializer : MonoBehaviour
    {
        private void Start()
        {
            PlayerPrefs prefs;
            if (UserPrefs.LoadPrefs(out prefs))
            {
                if (prefs.playerName != "" && prefs.playerName != null)
                {
                    PersistentData.SetPlayerName(prefs.playerName);
                }
            }
        }
    }
}
