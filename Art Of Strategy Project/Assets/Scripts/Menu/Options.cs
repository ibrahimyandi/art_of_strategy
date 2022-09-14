using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public void openOptions()
    {
        GameObject.Find("MainMenu").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("OptionsMenu").transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void openMenu()
    {
        GameObject.Find("OptionsMenu").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("MainMenu").transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void backgroundMusicVolume()
    {
        GameObject.Find("Background Music").GetComponent<AudioSource>().volume = GameObject.Find("Music Slider").GetComponent<Slider>().value;
    }
    public void exit()
    {
        Application.Quit();
    }
}
