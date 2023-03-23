using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        cursorLock();
    }

    
    public void cursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    } 
    public void cursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
    }
       
}
