using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject lostMenu, wonMenu, pauseMenu;

    public void Replay ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowLostMenu ()
    {
        StopGame(lostMenu);
    }

    public void ShowWonmenu ()
    {
        StopGame(wonMenu);
    }

    public void ShowPauseMenu ()
    {
        StopGame(pauseMenu);
    }
    
    public void CloseMenu (GameObject menu)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    private void StopGame (GameObject menu)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        menu.SetActive(true);
    }
}
