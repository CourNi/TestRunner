using UnityEngine;

namespace Runner
{
    public class StartScroller : MonoBehaviour
    {
        [SerializeField] private float _baseSpeed = 0.25f;

        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private float _timeElapsed;
        private float _lerpDuration;

        private void Start()
        {
            _timeElapsed = 0.0f;
            _startPosition = transform.localPosition;
            _targetPosition = new Vector3(-12, -5, 0);
            _lerpDuration = _baseSpeed * (transform.localPosition - _targetPosition).magnitude;
        }

        private void Update()
        {
            if (_timeElapsed < _lerpDuration)
            {
                transform.localPosition = Vector2.Lerp(_startPosition, _targetPosition, _timeElapsed / _lerpDuration);
                _timeElapsed += Time.deltaTime;
            }
            else
                Destroy(gameObject);
        }
    }
}