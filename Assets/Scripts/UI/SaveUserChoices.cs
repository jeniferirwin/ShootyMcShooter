using UnityEngine;

namespace Shooty.UI
{
    public class SaveUserChoices : MonoBehaviour
    {
        public static void SaveChoices()
        {
            UserPrefs.SavePrefs();
        }
    }
}
