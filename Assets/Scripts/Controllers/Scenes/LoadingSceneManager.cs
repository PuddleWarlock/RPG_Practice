using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers.Scenes
{
    public class LoadingSceneManager : MonoBehaviour
    {
        public static string NextSceneName;
        private void Start()
        {
            LoadNextScene(NextSceneName);
        }

        private async void LoadNextScene(string nextSceneName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);
            while (!operation.isDone)
            {
                await System.Threading.Tasks.Task.Yield();
            }
        }
    }
}