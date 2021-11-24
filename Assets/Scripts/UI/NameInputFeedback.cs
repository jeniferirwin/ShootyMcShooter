using UnityEngine;
using Shooty.Core;
using UnityEngine.UI;

namespace Shooty.UI
{
    public class NameInputFeedback : MonoBehaviour
    {
        [SerializeField] private GameObject instructions;
        [SerializeField] private GameObject clickNotification;
        [SerializeField] private GameObject buttons;
        [SerializeField] private Color successColor;
        [SerializeField] private Color failColor;
        [SerializeField] private Image panel;

        public void ChangeColor()
        {
            if (PersistentData.IsPlayerNameValid())
            {
                instructions.SetActive(false);
                buttons.SetActive(true);
                clickNotification.SetActive(false);
                panel.color = successColor;             
            }
            else if (!PersistentData.IsPlayerNameValid())
            {
                clickNotification.SetActive(false);
                instructions.SetActive(true);
                buttons.SetActive(false);
                panel.color = failColor;
            }
        }
    }
}
