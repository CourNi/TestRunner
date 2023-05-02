using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class Background : Controller
    {
        private const float FIRST_SPEED = 0.005f;
        private const float SECOND_SPEED = 0.01f;
        private const float THIRD_SPEED = 0.04f;
        private const float FOURTH_SPEED = 0.1f;

        [SerializeField] private Material _firstPlaneMaterial;
        [SerializeField] private Material _secondPlaneMaterial;
        [SerializeField] private Material _thirdPlaneMaterial;
        [SerializeField] private Material _fourthPlaneMaterial;
        private int _property = Shader.PropertyToID("_UVScrollSpeed");

        public override void Init()
        {
            StopSequence();
            base.Init();
        }

        public override void StartSequence() =>
            SetSpeeds(FIRST_SPEED, SECOND_SPEED, THIRD_SPEED, FOURTH_SPEED);

        public override void StopSequence() =>
            SetSpeeds(0, 0, 0, 0);

        private void SetSpeeds(float firstSpeed, float secondSpeed, float thirdSpeed, float fourthSpeed)
        {
            _firstPlaneMaterial.SetVector(_property, new Vector4(firstSpeed, 0.0f, 0.0f, 0.0f));
            _secondPlaneMaterial.SetVector(_property, new Vector4(secondSpeed, 0.0f, 0.0f, 0.0f));
            _thirdPlaneMaterial.SetVector(_property, new Vector4(thirdSpeed, 0.0f, 0.0f, 0.0f));
            _fourthPlaneMaterial.SetVector(_property, new Vector4(fourthSpeed, 0.0f, 0.0f, 0.0f));
        }
    }
}
