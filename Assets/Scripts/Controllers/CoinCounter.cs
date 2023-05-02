using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Runner
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CoinCounter : MonoBehaviour
    {
        private TextMeshProUGUI _counter;

        private void Start() =>
            _counter = GetComponent<TextMeshProUGUI>();

        private void OnEnable() =>
            GameModel.Instance.OnBalanceChange += SetCoins;
        private void OnDisable() =>
            GameModel.Instance.OnBalanceChange -= SetCoins;

        private void SetCoins(int coin) => _counter.text = $"{coin}";
    }
}
