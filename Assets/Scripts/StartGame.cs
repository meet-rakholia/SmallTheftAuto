using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class StartGame : MonoBehaviour
    {
        public void onStartGameClick()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}