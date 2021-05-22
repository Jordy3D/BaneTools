using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BT;

public class FadeToQuit : MonoBehaviour
{
  public KeyCode quitKey;

  public float timeToQuit = 5f;
  float timer;

  public Image dark;

  void Start()
  {
    if (gameObject.name == "QuitFadeObject")
      dark = GetComponent<Image>();
  }

  void Update()
  {
    if (Input.GetKeyDown(quitKey))
      timer = 0;

    if (Input.GetKey(quitKey))
    {
      timer += Time.deltaTime;

      var tempColor = dark.color;
      tempColor.a = (timer / timeToQuit);
      dark.color = tempColor;

      if (timer > timeToQuit)
      {
        print(BaneStrings.ColorString("Quit Successfully", Color.red));
        Application.Quit();
      }
    }

    if (Input.GetKeyUp(quitKey))
    {
      var tempColor = dark.color;
      tempColor.a = 0;
      dark.color = tempColor;
    }
  }
}
