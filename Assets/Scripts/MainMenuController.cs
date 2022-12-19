using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame(int playerIndex)
    {
        // UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        GameManager.instance.PlayerIndex = playerIndex;
        SceneManager.LoadScene("Gameplay");
    }
}
