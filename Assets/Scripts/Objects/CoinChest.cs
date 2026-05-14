// ==============================
// USINGS
// ==============================

// Unity:
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Internal:
using SubSea.Systems;
using UnityEngine.XR.Interaction.Toolkit;


// ==============================
// CLASSES
// ==============================

namespace SubSea.Objects
{
    public class CoinChest : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _chestClosedVisual;
        [SerializeField] private GameObject _chestOpenedVisual;

        [SerializeField] private XRSimpleInteractable _simpleInteractable;

        [Header("Coin Settings")]
        [SerializeField] private int _coinAmount = 10;
        private bool _wasOpened = false; // Para no sumar dinero infinitamente


        // ---- Unity ---- //

        private void Awake()
        {
            this._simpleInteractable = GetComponent<XRSimpleInteractable>();
            this._simpleInteractable.selectEntered.AddListener(OnPickedUp);
        }

        private void OnDestroy()
        {
            this._simpleInteractable.selectEntered.RemoveListener(OnPickedUp);
        }

        private void OnPickedUp(SelectEnterEventArgs args)
        {
            // Sumar dinero solo la primera vez que se abre
            if (!this._wasOpened)
            {
                this._wasOpened = true;

                this._chestClosedVisual.SetActive(false);
                this._chestOpenedVisual.SetActive(true);
            }
            else
            {
                CoinSystem.Instance.AddCoins(this._coinAmount);
                Destroy(gameObject);
            }
        }
    }
}