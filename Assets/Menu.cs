using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    public void goToGame(){
        SceneManager.LoadScene("GamePlay");
    }
}
