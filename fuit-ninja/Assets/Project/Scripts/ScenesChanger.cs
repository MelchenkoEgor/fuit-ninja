using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts
{
    public class ScenesChanger : MonoBehaviour
    {
        public void ChangeScene(string nameScene)
        {
            SceneManager.LoadScene(nameScene);
        }
    }
}
