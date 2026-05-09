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
    public class OxygenSystem : SingletonMonobehaviour<OxygenSystem>
    {
        // ---- Fields ---- //

        [Header("Oxygen Settings")]
        [SerializeField] private float _maxOxygen = 100f;
        [SerializeField] private float _oxygenDepletionRate = 2f;

        public event Action<float, float> OnOxygenChanged;
        public event Action OnOxygenDepleted;

        private float _currentOxygen = 100f;
        private bool _isDead = false;


        // ---- Unity ---- //

        public void Start()
        {
            this._currentOxygen = this._maxOxygen;
            this.Notify();
        }

        public void Update()
        {
            if (this._isDead) return;
            DrainOxygen();
        }


        // ---- Methods ---- //

        private void DrainOxygen()
        {
            float previous = this._currentOxygen;

            this._currentOxygen -= this._oxygenDepletionRate * Time.deltaTime;
            this._currentOxygen = Mathf.Clamp(this._currentOxygen, 0f, this._maxOxygen);

            // Solo notificar si cambia de forma relevante
            if (Mathf.Abs(previous - this._currentOxygen) > 0.01f)
            {
                Notify();
            }

            if (this._currentOxygen <= 0f)
            {
                this._isDead = true;
                OnOxygenDepleted?.Invoke();
            }
        }

        private void Notify()
        {
            this.OnOxygenChanged?.Invoke(this._currentOxygen, this._maxOxygen);
        }

        public void AddOxygen(float amount)
        {
            this._currentOxygen += amount;
            this._currentOxygen = Mathf.Clamp(this._currentOxygen, 0f, this._maxOxygen);
            this.OnOxygenChanged?.Invoke(this._currentOxygen, this._maxOxygen);
        }
    }
}