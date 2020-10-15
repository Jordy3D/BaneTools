using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCycle : MonoBehaviour
{
    public float timeBetweenEnable = 3.0f;
    public float timeLeft = 3.0f;
    
    public GameObject disappearObject;

    public bool isVisible = true;

    private void Start()
    {
        timeLeft = timeBetweenEnable;
        isVisible = disappearObject.activeInHierarchy;
    }
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