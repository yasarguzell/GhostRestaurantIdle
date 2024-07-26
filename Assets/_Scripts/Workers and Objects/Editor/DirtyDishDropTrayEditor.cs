using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DirtyDishDropTray))]
public class DirtyDishDropTrayEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DirtyDishDropTray myScript = (DirtyDishDropTray)target;
    }
}
