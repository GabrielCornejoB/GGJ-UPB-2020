using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public string playGameLevel;
    public void PlayGame()
    {
        Application.LoadLevel(playGameLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.anyKey && Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        } else  if (Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(1)){
            PlayGame();
        }
    }
    private static void GoToSite(string url)
    {
        Application.OpenURL(url);
    }

    public static void openAndresGallego()
    {
        GoToSite("https://www.behance.net/andygallego");

    }
    public static void openSamuelRodriguez()
    {
        GoToSite("");

    }
    public static void openMarianaCano()
    {
        GoToSite("");
        
    }
    public static void openAndresCano()
    {
        GoToSite("https://www.linkedin.com/in/canoaf/");
        
    }
    public static void openGabrielCornejo()
    {
        GoToSite("https://www.instagram.com/gabrielcornejobotero7/?hl=es-la");
        
    }
    public static void openEduardoHincapie()
    {
        GoToSite("");
        
    }
}
