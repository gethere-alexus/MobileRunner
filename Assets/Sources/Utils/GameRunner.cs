using Infrastructure.Bootstrap;
using UnityEngine;

namespace Sources.Utils
{
    // bootstrapping the application if it starts not from initial scene
    // created for developing purposes
    // make sure to drag it on a scene
    
    public class GameRunner : MonoBehaviour
    {
        private void Awake()
        {
            var instance = FindObjectOfType<GameBootstrapper>();

            if (instance == null)
                this.gameObject.AddComponent<GameBootstrapper>();
        }
    }
}