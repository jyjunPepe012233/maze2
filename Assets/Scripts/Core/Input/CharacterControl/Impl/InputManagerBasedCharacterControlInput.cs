using System;
using UnityEngine;

namespace Core.Input.CharacterControl.Impl
{

    public class InputManagerBasedCharacterControlInput : InputProfileBehaviour, ICharacterControlInput
    {
        public event Action OnRotated;
    
        public event Action OnMoved;
    
        public event Action OnInteracted;

        private Vector2 _rotationDirection;

        public Vector2 RotationDirection => IsActivate ? _rotationDirection : Vector2.zero;

        private Vector2 _moveDirection;

        public Vector2 MoveDirection => IsActivate ? _moveDirection : Vector2.zero;

        private bool _isSprinting;
        
        public bool IsSprinting => IsActivate ? _isSprinting : false;

        private void UpdateRotationInput()
        {
            float x = UnityEngine.Input.GetAxisRaw("Mouse X");
            float y = UnityEngine.Input.GetAxisRaw("Mouse Y");
            _rotationDirection = new Vector2(x, y);
            if (RotationDirection.magnitude != 0)
            {
                OnRotated?.Invoke();
            }
        }

        private void UpdateMoveInput()
        { 
            float horiz = UnityEngine.Input.GetAxisRaw("Horizontal");
            float vert = UnityEngine.Input.GetAxisRaw("Vertical");
            _moveDirection = new Vector2(horiz, vert).normalized;
            if (MoveDirection.magnitude != 0)
            {
                OnMoved?.Invoke();
            }
        }

        private void UpdateSprintInput()
        {
            _isSprinting = UnityEngine.Input.GetKey(KeyCode.LeftShift) && MoveDirection.magnitude != 0;
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
