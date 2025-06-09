using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    int counter = 0;
    [SerializeField]
    UnityEvent invoke;
    private void Update()
    {
        if (counter >= 2)
        {
            invoke?.Invoke();
        }
    }

    public void counterup()
    {
        counter += 1;
    }

}
