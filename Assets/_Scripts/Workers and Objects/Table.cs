using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Table : MonoBehaviour
{
    private int _seatAmount;
    //[SerializeField] private Transform[] _seatPositions;
    private ServiceAreaController _serviceAreaController;
    [SerializeField] private Transform _getOutPosition;

    public/**/   List<CustomerTableChair> chairs;
    public /**/ bool isThereFreeTable;
    private void Start()
    {

        chairs = new List<CustomerTableChair>();
        for (int i = 0; i < this.transform.childCount; i++)
            if (this.transform.GetChild(i).TryGetComponent(out CustomerTableChair chair))
                if (this.transform.GetChild(i).gameObject.activeSelf)
                    chairs.Add(chair);

        //int freeChairCount = 0;
        //foreach (var chair in chairs)
        //{
        //    if (!chair.isFull)
        //    {
        //        freeChairCount++;
        //    }
        //}
        _seatAmount = chairs.Count;

        Init(GameObject.FindAnyObjectByType<ServiceAreaController>(), _getOutPosition);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
            //if (CanThereAnyChair())
            //    print("Masada Bo� yer var");
            //else
            //    print("Masada bos yer yok!!!!");
    }



    public void Init(ServiceAreaController serviceAreaController, Transform getOutPosition)
    {
        _serviceAreaController = serviceAreaController;
        //_getOutPosition = getOutPosition;
        for (int i = 0; i < chairs.Count; i++)
        {
            //if (!chairs[i].isFull)
            //{
                GetCustomer(i);
                //chairs[i].isFull = true;
            //}

        }
    }
    //private bool CanThereAnyChair()
    //{
    //    foreach (var chair in chairs)
    //        if (!chair.isFull)
    //            return true;
    //    return false;
    //}
    public void CallForDirtyDishPickUp(int seatIndex)
    {
        StartCoroutine(CallForDirtyDishPickUpCoroutine(seatIndex));
    }

    private IEnumerator CallForDirtyDishPickUpCoroutine(int seatIndex)
    {
        ServiceWorker worker = null;
        while (!_serviceAreaController.TryGetAvailableWorker(out worker))
        {
            yield return new WaitForSeconds(1);
        }

        worker.StartReturningDirtyDishMission(chairs[seatIndex].transform.position, this, seatIndex);
    }

    [ContextMenu("Add Seat")]
    public void AddSeat()
    {
        if (chairs.Count == _seatAmount)
            return;
        _seatAmount++;
        GetCustomer(_seatAmount - 1);
    }

    public void GetCustomer(int seatIndex)
    {
        _serviceAreaController.SpawnCustomer(chairs[seatIndex].transform.position, this, seatIndex);
    }
}
