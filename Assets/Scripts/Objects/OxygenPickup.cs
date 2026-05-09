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
    public class OxygenPickup : MonoBehaviour
    {
        [Header("Oxygen Settings")]
        [SerializeField] private float _oxygenAmount = 20f;

        [Header("References")]
        [SerializeField] private XRGrabInteractable _grabInteractable;


        // ---- Unity ---- //

        private void Awake()
        {
            this._grabInteractable = GetComponent<XRGrabInteractable>();
            this._grabInteractable.selectEntered.AddListener(OnPickedUp);
        }

        private void OnDestroy()
        {
            this._grabInteractable.selectEntered.RemoveListener(OnPickedUp);
        }


        // ---- Methods ---- //

        private void OnPickedUp(SelectEnterEventArgs args)
        {
            OxygenSystem.Instance.AddOxygen(this._oxygenAmount);
            Destroy(gameObject);
        }
    }
}