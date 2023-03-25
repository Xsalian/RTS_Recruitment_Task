using Recruitment.GameplayManagment;
using Recruitment.InteractionManagment;
using Recruitment.MVC;
using UnityEngine;

namespace Recruitment.UI
{
    public class ConfirmationController : Controller<ConfirmationView, ConfirmationModel>
    {
        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }

        public void DisplayConfirmationPanel (IInteractable interactable)
        {
            CurrentGameplayController.SetPlayerMechanicsEnableState(false);
            gameObject.SetActive(true);
            CurrentModel.SetCurrentInteractable(interactable);
            CurrentView.SetLabelText(interactable.ConfirmationText);
        }

        public void ConfirmAction ()
        {
            CurrentGameplayController.SetPlayerMechanicsEnableState(true);
            CurrentModel.ConfirmInteraction();
            gameObject.SetActive(false);
        }

        public void CloseConfirmationPanel ()
        {
            CurrentGameplayController.SetPlayerMechanicsEnableState(true);
            gameObject.SetActive(false);
        }
    }
}