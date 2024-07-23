using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwashingAreaController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _initialWashingTime;
    [SerializeField] private float _initialMovementSpeed;
    [SerializeField] private int _maxWorkerAmount = 6;

    [Header("References")]
    [SerializeField] private BetweenAreasController _betweenAreasController;
    [SerializeField] private Transform _idlePosition;
    [SerializeField] private GameObject _dishwashingMachine;
    [SerializeField] private GameObject _dishwashingWorker;
    [SerializeField] private Transform[] _dishwashingMachineLocations;
    [SerializeField] private Transform _workerSpawnLocation;

    // Spawned objects
    public List<DishwashingMachine> _dishwashingMachines;
    public List<DishwashingWorker> _washingWorkers;


    private void Awake()
    {
        _dishwashingMachines = new List<DishwashingMachine>();
        _washingWorkers = new List<DishwashingWorker>();
    }

    [ContextMenu("Spawn Machine")]
    public void SpawnDishwashingMachine()
    {
        if (_dishwashingMachines.Count == _dishwashingMachineLocations.Length)
            return;
        var machine = Instantiate(_dishwashingMachine, _dishwashingMachineLocations[_dishwashingMachines.Count]).GetComponent<DishwashingMachine>();
        _dishwashingMachines.Add(machine);
    }

    [ContextMenu("Spawn Worker")]
    public void SpawnWashingWorker()
    {
        if (_washingWorkers.Count == _maxWorkerAmount)
            return;
        DishwashingWorker worker = Instantiate(_dishwashingWorker, _workerSpawnLocation).GetComponent<DishwashingWorker>();
        _washingWorkers.Add(worker);
        worker.Init(this, _initialWashingTime, _initialMovementSpeed, _idlePosition.position, _betweenAreasController);
    }

    public bool TryGetAvailableDishwashingMachine(out DishwashingMachine machine)
    {
        for (int i = 0; i < _dishwashingMachines.Count; i++)
        {
            if (!_dishwashingMachines[i].IsInUse)
            {
                _dishwashingMachines[i].IsInUse = true;
                machine = _dishwashingMachines[i];

                _dishwashingMachines.RemoveAt(i);
                _dishwashingMachines.Add(machine);

                return true;
            }
        }

        machine = null;
        return false;
    }

    public bool TryGetAvailableWorker(out DishwashingWorker worker)
    {
        for (int i = 0; i < _washingWorkers.Count; i++)
        {
            if (_washingWorkers[i].WorkerState == WorkerState.idle)
            {
                _washingWorkers[i].WorkerState = WorkerState.working;
                worker = _washingWorkers[i];

                _washingWorkers.RemoveAt(i);
                _washingWorkers.Add(worker);

                return true;
            }
        }

        worker = null;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        foreach (Transform tr in _dishwashingMachineLocations)
            Gizmos.DrawSphere(tr.position, 0.5f);


        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_idlePosition.position, 0.5f);
    }
}
