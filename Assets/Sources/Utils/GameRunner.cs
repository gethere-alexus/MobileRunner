using Infrastructure.Bootstrap;
using Infrastructure.SceneLoad;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Utils
{
    // bootstrapping the application if it starts not from initial scene
    // created for developing purposes
    // make sure to drag it on a scene
    
    public class GameRunner : MonoBehaviour
    {
        private const string BootstrapScene = "Bootstrap";

        private void Awake()
        {
            var instance = FindObjectOfType<GameBootstrapper>();

            if (instance == null)
                SceneManager.LoadScene(BootstrapScene);
        }
    }
}