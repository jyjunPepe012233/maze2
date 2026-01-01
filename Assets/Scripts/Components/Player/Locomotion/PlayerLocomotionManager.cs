using Core.Attributes;
using Core.Input.CharacterControl;
using UnityEngine;

namespace Player.Components.Player
{

    public class PlayerLocomotionManager : MonoBehaviour, ILocomotionStateProvider
    {
        public bool IsMoving { get; private set; }
        
        public Vector3 MoveWorldDirection { get; private set; }
        
        public bool IsSprinting { get; }

        [SerializeField, RequireImplement(typeof(ICharacterControlInput))]
        private Object _inputProvider;

        [SerializeField]
        private Transform _rotationSource;
        
        public Transform RotationSource => _rotationSource;

        [SerializeField]
        private Rigidbody _rigidbody;

        public Rigidbody Rigidbody => _rigidbody;

        public float MoveSpeed = 2f;

        public float SprintingSpeedMultiplier = 2f;
        
        private void Update()
        {
            var inputProvider = _inputProvider as ICharacterControlInput;
            if (inputProvider == null) return;
            
            if (_rotationSource == null) return;

            Vector3 inputToLocal = new Vector3(
                inputProvider.MoveDirection.x,
                0,
                inputProvider.MoveDirection.y
            );
            Vector3 parallelForward = _rotationSource.forward;
            parallelForward.y = 0;
            parallelForward.Normalize();
            MoveWorldDirection = Quaternion.LookRotation(parallelForward) * inputToLocal;

            Vector3 moveVector = MoveWorldDirection * MoveSpeed;
            if (inputProvider.IsSprinting) moveVector *= SprintingSpeedMultiplier;

            if (_rigidbody == null) return;
            moveVector.y = _rigidbody.velocity.y;
            _rigidbody.velocity = moveVector;

            IsMoving = moveVector.magnitude != 0;
        }
    }

}