using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TakeABreak : MonoBehaviour
{
    public static float elapsedTime = 0;
    public static float breakTime = 1800.0f;
    public static bool warning;
    public static GameObject breakMessage; // provided by LoseMenu script

    void Awake() {
        int numInstances = FindObjectsOfType<TakeABreak>().Length;
        if (numInstances > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            warning = false;
            StartCoroutine(RunTimer());
        }
    }

    private IEnumerator RunTimer()
    {
        while (true)
        {
            elapsedTime += Time.deltaTime;

            if ((int)elapsedTime % breakTime == breakTime-1 && !warning) // warn user to take a break every [breakTime] seconds
            {  
                warning = true;
            }
            yield return null;
        }
    }

    public static void Warn()
    {
        breakMessage.SetActive(true);
    }

    public static void Acknowledge()
    {
        breakMessage.SetActive(false);
        warning = false;
    }
        
    public static GameObject FindInActiveObject(GameObject parent, string name)
    {
        Transform[] trs= parent.GetComponentsInChildren<Transform>(true);
        foreach(Transform t in trs){
            if(t.name == name){
                return t.gameObject;
            }
        }
        return null;
    }
}
