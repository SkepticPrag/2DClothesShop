using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _movement;
        [SerializeField] private List<Animator> animators = new List<Animator>();

        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            foreach (var animator in animators)
            {
                if (animator.runtimeAnimatorController != null)
                {
                    animator.SetFloat(Horizontal, _movement.x);
                    animator.SetFloat(Vertical, _movement.y);
                    animator.SetFloat(Speed, _movement.sqrMagnitude);
                }
            }
            //
            // _animator.SetFloat(Horizontal, _movement.x);
            // _animator.SetFloat(Vertical, _movement.y);
            // _animator.SetFloat(Speed, _movement.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}