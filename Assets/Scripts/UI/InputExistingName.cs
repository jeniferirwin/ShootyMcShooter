using UnityEngine;
using Shooty.Core;
using TMPro;

namespace Shooty.UI
{
    public class InputExistingName : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameText;
        
        private void Start()
        {
            if (PersistentData.PlayerName != "")
            {
                nameText.text = PersistentData.PlayerName;
                nameText.Select();
                nameText.DeactivateInputField();
            }
        }
    }
}
