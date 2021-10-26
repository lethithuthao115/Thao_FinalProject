using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkateboardGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        public string SceneName;

        public void LoadTargetScene() 
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }
    }
}
