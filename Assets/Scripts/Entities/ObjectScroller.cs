using Unity.VisualScripting;
using UnityEngine;

namespace Runner
{
    public class ObjectScroller : MonoBehaviour, IPoolable
    {
        [SerializeField] private float _baseSpeed = 0.25f;

        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private float _timeElapsed;
        private float _lerpDuration;
        private bool _isMove;

        public void OnObjectSpawn(Vector3 start, Vector3 target)
        {
            Sequencer.Instance.OnSequencePlay += Move;
            Sequencer.Instance.OnSequenceStop += Stop;
            _timeElapsed = 0.0f;
            transform.localPosition = start;
            _startPosition = start;
            _targetPosition = target;
            _lerpDuration = _baseSpeed * (transform.localPosition - _targetPosition).magnitude;
            _isMove = true;
        }

        private void Update()
        {
            if (_isMove)
            {
                if (_timeElapsed < _lerpDuration)
                {
                    transform.localPosition = Vector2.Lerp(_startPosition, _targetPosition, _timeElapsed / _lerpDuration);
                    _timeElapsed += Time.deltaTime;
                }
                else
                    gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            Sequencer.Instance.OnSequencePlay -= Move;
            Sequencer.Instance.OnSequenceStop -= Stop;
        }

        private void Move() => _isMove = true;
        private void Stop() => _isMove = false;
    }
}