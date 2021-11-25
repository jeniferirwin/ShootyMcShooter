using UnityEngine;
using Shooty.Core;

namespace Shooty.UI
{
    public class TargetChoiceInput : MonoBehaviour
    {
        public void SetTargetType(string type)
        {
            PersistentData.TargetType playerTarget = PersistentData.TargetType.Sphere;
            if (type == "Cube") playerTarget = PersistentData.TargetType.Cube; 
                
            PersistentData.SetChosenTargetType(playerTarget);
        }
    }
}
