using UnityEngine;

public class ExitConfirmation : MonoBehaviour
{
    public GameObject exitConfirmationPanel;

    public void ShowExitConfirmation()
    {
        exitConfirmationPanel.SetActive(true);
    }

    public void HideExitConfirmation()
    {
        exitConfirmationPanel.SetActive(false);
    }

    public void ConfirmExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}

