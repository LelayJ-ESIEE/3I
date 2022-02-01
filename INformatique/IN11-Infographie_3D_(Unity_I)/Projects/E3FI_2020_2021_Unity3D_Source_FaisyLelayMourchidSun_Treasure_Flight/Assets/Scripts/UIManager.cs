using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class UIManager : MonoBehaviour
{
 
    public void StartGame()
    {
        EventManager.Instance.Raise(new PlayButtonClickedEvent() );
    }
    public void StartDemo()
    {
        EventManager.Instance.Raise(new DemoButtonClickedEvent() );
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMenu()
    {
        EventManager.Instance.Raise(new MainMenuButtonClickedEvent());
    }
   
}
