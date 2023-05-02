using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public abstract class Controller : MonoBehaviour
    {
        [SerializeField] protected string _id;

        protected virtual void Awake()
        {
            _id ??= name;
            Sequencer.Instance.RegisterController(_id, this);
        }

        public virtual void Init() =>
            Debug.Log($"{_id} controller initialized");

        public virtual void StartSequence() { }
        public virtual void StopSequence() { }
        public virtual void ResetSequence() => StopSequence();
    }
}
