using UnityEngine;

namespace ExPresSXR.Movement
{
    /// <summary>
    /// Applies a constant gravity on the player while still allowing teleportation, climbing, other movement.
    /// </summary>
    public class PlayerGravity : PlayerForceBase
    {
        /// <summary>
        /// Whether or not gravity should be applied.
        /// </summary>
        [SerializeField]
        [Tooltip("Whether or not gravity should be applied.")]
        private bool _applyGravity = true;
        public bool applyGravity
        {
            get => _applyGravity;
            set => _applyGravity = value;
        }

        /// <summary>
        /// The gravity applied to the player. The default is Unity's default gravity.
        /// </summary>
        [SerializeField]
        [Tooltip("The gravity applied to the player. The default is Unity's default gravity.")]
        private Vector3 _gravity = Physics.gravity;
        public Vector3 gravity
        {
            get => _gravity;
            set => _gravity = value;
        }

        private void Update()
        {
            if (_characterController != null && _characterController.gameObject.activeInHierarchy && _characterController.enabled 
                && _applyGravity && !forceTemporarilyDisabled)
            {
                _currentVelocity += _gravity * Time.deltaTime;
                if (_characterController.Move(_currentVelocity * Time.deltaTime).HasFlag(CollisionFlags.Below))
                {
                    // Floor Collision -> Reset Velocity
                    _currentVelocity = Vector3.zero;
                }
            }
        }
    }
}