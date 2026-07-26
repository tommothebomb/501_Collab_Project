using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    // this is the logic manager script for the menu
    // it controls the buttons and other stuff

    [SerializeField] Animator animator;
    [SerializeField] GameObject secret;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        AkUnitySoundEngine.PostEvent("Play_sfx_forward", this.gameObject);
        animator.SetTrigger("controls"); // animates the UI to go from the menu screen to the controls screen
    }

    public void Credits()
    {
        AkUnitySoundEngine.PostEvent("Play_sfx_forward", this.gameObject);
        animator.SetTrigger("credits"); // animates the UI to go from the menu screen to the controls screen
    }

    public void Return()
    {
        AkUnitySoundEngine.PostEvent("Play_sfx_back", this.gameObject);
        animator.SetTrigger("return"); // animates the UI to go from any screen back to the menu screen
    }

    public void ExitGame()
    {
        Application.Quit(); // quits the game (only works in .exe)
    }
}
