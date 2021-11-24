using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooty
{
    public class Shoot : MonoBehaviour
    {
        private Camera mainCamera;
        private Vector2 mousePos;

        private void Start()
        {
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }

        public void OnShoot()
        {
            var ray = mainCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Target target;
                if (hit.transform.gameObject.TryGetComponent<Target>(out target))
                {
                    target.GetShot();
                }
            }
        }

        public void SetMousePosition(InputAction.CallbackContext context)
        {
            mousePos = context.ReadValue<Vector2>();
        }
    }
}
