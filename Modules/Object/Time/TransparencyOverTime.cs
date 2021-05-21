using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Change Transparency Over Time")]
  public class TransparencyOverTime : MonoBehaviour
  {
    public Color startColour, targetColour;
    public float time;
    public TargetType objectType = TargetType.TextMeshPro;

    public Transform targetObject;

    float currentTime;
    public bool isEnabled = false;

    void Start()
    {
      currentTime = 0;

      if (!targetObject)
        targetObject = transform;
    }

    void Update()
    {
      if (isEnabled && currentTime <= time)
        ChangeTransparency();
    }

    public void ChangeTransparency()
    {
      switch (objectType)
      {
        case TargetType.Text:
          Text t1 = targetObject.GetComponent<Text>();
          t1.color = Color.Lerp(startColour, targetColour, currentTime);
          break;
        case TargetType.TextMeshPro:
          TextMeshPro t2 = targetObject.GetComponent<TextMeshPro>();
          t2.color = Color.Lerp(startColour, targetColour, currentTime);
          break;
        case TargetType.TextMeshProUGUI:
          TextMeshProUGUI t3 = targetObject.GetComponent<TextMeshProUGUI>();
          t3.color = Color.Lerp(startColour, targetColour, currentTime);
          break;
        case TargetType.Image:
          Image t4 = targetObject.GetComponent<Image>();
          t4.color = Color.Lerp(startColour, targetColour, currentTime);
          break;
        case TargetType.SpriteRenderer:
          SpriteRenderer t5 = targetObject.GetComponent<SpriteRenderer>();
          t5.color = Color.Lerp(startColour, targetColour, currentTime);
          break;
      }
      currentTime += Time.deltaTime;
    }

    public enum TargetType
    {
      Text,
      TextMeshPro,
      TextMeshProUGUI,
      Image,
      SpriteRenderer
    }
  }

}