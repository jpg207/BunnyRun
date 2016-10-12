using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject AudioOn;
    public GameObject AudioOff;

	// Use this for initialization
	void Start () {
        SetSoundState();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        Application.LoadLevel("Bunny run");
    }

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        SetSoundState();
    }

    private void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            AudioOn.SetActive(true);
            AudioOff.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            AudioOn.SetActive(false);
            AudioOff.SetActive(true);
        }
    }
}
