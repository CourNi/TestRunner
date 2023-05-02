using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class GameModel : Singleton<GameModel>
    {
        private int _balance = 0;

        public void AddCoin()
        {
            _balance++;
            OnBalanceChange?.Invoke(_balance);
            if (_balance >= 100)
                OnGameEnd?.Invoke();
        }

        public void ResetBalance()
        {
            _balance = 0;
            OnBalanceChange?.Invoke(_balance);
        }

        public int Balance { get => _balance; set => _balance = value; }

        public delegate void BalanceChange(int balance);
        public event BalanceChange OnBalanceChange;
        public delegate void GameEnd();
        public event GameEnd OnGameEnd;
    }
}
