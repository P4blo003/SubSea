// ==============================
// USINGS
// ==============================

// Unity:
using UnityEngine;


// ==============================
// CLASSES
// ==============================

namespace SubSea.Utilities
{
    public class StaticMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        // ---- Properties ---- //

        private static T _instance;
        public static T Instance => _instance;


        // ---- Unity ---- //

        protected virtual void Awake()
        {
            _instance = this as T;
        }
    }
}