using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDishesTray : MonoBehaviour
{
    public CleanDishesTray CleanDishesTray;
    public DishwashingAreaController _areaController;

    [ContextMenu("Add dirty dish")]
    public void AddDirtyDish()
    {
        // add to there visually

        StartCoroutine("ManageDirtyDish");
    }


    private IEnumerator ManageDirtyDish()
    {
        DishwashingWorker worker;
        while (!_areaController.TryGetAvailableWorker(out worker))
            yield return new WaitForSeconds(1f);

        worker.StartMission(transform.position, CleanDishesTray.transform.position);
    }
}
