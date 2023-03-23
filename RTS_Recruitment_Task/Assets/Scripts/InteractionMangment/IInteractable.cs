namespace Recruitment.InteractionManagment
{
    public interface IInteractable
    {
        public string ConfirmationText { get; set; }
        public string InformationText { get; set; }
        public void Interaction();
        public bool CanInteract();
    }
}