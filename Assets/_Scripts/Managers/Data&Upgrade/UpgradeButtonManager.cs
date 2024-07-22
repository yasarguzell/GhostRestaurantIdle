using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonManager : MonoBehaviour
{
   public void UpgradeValueX()
   {
    CoreGameSignals.Instance.onDataValueX?.Invoke(5f);
   }
   public void UpgradeValueY()
   {
    CoreGameSignals.Instance.onDataValueY?.Invoke(12f);
   }
   public void UpgradeValueZ()
   {
    CoreGameSignals.Instance.onDataValueZ?.Invoke(15f);
   }
   public void UpgradeValueA()
   {
    CoreGameSignals.Instance.onDataValueA?.Invoke(20f);
   }
   public void UpgradeValueB()
   {
    CoreGameSignals.Instance.onDataValueB?.Invoke(35f);
   }
}
