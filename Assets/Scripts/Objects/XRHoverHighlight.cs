// ==============================
// USINGS
// ==============================

// Unity:
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Internal:
using UnityEngine.XR.Interaction.Toolkit;


// ==============================
// CLASSES
// ==============================

namespace SubSea.Objects
{
    public class XRHoverHighlight : MonoBehaviour
    {
        // ---- Fields ---- //

        [Header("Renderer")]
        [SerializeField] private Renderer _targetRenderer;

        [Header("Emission")]
        [SerializeField] private Material _normalMaterial;
        [SerializeField] private Material _highlightMaterial;

        private XRBaseInteractable _interactable;
        private Material _materialInstance;
        private Color _originalEmissionColor;


        // ---- Unity ---- //

        private void Awake()
        {
            this._interactable = GetComponent<XRBaseInteractable>();

            this._interactable.hoverEntered.AddListener(OnHoverEnter);
            this._interactable.hoverExited.AddListener(OnHoverExit);
        }

        private void OnDestroy()
        {
            this._interactable.hoverEntered.RemoveListener(OnHoverEnter);
            this._interactable.hoverExited.RemoveListener(OnHoverExit);
        }


        // ---- Methods ---- //

        private void OnHoverEnter(HoverEnterEventArgs args)
        {
            this._targetRenderer.material = this._highlightMaterial;
        }

        private void OnHoverExit(HoverExitEventArgs args)
        {
            this._targetRenderer.material = this._normalMaterial;
        }
    }
}