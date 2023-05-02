using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.UI;

namespace Runner
{
    [RequireComponent (typeof (Animator))]
    [RequireComponent (typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private const float COLLIDER_RADIUS = 0.35f;

        [SerializeField] private float _verticalForce = 1f;
        [SerializeField] private float _groundSensitivity;
        [SerializeField] private GameMenu _gameWindow;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private int _groundMask = 1 << 9;
        private bool _secondJump = true;
        private int _health = 3;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            Control.Instance.Enable();
        }

        private void OnEnable()
        {
            Control.Instance.OnJump += Jump;
            Control.Instance.OnRoll += Roll;
            GameModel.Instance.OnGameEnd += GameEnd;
        }

        private void Jump()
        {
            if (IsGrounded() || _secondJump)
            {
                if (!IsGrounded()) _secondJump = false;
                else _animator.SetTrigger("Jump");
                _rigidbody.AddForce(Vector2.up * _verticalForce);
            }
        }

        private void Roll()
        {
            _animator.SetTrigger("Roll");
        }

        public void TakeDamage(int damage = 1)
        {
            _health -= damage;
            OnDamage?.Invoke();
            if (_health <= 0)
            {
                _animator.SetBool("Dead", true);
                Sequencer.Instance.Pause();
                _gameWindow.ShowWindow();
            }
        }

        public void GameEnd()
        {
            Control.Instance.Disable();
            _animator.SetBool("Wait", true);
            Sequencer.Instance.Pause();
            _gameWindow.ShowWindow();
        }

        private bool IsGrounded() =>
            Physics2D.OverlapCircle(transform.position + new Vector3(0, _groundSensitivity, 0), COLLIDER_RADIUS, _groundMask);

        private void Update()
        {
            //need optimization
            if (IsGrounded())
            {
                _animator.SetBool("Grounded", true);
                _secondJump = true;
            }
            else _animator.SetBool("Grounded", false);
        }

        private void OnDisable()
        {
            Control.Instance.OnJump -= Jump;
            Control.Instance.OnRoll -= Roll;
            GameModel.Instance.OnGameEnd -= GameEnd;
        }

        public delegate void Damaged();
        public event Damaged OnDamage;
    }
}
