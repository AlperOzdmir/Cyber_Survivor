using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject inGameMenu;
        [SerializeField] private GameObject gameOverMenu;
        
        public enum GameState
        {
            MainMenu,
            InGame,
            InGameMenu,
            GameOver
        }
        
        public GameState CurrentGameState { get; private set; }

        public void FixedUpdate()
        {
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    break;
                case GameState.InGame:
                    break;
                case GameState.InGameMenu:
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
            inGameMenu.SetActive(true);
        }
        
        public void CloseInGameMenu()
        {
            SetGameState(GameState.InGame);
            inGameMenu.SetActive(false);
        }
        
        public void OpenGameOverMenu()
        {
            SetGameState(GameState.GameOver);
            gameOverMenu.SetActive(true);
        }
    }
}
