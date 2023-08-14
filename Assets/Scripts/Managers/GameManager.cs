using TMPro;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [Header("UI")]
        [SerializeField] private GameObject levelUpMenuUI;
        [SerializeField] private GameObject gamePlayUI;
        [SerializeField] private GameObject inGameMenuUI;
        [SerializeField] private GameObject gameOverMenuUI;
        [SerializeField] private TextMeshProUGUI timeText;
        
        [Header("Status UI")]
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI recoveryText;
        public TextMeshProUGUI armorText;
        public TextMeshProUGUI movementSpeedText;
        public TextMeshProUGUI cooldownReductionText;
        public TextMeshProUGUI strengthText;

        private float timer;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogError("GameManager already exists");
                Destroy(gameObject);
            }
        }

        public enum GameState
        {
            InGame,
            LevelUpMenu,
            InGameMenu,
            GameOver
        }
        
        private GameState CurrentGameState { get; set; }

        public void FixedUpdate()
        {
            switch (CurrentGameState)
            {
                case GameState.InGame:
                    UpdateTime();
                    break;
                case GameState.LevelUpMenu:
                    UpdateTime();
                    break;
                case GameState.InGameMenu:
                    UpdateTime();
                    break;
                case GameState.GameOver:
                    break;
                default:
                    Debug.LogError("Invalid game state");
                    break;
            }
        }
        
        public void SetGameState(GameState gameState)
        {
            CurrentGameState = gameState;
        }
        
        public void OpenInGameMenu()
        {
            SetGameState(GameState.InGameMenu);
            inGameMenuUI.SetActive(true);
            gamePlayUI.SetActive(false);
        }
        
        public void CloseInGameMenu()
        {
            SetGameState(GameState.InGame);
            inGameMenuUI.SetActive(false);
            gamePlayUI.SetActive(true);
        }
        
        public void OpenGameOverMenu()
        {
            SetGameState(GameState.GameOver);
            gameOverMenuUI.SetActive(true);
            gamePlayUI.SetActive(false);
        }
        
        public void OpenLevelUpMenu()
        {
            SetGameState(GameState.LevelUpMenu);
            levelUpMenuUI.SetActive(true);
            gamePlayUI.SetActive(false);
        }
        
        public void CloseLevelUpMenu()
        {
            SetGameState(GameState.InGame);
            levelUpMenuUI.SetActive(false);
            gamePlayUI.SetActive(true);
        }
        
        private void UpdateTime()
        {
            timer += Time.deltaTime;
            timeText.text = timer.ToString("F2");
        }
        
        public void UpdateHealthText(float value)
        {
            healthText.text = value.ToString("F2");
        }
        
        public void UpdateRecoveryText(float value)
        {
            recoveryText.text = value.ToString("F2");
        }
        
        public void UpdateArmorText(float value)
        {
            armorText.text = value.ToString("F2");
        }
        
        public void UpdateMovementSpeedText(float value)
        {
            movementSpeedText.text = value.ToString("F2");
        }
        
        public void UpdateCooldownReductionText(float value)
        {
            cooldownReductionText.text = value.ToString("F2");
        }
        
        public void UpdateStrengthText(float value)
        {
            strengthText.text = value.ToString("F2");
        }
    }
}
