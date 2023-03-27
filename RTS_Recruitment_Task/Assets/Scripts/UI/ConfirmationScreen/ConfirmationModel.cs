using Recruitment.InteractionManagment;
using Recruitment.MVC;

namespace Recruitment.UI
{
    public class ConfirmationModel : Model<ConfirmationView>
    {
        private IInteractable CurrentInteractable { get; set; }

        public void SetCurrentInteractable (IInteractable interactable)
        {
            CurrentInteractable = interactable;
        }

        public void ConfirmInteraction ()
        {
            CurrentInteractable.Interaction();
        }
    }
}