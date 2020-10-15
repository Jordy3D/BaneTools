using UnityEngine;

[AddComponentMenu("BaneTools/Modules/Detach on Start")]
public class DetachOnStart : MonoBehaviour
{
  public bool destroyScript = false;

  void Start()
  {
    transform.SetParent(null);
    if (destroyScript)
      Destroy(GetComponent<DetachOnStart>());
  }
}
