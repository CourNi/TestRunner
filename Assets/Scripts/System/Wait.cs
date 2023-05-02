using UnityEngine;
using CustomRoutine;

namespace Runner
{
    public sealed class Wait : Instruction
    {
        public float Delay { get; set; }
        private float startTime;

        protected override bool Update()
        {
            return Time.time - startTime < Delay;
        }

        public Wait(MonoBehaviour parent) : base(parent) { }

        public Wait(float delay, MonoBehaviour parent) : base(parent)
        {
            Delay = delay;
        }

        protected override void OnStarted()
        {
            startTime = Time.time;
        }

        protected override void OnPaused()
        {
            Delay -= Time.time - startTime;
        }

        protected override void OnResumed()
        {
            startTime = Time.time;
        }

        public Instruction Execute(float delay)
        {
            Delay = delay;

            return base.Execute();
        }
    }
}
