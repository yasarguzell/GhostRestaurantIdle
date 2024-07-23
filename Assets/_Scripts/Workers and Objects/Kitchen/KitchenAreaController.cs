using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenAreaController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _initialCookingTime;
    [SerializeField] private float _initialMovementSpeed;
    [SerializeField] private int _maxWorkerAmount = 6;

    [Header("References")]
    [SerializeField] private BetweenAreasController _betweenAreasController;
    [SerializeField] private Transform _idlePosition;
    [SerializeField] private GameObject _cooktop;
    [SerializeField] private GameObject _cookWorker;
    [SerializeField] private Transform[] _cooktopLocations;
    [SerializeField] private Transform _workerSpawnLocation;

    // Spawned objects
    public List<Cooktop> _cooktops;
    public List<CookWorker> _cookWorkers;


    private void Awake()
    {
        _cooktops = new List<Cooktop>();
        _cookWorkers = new List<CookWorker>();
    }

    [ContextMenu("Spawn Cooktop")]
    public void SpawnDishwashingMachine()
    {
        if (_cooktops.Count == _cooktopLocations.Length)
            return;
        var cooktop = Instantiate(_cooktop, _cooktopLocations[_cooktops.Count]).GetComponent<Cooktop>();
        _cooktops.Add(cooktop);
    }

    [ContextMenu("Spawn Worker")]
    public void SpawnWashingWorker()
    {
        if (_cookWorkers.Count == _maxWorkerAmount)
            return;
        CookWorker worker = Instantiate(_cookWorker, _workerSpawnLocation).GetComponent<CookWorker>();
        _cookWorkers.Add(worker);
        worker.Init(this, _initialCookingTime, _initialMovementSpeed, _idlePosition.position, _betweenAreasController);
    }

    public bool TryGetAvailableCooktop(out Cooktop cooktop)
    {
        for (int i = 0; i < _cooktops.Count; i++)
        {
            if (!_cooktops[i].IsInUse)
            {
                _cooktops[i].IsInUse = true;
                cooktop = _cooktops[i];

                _cooktops.RemoveAt(i);
                _cooktops.Add(cooktop);

                return true;
            }
        }

        cooktop = null;
        return false;
    }

    public bool TryGetAvailableWorker(out CookWorker worker)
    {
        for (int i = 0; i < _cookWorkers.Count; i++)
        {
            if (_cookWorkers[i].WorkerState == WorkerState.idle)
            {
                _cookWorkers[i].WorkerState = WorkerState.working;
                worker = _cookWorkers[i];

                _cookWorkers.RemoveAt(i);
                _cookWorkers.Add(worker);

                return true;
            }
        }

        worker = null;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        foreach (Transform tr in _cooktopLocations)
            Gizmos.DrawSphere(tr.position, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_idlePosition.position, 0.5f);
    }
}
