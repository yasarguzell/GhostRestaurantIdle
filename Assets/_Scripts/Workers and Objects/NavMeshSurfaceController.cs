using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshSurfaceController : MonoBehaviour
{
    public static NavMeshSurfaceController Instance;
    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }

    void Start()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
        UpdateNavMesh();
    }

    [ContextMenu("Update Navmesh")]
    public void UpdateNavMesh()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
