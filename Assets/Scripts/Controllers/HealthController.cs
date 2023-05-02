using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class HealthController : MonoBehaviour
    {
        [Header("Sprites")]
        [SerializeField] private Sprite _empty;
        [Header("Main")]
        [SerializeField] private Player _player;
        private Stack<Image> _hearts = new();

        private void Start()
        {
            foreach (Transform child in transform)
            {
                _hearts.Push(child.GetComponent<Image>());
            }
        }

        private void OnEnable() =>
            _player.OnDamage += GetDamage;

        private void OnDisable() =>
            _player.OnDamage -= GetDamage;

        private void GetDamage() =>
            _hearts.Pop().sprite = _empty;
    }
}
