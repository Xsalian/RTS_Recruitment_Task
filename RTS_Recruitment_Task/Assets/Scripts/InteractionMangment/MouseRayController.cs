using Recruitment.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Recruitment.InteractionManagment
{
    public class MouseRayController : MonoBehaviour
    {
        [field: SerializeField]
        private ConfirmationController ConfirmationPanel { get; set; }
        [field: SerializeField]
        private InformationController InformationPanel { get; set; }
        [field: SerializeField]
        private Camera MainCamera { get; set; }

        protected virtual void Update ()
        {
            CastRay();
        }

        private void CastRay ()
        {
            Ray ray = MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit) == true)
            {
                if (Mouse.current.leftButton.wasPressedThisFrame == true)
                {
                    IInteractable cachedInteractable = hit.collider.GetComponent<IInteractable>();
                    
                    if (cachedInteractable != null)
                    {
                        if (cachedInteractable.CanInteract() == true)
                        {
                            ConfirmationPanel.DisplayConfirmationPanel(cachedInteractable);
                        }
                        else
                        {
                            InformationPanel.DisplayPanel(cachedInteractable);
                        }
                    }
                }
            }
        }
    }
}