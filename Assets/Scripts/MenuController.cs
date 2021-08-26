using UnityEngine;
using UnityEngine.SceneManagement;


namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Main");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
