using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> restaurants;
    private int index = 0;
    void Start()
    {
        CoreGameSignals.Instance.onNewRestaurant += NewRestaurant;
        index = 0;
    }

    private void NewRestaurant()
    {
        if (index < restaurants.Count)
        {
            restaurants[index].SetActive(true);
            index++;
        }
    }
}
