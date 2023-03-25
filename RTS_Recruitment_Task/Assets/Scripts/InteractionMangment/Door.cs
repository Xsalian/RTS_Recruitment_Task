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

        private const string OPEN_DOOR_TRIGGER = "OpenDoor";
        private const string IDLE_DOOR_TRIGGER = "ResetDoor";

        public void Interaction ()
        {
            CurrentAnimator.SetTrigger(OPEN_DOOR_TRIGGER);
            CurrentGameplayController.EndGame();
        }

        public bool CanInteract ()
        {
            return CurrentGameplayController.IsKeyCollected == true;
        }

        protected virtual void Start()
        {
            AttachToEvent();
        }

        protected virtual void OnDestroy()
        {
            DetachFromEvent();
        }

        private void AttachToEvent()
        {
            CurrentGameplayController.GameEnded += HandleOnGameEnded;
        }

        private void DetachFromEvent()
        {
            CurrentGameplayController.GameEnded -= HandleOnGameEnded;
        }

        private void HandleOnGameEnded()
        {
            CurrentAnimator.SetTrigger(IDLE_DOOR_TRIGGER);
        }
    }
}