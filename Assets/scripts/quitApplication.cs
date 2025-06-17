using UnityEngine;
using UnityEngine.InputSystem;

public class quitApplication : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Debug.Log("quit");
            Application.Quit();
        }
    }
}
