using UnityEngine;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Enable Disable")]
  public class EnableDisable : MonoBehaviour
  {
    public void EnableGameobject() => gameObject.SetActive(true);
    public void DisableGameObject() => gameObject.SetActive(false);
    public void ToggleActive() => gameObject.SetActive(!gameObject.activeInHierarchy);
  }

}