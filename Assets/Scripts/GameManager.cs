using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsMobile;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);

        DontDestroyOnLoad(gameObject);
        GameObject[] gameManager = GameObject.FindGameObjectsWithTag("GameManager");
        for (int i = 1; i < gameManager.Length; i++) Destroy(gameManager[i]);
    }

    public void OnMobileTouch()
    {
        IsMobile = true;
        SceneManager.LoadScene("GameScene");
    }
    public void OnPCclick()
    {
        IsMobile = false;
        SceneManager.LoadScene("GameScene");
    }
}