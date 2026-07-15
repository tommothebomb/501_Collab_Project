using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] GameObject returnToMenu;
    Animator phoneAnimator;

    [SerializeField] GameObject appButtons;
    [SerializeField] GameObject closeAppButton;
    [SerializeField] GameObject settingsApp;
    [SerializeField] GameObject messagesApp;

    void Start()
    {
        phoneAnimator = GameObject.FindGameObjectWithTag("PhoneUI").GetComponent<Animator>();
    }

    public void ReturnToMenu()
    {
        returnToMenu.SetActive(true);
    }

    public void YesMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NoMenu()
    {
        returnToMenu.SetActive(false);
    }

    public void UnPause()
    {
        phoneAnimator.SetBool("isPaused", false);
        CloseApp();
    }

    public void OpenSettings()
    {
        OpenApp();
        settingsApp.SetActive(true);
    }

    public void OpenMessages()
    {
        OpenApp();
        messagesApp.SetActive(true);
    }

    void OpenApp()
    {
        appButtons.SetActive(false);
        closeAppButton.SetActive(true);
    }

    public void CloseApp()
    {
        appButtons.SetActive(true);
        closeAppButton.SetActive(false);
        messagesApp.SetActive(false);
        settingsApp.SetActive(false);
    }
}
