using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Table : MonoBehaviour
{
    [SerializeField] private int _seatAmount = 4;
    [SerializeField] private Transform[] _seatPositions;
    private ServiceAreaController _serviceAreaController;
    private Transform _getOutPosition;

    public void Init(ServiceAreaController serviceAreaController, Transform getOutPosition, int seatAmount)
    {
        _serviceAreaController = serviceAreaController;
        _seatAmount = seatAmount;
        _getOutPosition = getOutPosition;
        for (int i = 0; i < seatAmount; i++)
        {
            GetCustomer(i);
        }
    }

    public void CallForDirtyDishPickUp(int seatIndex)
    {
        StartCoroutine(CallForDirtyDishPickUpCoroutine(seatIndex));
    }

    private IEnumerator CallForDirtyDishPickUpCoroutine(int seatIndex)
    {
        ServiceWorker worker = null;
        while (!_serviceAreaController.TryGetAvailableWorker(out worker))
        {
            yield return null;
        }

        worker.StartReturningDirtyDishMission(_seatPositions[seatIndex].position, this, seatIndex);
    }

    [ContextMenu("Add Seat")]
    private void AddSeat()
    {
        if (_seatPositions.Length == _seatAmount)
            return;
        _seatAmount++;
        GetCustomer(_seatAmount - 1);
    }

    public void GetCustomer(int seatIndex)
    {
        _serviceAreaController.SpawnCustomer(_seatPositions[seatIndex].position, this, seatIndex);
    }
}
