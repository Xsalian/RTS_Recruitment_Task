using Recruitment.InteractionManagment;
using Recruitment.MVC;

namespace Recruitment.UI
{
    public class InformationController : Controller<InformationView, InformationModel>
    {
        public void DisplayPanel (IInteractable interactable)
        {
            gameObject.SetActive(true);
            CurrentView.SetLabelText(interactable.InformationText);
        }

        public void ClosePanel ()
        {
            gameObject.SetActive(false);
        }
    }
}