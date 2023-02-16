using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Click : MonoBehaviour
{
   public void arcade()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Application.LoadLevel(2);
    }
    public void trailer()
    {
        Application.LoadLevel(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
