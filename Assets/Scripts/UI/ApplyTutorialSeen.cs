using UnityEngine;
using Shooty.Core;

namespace Shooty.UI
{
    public class ApplyTutorialSeen : MonoBehaviour
    {
        private void Start()
        {
            PlayerPrefs prefs = null;
            if (UserPrefs.LoadPrefs(out prefs))
            {
                if (!prefs.hasSeenTutorial) return;
                PersistentData.SetTutorialSeen();
            }
        }
    }
}
