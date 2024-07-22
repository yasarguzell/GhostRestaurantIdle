using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonManager : MonoBehaviour
{
   public void UpgradeValueX()
   {
    CoreGameSignals.Instance.onDataValueX?.Invoke(5f);
   }
}
