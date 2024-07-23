using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(KitchenAreaController))]
public class KitchenAreaControllerEditor : Editor
{
     public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        KitchenAreaController myScript = (KitchenAreaController)target;
        if (GUILayout.Button("Spawn Worker"))
        {
            myScript.SpawnCookWorker();
        }

        if (GUILayout.Button("Spawn Cooktop"))
        {
            myScript.SpawnCooktop();
        }
    }
}
