using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ServiceAreaController))]
public class ServiceAreaControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ServiceAreaController myScript = (ServiceAreaController)target;
        if (GUILayout.Button("Spawn Worker"))
        {
            myScript.SpawnServiceWorker();
        }

        if (GUILayout.Button("Spawn Table"))
        {
            myScript.SpawnTable();
        }
    }
}
