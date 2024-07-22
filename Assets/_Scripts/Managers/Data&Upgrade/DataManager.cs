using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // update ref update manager
    SODataHolder soDataHolder;


    void Awake()
    {
        soDataHolder = GetDataHolder();
    }
    private SODataHolder GetDataHolder()
    {

        return Resources.Load<SODataHolder>("Datas/SODataHolder");
    }
    void OnEnable()
    {
        Subscribe();
    }
    void OnDisable()
    {
        UnSubscribe();
    }

    void Subscribe()
    {
        CoreGameSignals.Instance.onDataValueX += onGetDataX;
        CoreGameSignals.Instance.onDataValueY += onGetDataY;
        CoreGameSignals.Instance.onDataValueZ += onGetDataZ;
        CoreGameSignals.Instance.onDataValueA += onGetDataA;
        CoreGameSignals.Instance.onDataValueB += onGetDataB;

    }
    private void UnSubscribe()
    {
        CoreGameSignals.Instance.onDataValueX -= onGetDataX;
        CoreGameSignals.Instance.onDataValueY -= onGetDataY;
        CoreGameSignals.Instance.onDataValueZ -= onGetDataZ;
        CoreGameSignals.Instance.onDataValueA -= onGetDataA;
        CoreGameSignals.Instance.onDataValueB -= onGetDataB;
    }


    private void onGetDataB(float value)
    {
        soDataHolder.dataHolder.valueB += value;
    }

    private void onGetDataA(float value)
    {
        soDataHolder.dataHolder.valueA += value;
    }

    private void onGetDataZ(float value)
    {
        soDataHolder.dataHolder.valueZ += value;
    }

    private void onGetDataY(float value)
    {
         soDataHolder.dataHolder.valueY += value;
    }

    private void onGetDataX(float value)
    {
         soDataHolder.dataHolder.valueX += value;
    }


    



}
