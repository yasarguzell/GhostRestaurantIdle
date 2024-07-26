using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDishesTray : MonoBehaviour
{
    public bool IsInUse = false;
    public KitchenAreaController _areaController;
    public Plate PlateOnIt;

    [ContextMenu("Add clean dish")]
    public void AddCleanDish()
    {
        StartCoroutine("ManageCleanDish");
    }

    private IEnumerator ManageCleanDish()
    {
        CookWorker worker;
        while (!_areaController.TryGetAvailableWorker(out worker))
            yield return new WaitForSeconds(1f);

        worker.StartCookingMission(transform.position, this);
    }
}
