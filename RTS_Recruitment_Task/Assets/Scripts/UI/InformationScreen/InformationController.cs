using MilkShake;
using Recruitment.GameplayManagment;
using Recruitment.InteractionManagment;
using Recruitment.MVC;
using UnityEngine;

namespace Recruitment.UI
{
    public class InformationController : Controller<InformationView, InformationModel>
    {
        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }
        [field: SerializeField]
        private Shaker CurrentShaker { get; set; }
        [field: SerializeField]
        private ShakePreset CurrentShakePreset { get; set; }

        public void DisplayPanel (IInteractable interactable)
        {
            CurrentGameplayController.SetPlayerMechanicsEnableState(false);
            CurrentShaker.Shake(CurrentShakePreset);
            gameObject.SetActive(true);
            CurrentView.SetLabelText(interactable.InformationText);
        }

        public void ClosePanel ()
        {
            CurrentGameplayController.SetPlayerMechanicsEnableState(true);
            gameObject.SetActive(false);
        }
    }
}