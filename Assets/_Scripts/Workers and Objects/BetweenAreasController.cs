using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenAreasController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<DirtyDishesTray> _dirtyDishesTrays;
    [SerializeField] private List<CleanDishesTray> _cleanDishesTrays;
    [SerializeField] private List<ReadyFoodTray> _readyFoodTrays;
    public DirtyDishDropTray _dirtyDishDropTray;

    public bool TryGetAvailableDirtyDishTray(out DirtyDishesTray tray)
    {
        for (int i = 0; i < _dirtyDishesTrays.Count; i++)
        {
            if (!_dirtyDishesTrays[i].IsInUse)
            {
                _dirtyDishesTrays[i].IsInUse = true;
                tray = _dirtyDishesTrays[i];

                _dirtyDishesTrays.RemoveAt(i);
                _dirtyDishesTrays.Add(tray);

                return true;
            }
        }

        tray = null;
        return false;
    }

    public bool TryGetAvailableCleanDishTray(out CleanDishesTray tray)
    {
        for (int i = 0; i < _cleanDishesTrays.Count; i++)
        {
            if (!_cleanDishesTrays[i].IsInUse)
            {
                _cleanDishesTrays[i].IsInUse = true;
                tray = _cleanDishesTrays[i];

                _cleanDishesTrays.RemoveAt(i);
                _cleanDishesTrays.Add(tray);

                return true;
            }
        }

        tray = null;
        return false;
    }

    public bool TryGetAvailableReadyFoodTray(out ReadyFoodTray tray)
    {
        for (int i = 0; i < _readyFoodTrays.Count; i++)
        {
            if (!_readyFoodTrays[i].IsInUse)
            {
                _readyFoodTrays[i].IsInUse = true;
                tray = _readyFoodTrays[i];

                _readyFoodTrays.RemoveAt(i);
                _readyFoodTrays.Add(tray);

                return true;
            }
        }

        tray = null;
        return false;
    }

    public bool TryGetReadyFood(out ReadyFoodTray tray)
    {
        for (int i = 0; i < _readyFoodTrays.Count; i++)
        {
            if (_readyFoodTrays[i].IsInUse && !_readyFoodTrays[i].IsSelectedByWorker)
            {
                tray = _readyFoodTrays[i];
                _readyFoodTrays[i].IsSelectedByWorker = true;
                return true;
            }
        }

        tray = null;
        return false;
    }
}
