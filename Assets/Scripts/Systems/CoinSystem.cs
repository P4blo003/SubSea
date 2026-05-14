// ==============================
// USINGS
// ==============================

// Unity:
using UnityEngine;

// Internal:
using SubSea.Utilities;
using System;


// ==============================
// CLASSES
// ==============================

namespace SubSea.Systems
{
    public class CoinSystem : SingletonMonobehaviour<CoinSystem>
    {
        // ---- Fields ---- //

        public event Action<float> OnCoinsChanged;
        private float _currentCoins = 0f;

        // ---- Unity ---- //

        public void Start()
        {
            this._currentCoins = 0f;
            this.Notify();
        }


        // ---- Methods ---- //

        private void Notify()
        {
            this.OnCoinsChanged?.Invoke(this._currentCoins);
        }

        public void AddCoins(float amount)
        {
            this._currentCoins += amount;
            this.OnCoinsChanged?.Invoke(this._currentCoins);
        }
    }
}