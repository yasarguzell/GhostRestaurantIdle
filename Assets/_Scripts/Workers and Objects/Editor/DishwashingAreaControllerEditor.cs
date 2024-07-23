using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DishwashingAreaController))]
public class DishwashingAreaControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DishwashingAreaController myScript = (DishwashingAreaController)target;
        if (GUILayout.Button("Spawn Worker"))
        {
            myScript.SpawnWashingWorker();
        }

        if (GUILayout.Button("Spawn Dishwashing Machine"))
        {
            myScript.SpawnDishwashingMachine();
        }
    }
}
