using Recruitment.GameplayManagment;
using UnityEngine;

namespace Recruitment.InteractionManagment
{
    public class Door : MonoBehaviour, IInteractable
    {
        [field: SerializeField]
        public string ConfirmationText { get; set; }
        [field: SerializeField]
        public string InformationText { get; set; }

        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }
        [field: SerializeField]
        private Animator CurrentAnimator { get; set; }

        private const string OPEN_DOOR_TRIGGER = "CanOpenDoor";

        public void Interaction ()
        {
            CurrentAnimator.SetTrigger(OPEN_DOOR_TRIGGER);
        }

        public bool CanInteract ()
        {
            return CurrentGameplayController.IsKeyCollected == true;
        }
    }
}