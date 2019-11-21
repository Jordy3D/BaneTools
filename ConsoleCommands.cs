using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using System.Linq;

public class ConsoleCommands : MonoBehaviour
{
  public string triggerCharacter = "!";

  public InputField consoleInput;

  public string[] keyWords;
  public UnityEvent[] events;

  public string enteredString;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void CheckCommandSimple()
  {
    enteredString = consoleInput.text;

    if (!enteredString.StartsWith("!"))
    {
      print("Not a command");
    }
    else
    {
      enteredString.Substring(1);

      for (int i = 0; i < keyWords.Length; i++)
      {
        if (keyWords[i] == enteredString)
        {
          events[i].Invoke();
        }
      }
    }
  }

  public void CheckCommandSwitchSystem()
  {
    enteredString = consoleInput.text;

    if (!enteredString.StartsWith("!"))
    {
      print("Not a command");
    }
    else
    {
      enteredString = enteredString.Substring(1);
      string[] args = enteredString.Split(' ');
      var command = args[0];

      switch (command)
      {
        case "Yes":
          print(args[1]);
          print(args[2]);
          break;
        case "No":
          break;
      }
    }
  }

  public void Event1()
  {
    print("First event called");
  }
  public void Event2()
  {
    print("Second event called");
  }
}
