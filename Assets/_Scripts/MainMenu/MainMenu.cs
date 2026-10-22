using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //Test: play game >> die >> main menu >> new game
        if (GameSession.Instance != null)
        {
            GameSession.Instance.ResetSession();
        }

        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        // # cho phep tuong tac truc tiep voi he dieu hanh
    }
}
