using UnityEngine;

namespace Recruitment.InteractionManagment
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [field: SerializeField]
        public string ConfirmationText { get; set; }
        [field: SerializeField]
        public string InformationText { get; set; }

        [field: SerializeField]
        private GameObject Contents { get; set; }
        [field: SerializeField]
        private Animator CurrentAnimator { get; set; }

        private const string OPEN_CHEST_TRIGGER = "CanOpenChest";

        public void Interaction ()
        {
            Contents.SetActive(true);
            CurrentAnimator.SetTrigger(OPEN_CHEST_TRIGGER);
        }

        public bool CanInteract ()
        {
            return true;
        }
    }
}