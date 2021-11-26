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
            nameText.text = Game.Data.Prefs.PlayerName;
            nameText.Select();
            nameText.DeactivateInputField();
        }
    }
}
