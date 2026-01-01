using System;
using UnityEngine;

namespace Core.Input.CharacterControl
{

    public class InputManagerBasedCharacterControlInput : MonoBehaviour, ICharacterControlInput
    {
        public event Action OnRotated;
    
        public event Action OnMoved;
    
        public event Action OnInteracted;

        public Vector2 RotationDirection { get; private set; }
    
        public Vector2 MoveDirection { get; private set; }
    
        public bool IsSprinting { get; private set; }

        private void UpdateRotationInput()
        {
            float x = UnityEngine.Input.GetAxisRaw("Mouse X");
            float y = UnityEngine.Input.GetAxisRaw("Mouse Y");
            RotationDirection = new Vector2(x, y);
            if (RotationDirection.magnitude != 0)
            {
                OnRotated?.Invoke();
            }
        }

        private void UpdateMoveInput()
        { 
            float horiz = UnityEngine.Input.GetAxisRaw("Horizontal");
            float vert = UnityEngine.Input.GetAxisRaw("Vertical");
            MoveDirection = new Vector2(horiz, vert).normalized;
            if (MoveDirection.magnitude != 0)
            {
                OnMoved?.Invoke();
            }
        }

        private void UpdateSprintInput()
        {
            IsSprinting = UnityEngine.Input.GetKey(KeyCode.LeftShift) && MoveDirection.magnitude != 0;
        }

        private void UpdateInteractionInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                OnInteracted?.Invoke();
            }
        }
    
        private void Update()
        {
            UpdateRotationInput();
            UpdateMoveInput();
            UpdateSprintInput();
            UpdateInteractionInput();
        }
    }

}
