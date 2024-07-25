using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceAreaController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _initialMovementSpeed;
    [SerializeField] private int _maxWorkerAmount = 6;
    [SerializeField] private int _initialSeatAmount = 1;

    [Header("Customer Settings")]
    [SerializeField] private GameObject _customer;
    [SerializeField] private Transform _customerSpawnPoint;
    [SerializeField] private Transform _getOutPosition;
    [SerializeField] private float _initialEatingTime;
    [SerializeField] private float _customerInitialMovementSpeed;

    [Header("References")]
    [SerializeField] private BetweenAreasController _betweenAreasController;
    [SerializeField] private Transform _idlePosition;
    [SerializeField] private GameObject _table;
    [SerializeField] private GameObject _serviceWorker;
    [SerializeField] private Transform[] _tableLocations;
    [SerializeField] private Transform _workerSpawnLocation;
    [SerializeField] private Transform _customerSpawnLocation;

    // Spawned objects
    private List<Table> _tables;
    private List<ServiceWorker> _serviceWorkers;


    private void Awake()
    {
        _tables = new List<Table>();
        _serviceWorkers = new List<ServiceWorker>();
    }

    [ContextMenu("Spawn table")]
    public void SpawnTable()
    {
        if (_tables.Count == _tableLocations.Length)
            return;
        var table = Instantiate(_table, _tableLocations[_tables.Count]).GetComponent<Table>();
        _tables.Add(table);
        NavMeshSurfaceController.Instance.UpdateNavMesh();
        table.Init(this, _getOutPosition/*, _initialSeatAmount*/);
    }

    [ContextMenu("Spawn Worker")]
    public void SpawnServiceWorker()
    {
        if (_serviceWorkers.Count == _maxWorkerAmount)
            return;
        ServiceWorker worker = Instantiate(_serviceWorker, _workerSpawnLocation).GetComponent<ServiceWorker>();
        _serviceWorkers.Add(worker);
        worker.Init(this, _initialMovementSpeed, _idlePosition.position, _betweenAreasController);
      
    }

    public void SpawnCustomer(Vector3 seatPosition, Table tableReference, int seatIndex)
    {
        // Spawn customer
        Customer customer = Instantiate(_customer, _customerSpawnPoint).GetComponent<Customer>();
        // Initialize the customer
        customer.Init(this, _initialEatingTime, _initialMovementSpeed);
        customer.StartEatingMission(seatPosition, _getOutPosition.position, tableReference, seatIndex,.1f);
    }

    public bool TryGetAvailableWorker(out ServiceWorker worker)
    {
        for (int i = 0; i < _serviceWorkers.Count; i++)
        {
            if (_serviceWorkers[i].WorkerState == WorkerState.idle)
            {
                _serviceWorkers[i].WorkerState = WorkerState.working;
                worker = _serviceWorkers[i];

                _serviceWorkers.RemoveAt(i);
                _serviceWorkers.Add(worker);

                return true;
            }
        }

        worker = null;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        foreach (Transform tr in _tableLocations)
            Gizmos.DrawSphere(tr.position, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_idlePosition.position, 0.5f);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_customerSpawnLocation.position, 0.5f);
    }
}
