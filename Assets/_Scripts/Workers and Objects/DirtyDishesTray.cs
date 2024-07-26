using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDishesTray : MonoBehaviour
{
    public bool IsInUse = false;
    public DishwashingAreaController _areaController;
    public Vector3 PlatePosition;
    public Plate PlateOnIt;

    private void Start()
    {
        PlatePosition = transform.TransformPoint(Vector3.up * 0.5f);
        InitializePlate();
        AddDirtyDish();

    }

    [ContextMenu("Add dirty dish")]
    public void AddDirtyDish()
    {
        StartCoroutine("ManageDirtyDish");
    }


    private IEnumerator ManageDirtyDish()
    {
        DishwashingWorker worker;
        while (!_areaController.TryGetAvailableWorker(out worker))
            yield return new WaitForSeconds(1f);

        worker.StartMission(transform.position, this);
    }

    private void InitializePlate()
    {
        PlateOnIt = PlateController.Instance.CreatePlate(transform.TransformPoint(Vector3.up * 0.5f));
        IsInUse = true;
    }
}
