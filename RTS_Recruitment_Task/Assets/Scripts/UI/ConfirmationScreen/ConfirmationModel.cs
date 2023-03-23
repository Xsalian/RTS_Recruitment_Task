using Recruitment.InteractionManagment;
using Recruitment.MVC;

namespace Recruitment.UI
{
    public class ConfirmationModel : Model<ConfirmationView>
    {
        private IInteractable CurrentInteractable { get; set; }

        public void SetCurrentInteractable (IInteractable interactable) //TODO: CHECK IF IN THIS SITUATION TDA IS GOOD SOLUTION
        {
            CurrentInteractable = interactable;
        }

        public void ConfirmInteraction ()
        {
            CurrentInteractable.Interaction();
        }
    }
}