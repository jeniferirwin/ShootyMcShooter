using UnityEngine;
using Shooty.UI;

namespace Shooty
{
    public class ClearDataButton : MonoBehaviour
    {
        public void DoClearAll()
        {
            UserPrefs.ClearAllData();
        }
    }
}
