using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Table : MonoBehaviour
{
    public int _seatAmount;
    [SerializeField] private Transform[] _seatPositions;
    [SerializeField] private Transform[] _platePositions;
    public Plate[] Plates;
    private ServiceAreaController _serviceAreaController;
    [SerializeField] private Transform _getOutPosition;
    public GameObject _seat;

    public/**/   List<CustomerTableChair> chairs;
    public /**/ bool isThereFreeTable;
    private void Start()
    {
        Plates = new Plate[4];
        /*
                chairs = new List<CustomerTableChair>();
                for (int i = 0; i < this.transform.childCount; i++)
                    if (this.transform.GetChild(i).TryGetComponent(out CustomerTableChair chair))
                        if (this.transform.GetChild(i).gameObject.activeSelf)
                            chairs.Add(chair);
        */
        //int freeChairCount = 0;
        //foreach (var chair in chairs)
        //{
        //    if (!chair.isFull)
        //    {
        //        freeChairCount++;
        //    }
        //}

        /*
        _seatAmount = chairs.Count;

        Init(GameObject.FindAnyObjectByType<ServiceAreaController>(), _getOutPosition);
        */

    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //if (CanThereAnyChair())
        //    print("Masada Bo� yer var");
        //else
        //    print("Masada bos yer yok!!!!");
    }



    public void Init(ServiceAreaController serviceAreaController, Transform getOutPosition, int initialSeatAmount)
    {
        _serviceAreaController = serviceAreaController;
        _getOutPosition = getOutPosition;
        for (int i = 0; i < initialSeatAmount; i++)
        {
            AddSeat();
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

        worker.StartReturningDirtyDishMission(_seatPositions[seatIndex].transform.position, this, seatIndex);
    }

    [ContextMenu("Add Seat")]
    public void AddSeat()
    {
        if (_seatAmount == _seatPositions.Length)
            return;
        _seatAmount++;
        GetCustomer(_seatAmount - 1);
        Instantiate(_seat, _seatPositions[_seatAmount - 1]);
    }

    public void GetCustomer(int seatIndex)
    {
        _serviceAreaController.SpawnCustomer(_seatPositions[seatIndex].transform.position, this, seatIndex);
    }

    public Vector3 GetPlatePosition(int seatIndex)
    {
        return _platePositions[seatIndex].position;
    }
}
