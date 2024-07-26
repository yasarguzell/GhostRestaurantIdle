using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    public static PlateController Instance;
    public GameObject Plate;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }

    public Plate CreatePlate(Vector3 position)
    {
        return Instantiate(Plate, position, Quaternion.identity).GetComponent<Plate>();
    }
}
