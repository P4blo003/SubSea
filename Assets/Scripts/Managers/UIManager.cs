// ==============================
// USINGS
// ==============================

// Unity:
using UnityEngine;

// Internal:
using SubSea.Utilities;
using TMPro;
using SubSea.Systems;
using UnityEngine.UI;


// ==============================
// CLASSES
// ==============================

namespace SubSea.Managers
{
    public class UIManager : SingletonMonobehaviour<UIManager>
    {
        // ---- Fields ---- //

        [Header("References")]
        [SerializeField] private TMP_Text _oxygenText;
        [SerializeField] private TMP_Text _coinText;
        
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private Button _restartButton;


        // ---- Unity ---- //

        public void Start()
        {
            OxygenSystem.Instance.OnOxygenChanged += this.UpdateOxygenUI;
            OxygenSystem.Instance.OnOxygenDepleted += () => this._gameOverPanel.SetActive(true);
            CoinSystem.Instance.OnCoinsChanged += this.UpdateCoinsUI;
            this._restartButton.onClick.AddListener(this.RestartGame);
        }


        // ---- Methods ---- //

        public void UpdateOxygenUI(float currentOxygen, float maxOxygen)
        {
            float percent = (currentOxygen / maxOxygen) * 100f;
            this._oxygenText.text = $"O2: {Mathf.Round(currentOxygen)} / {maxOxygen} ({Mathf.Round(percent)}%)";
        }

        public void UpdateCoinsUI(float currentCoins)
        {
            this._coinText.text = $"Coins: {Mathf.Round(currentCoins)} $";
        }

        public void RestartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }
    }
}