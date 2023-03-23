using Recruitment.InteractionManagment;
using Recruitment.MVC;

namespace Recruitment.UI
{
    public class ConfirmationController : Controller<ConfirmationView, ConfirmationModel>
    {
        public void DisplayConfirmationPanel (IInteractable interactable)
        {
            gameObject.SetActive(true);
            CurrentModel.SetCurrentInteractable(interactable);
            CurrentView.SetLabelText(interactable.ConfirmationText);
        }

        public void ConfirmAction ()
        {
            CurrentModel.ConfirmInteraction();
            gameObject.SetActive(false);
        }

        public void CloseConfirmationPanel ()
        {
            gameObject.SetActive(false);
        }
    }
}