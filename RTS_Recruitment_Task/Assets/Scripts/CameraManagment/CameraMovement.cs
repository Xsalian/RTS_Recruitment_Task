using Recruitment.InputManagment;
using UnityEngine;

namespace Recruitment.CamerManagment
{
    public class CameraMovement : MonoBehaviour
    {
        [field: SerializeField]
        private PlayerInput CurrentInput { get; set; }

        [field: Header("Movement settings")]
        [field: SerializeField]
        private float MoveSpeed { get; set; }
        [field: SerializeField]
        private float RotateSpeed { get; set; }
        [field: SerializeField]
        private float MinX { get; set; }
        [field: SerializeField]
        private float MaxX { get; set; }
        [field: SerializeField]
        private float MinZ { get; set; }
        [field: SerializeField]
        private float MaxZ { get; set; }

        private float RotationY { get; set; }


        protected virtual void Update ()
        {
            ChangeCameraPosition();
            ChangeCameraRotation();
        }

        private void ChangeCameraPosition ()
        {
            Vector2 moveAxis = CurrentInput.GetMoveVector();

            if (moveAxis != Vector2.zero)
            {
                Vector3 originPosition = transform.position;

                originPosition += moveAxis.x * MoveSpeed * Time.deltaTime * transform.right;
                originPosition += moveAxis.y * MoveSpeed * Time.deltaTime * transform.forward;
                originPosition.x = Mathf.Clamp(originPosition.x, MinX, MaxX);
                originPosition.z = Mathf.Clamp(originPosition.z, MinZ, MaxZ);

                transform.position = originPosition;
            }
        }

        private void ChangeCameraRotation ()
        {
            float rotateAxis = CurrentInput.GetRotateVector();

            if (rotateAxis != 0.0f)
            {
                RotationY += rotateAxis * Time.deltaTime * RotateSpeed;
                transform.rotation = Quaternion.Euler(0.0f, RotationY, 0.0f);
            }
        }
    }
}