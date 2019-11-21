using UnityEngine;

[AddComponentMenu("BaneTools/Modules/Disable on Start")]
public class DisableOnStart : MonoBehaviour
{
  public bool destroyScript = false;
  // Start is called before the first frame update
  void Start()
  {
    gameObject.SetActive(false);
    if (destroyScript)
      Destroy(GetComponent<DisableOnStart>());
  }
}
