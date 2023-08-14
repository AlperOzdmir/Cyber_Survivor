using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneManager : MonoBehaviour
    {
        public void SetScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
