using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public void ChangeLevel(string toLevel)
    {
        SceneManager.LoadScene(toLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeLevel("SampleScene");
        }
    }
}
