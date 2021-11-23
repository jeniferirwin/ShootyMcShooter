using UnityEngine;
using Shooty.Core;

namespace Shooty.UI
{
    public class NameInput : MonoBehaviour
    {
        // This class might seem a bit redundant, but we need it because
        // PersistentData is a DontDestroyOnLoad from a previous scene,
        // so we can't just plug it into the 'edit finished' event. We
        // can plug this one in, though.

        public void SetPlayerName(string name)
        {
            PersistentData.SetPlayerName(name);
        }
    }
}
