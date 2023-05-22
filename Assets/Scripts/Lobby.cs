using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
   public void Game_start_button_on()
    {
        SceneManager.LoadScene("BallGame");
    }
}
