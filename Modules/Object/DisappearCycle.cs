using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCycle : MonoBehaviour
{
    public float timeBetweenEnable = 3.0f;
    public float timeLeft = 3.0f;
    
    public GameObject disappearObject;

    public bool isVisible = true;

    //void OnTriggerEnter(Collider other)
    //{
    //    StartCoroutine(ShowAndHide(disappearObject, delay)); // 1 second
    //}

    private void Start()
    {
        timeLeft = timeBetweenEnable;

        isVisible = disappearObject.activeInHierarchy;
    }
    //IEnumerator ShowAndHide(GameObject go, float delay)
    //{
    //    go.SetActive(false);
    //    yield return new WaitForSeconds(delay);
    //    go.SetActive(true); 
    //}

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            disappearObject.SetActive(!isVisible);
            isVisible = !isVisible;

            timeLeft = 3.0f;
        }
    }
}