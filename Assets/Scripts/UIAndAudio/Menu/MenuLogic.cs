using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    // this is the logic manager script for the menu
    // it controls the buttons and other stuff

    [SerializeField] Animator animator;
    
    public void StartGame()
    {
        //SceneManager.LoadScene("");
    }

    public void Controls()
    {
        animator.SetTrigger("controls"); // animates the UI to go from the menu screen to the controls screen
    }

    public void Credits()
    {
        animator.SetTrigger("credits"); // animates the UI to go from the menu screen to the controls screen
    }

    public void Return()
    {
        animator.SetTrigger("return"); // animates the UI to go from any screen back to the menu screen
    }

    public void ExitGame()
    {
        Application.Quit(); // quits the game (only works in .exe)
    }
}
