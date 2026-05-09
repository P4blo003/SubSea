// ==============================
// CLASSES
// ==============================

// Unity:
using UnityEngine;


// ==============================
// CLASSES
// ==============================

namespace SubSea.Utilities
{
    public class SingletonMonobehaviour<T> : StaticMonobehaviour<T> where T : MonoBehaviour
    {
        // ---- Unity ---- //

        protected override void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            base.Awake();
        }
    }
}