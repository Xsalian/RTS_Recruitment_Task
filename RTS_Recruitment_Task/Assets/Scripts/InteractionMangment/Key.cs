using Recruitment.GameplayManagment;
using UnityEngine;

namespace Recruitment.InteractionManagment
{
    public class Key : MonoBehaviour, IInteractable
    {
        [field: SerializeField]
        public string ConfirmationText { get; set; }
        [field: SerializeField]
        public string InformationText { get; set; }

        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }

        public void Interaction ()
        {
            CurrentGameplayController.IsKeyCollected = true;
            gameObject.SetActive(false);
        }

        public bool CanInteract ()
        {
            return true;
        }
    }
}