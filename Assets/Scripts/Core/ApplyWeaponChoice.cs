using UnityEngine;
using Shooty.UI;
using TMPro;

namespace Shooty.Core
{
    public class ApplyWeaponChoice : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void Start()
        {
            if (PersistentData.ChosenTargetType == PersistentData.TargetType.Sphere)
            {
                text.text = "Sphere";
            }
            else if (PersistentData.ChosenTargetType == PersistentData.TargetType.Cube)
            {
                text.text = "Cube";
            }
        }
    }
}
