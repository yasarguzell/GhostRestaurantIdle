using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [System.Serializable]
    public class VFXElement
    {
        public string name;
        public Transform vFX_Prefab;
        public float destroyDelay;
    }

    [Header("VFX Elements")]
    [SerializeField] List<VFXElement> vFX_ElementList = new List<VFXElement>();

    private Dictionary<string, VFXElement> vFX_ElementDictionary = new Dictionary<string, VFXElement>();

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < vFX_ElementList.Count; i++)
        {
            vFX_ElementDictionary.Add(vFX_ElementList[i].name, vFX_ElementList[i]);
        }
    }

    public void PlayVFX(string name, Vector3 position, Quaternion rotation)
    {
        VFXElement tempVFXElement = vFX_ElementDictionary[name];

        Transform vFX_Transform = GameObject.Instantiate(tempVFXElement.vFX_Prefab, position, rotation);
        DelayedDestroy tempDelayedDestroy = vFX_Transform.gameObject.AddComponent<DelayedDestroy>();
        tempDelayedDestroy.seconds = tempVFXElement.destroyDelay;
        tempDelayedDestroy.RestartCoroutine();
    }
}
