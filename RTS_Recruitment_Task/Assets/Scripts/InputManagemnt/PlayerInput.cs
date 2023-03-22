using UnityEngine;

namespace Recruitment.InputMangment
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerInputActions PlayerActions { get; set; }

        public Vector2 GetMoveVector()
        {
            return PlayerActions.Camera.Move.ReadValue<Vector2>();
        }

        public float GetRotateVector()
        {
            return PlayerActions.Camera.Rotate.ReadValue<float>();
        }

        protected virtual void Awake()
        {
            InitializePlayerControls();
        }

        private void InitializePlayerControls()
        {
            PlayerActions = new PlayerInputActions();
            PlayerActions.Camera.Enable();
        }
    }
}