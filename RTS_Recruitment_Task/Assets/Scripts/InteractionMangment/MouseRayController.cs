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
        [field: SerializeField]
        private float MaxRayDistance { get; set; }
        [field: SerializeField]
        private LayerMask InteractableLayer { get; set; }

        private IInteractable CurrentInteractable { get; set; }

        protected virtual void Update ()
        {
            CastRay();
            SelectInteractable();
        }

        private void CastRay ()
        {
            Ray ray = MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, MaxRayDistance, InteractableLayer) == true)
            {
                IInteractable cachedInteractable = hit.collider.GetComponent<IInteractable>();

                if (cachedInteractable != null && cachedInteractable != CurrentInteractable)
                {
                    if (CurrentInteractable != null)
                    {
                        CurrentInteractable.StopHighlight();
                    }

                    CurrentInteractable = cachedInteractable;
                    CurrentInteractable.Highlight();
                }
            }
            else
            {
                if (CurrentInteractable != null)
                {
                    CurrentInteractable.StopHighlight();
                    CurrentInteractable = null;
                }
            }
        }

        private void SelectInteractable ()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame == true)
            {
                if (CurrentInteractable != null)
                {
                    if (CurrentInteractable.CanInteract() == true)
                    {
                        ConfirmationPanel.DisplayConfirmationPanel(CurrentInteractable);
                    }
                    else
                    {
                        InformationPanel.DisplayPanel(CurrentInteractable);
                    }
                }
            }
        }
    }
}