using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SaveLoadUI saveLoadUI;
    [SerializeField] private SaveSystem saveSystem;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button deleteSaveButton;
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

    // private void UpdateContinueButton()
    // {
    //     if (continueButton == null)
    //     {
    //         Debug.LogWarning("ContinueButton is missing.");
    //         return;
    //     }

    //     continueButton.interactable = 
    //         saveSystem != null &&
    //         saveSystem.HasSaveFile();
    // }

    public void ContinueGame()
    {
        if (saveSystem == null || !saveSystem.HasSaveFile())
        {
            Debug.LogWarning("No save file available.");
            UpdateButton();
            return;
        }

        if (saveLoadUI == null)
        {
            Debug.LogWarning("SaveLoadUI is missing.");
            return;
        }

        saveLoadUI.LoadGame();
    }

    private void Start()
    {
        UpdateButton();
    }

    private void UpdateButton()
    {
        bool hasSave = saveSystem != null && saveSystem.HasSaveFile();

        if (continueButton != null)
            continueButton.interactable = hasSave;

        if (deleteSaveButton != null)
            deleteSaveButton.interactable = hasSave;
    }

    public void DeleteSaveGame()
    {
        saveSystem.DeleteSave();
        UpdateButton();
    }
}
