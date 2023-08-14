using System;
using Player;
using UnityEngine;

namespace Managers
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager Instance;
        [HideInInspector]
        public PlayerDataSO characterData;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogError("CharacterManager already exists");
                Destroy(this);
            }
        }

        public static PlayerDataSO GetCharacterData()
        {
            return Instance.characterData;
        }
        
        public void SetCharacterData(PlayerDataSO data)
        {
            characterData = data;
        }
        
        public void DestroySingleton()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }
}
