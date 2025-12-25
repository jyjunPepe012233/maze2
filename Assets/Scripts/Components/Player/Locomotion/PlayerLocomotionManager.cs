using Core.Attributes;
using UnityEngine;

namespace Player.Components.Player
{

    public class PlayerLocomotionManager : MonoBehaviour, ILocomotionStateProvider
    {
        public bool IsMoving { get; private set; }
        
        public Vector3 moveWorldDirection { get; private set; }
        
        public bool isSprinting { get; }

        [SerializeField, RequireImplement(typeof(IPlayerInputProvider))]
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
            var inputProvider = _inputProvider as IPlayerInputProvider;
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
            moveWorldDirection = Quaternion.LookRotation(parallelForward) * inputToLocal;

            Vector3 moveVector = moveWorldDirection * MoveSpeed;
            if (inputProvider.IsSprinting) moveVector *= SprintingSpeedMultiplier;

            if (_rigidbody == null) return;
            moveVector.y = _rigidbody.velocity.y;
            _rigidbody.velocity = moveVector;

            IsMoving = moveVector.magnitude != 0;
        }
    }

}