using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts {
    public class SceneControl : MonoBehaviour {
        public void ResetScene() {
            SceneManager.LoadScene(0);
        }
    }
}