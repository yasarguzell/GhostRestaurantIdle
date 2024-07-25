using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTable : MonoBehaviour
{
    public/**/   List<CustomerTableChair> chairs;
    public /**/ bool isThereFreeTable;
    public/**/ int isFullCount = 0;
    private void Start()
    {
        chairs = new List<CustomerTableChair>();
        for (int i = 0; i < this.transform.childCount; i++)
            if (this.transform.GetChild(i).TryGetComponent(out CustomerTableChair chair))
                chairs.Add(chair);

        //if (CanThereAnyChair())
        //    print("Masada Boþ yer var");
        //else
        //    print("Masada bos yer yok!!!!");



    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //    if (CanThereAnyChair())
        //        print("Masada Boþ yer var");
        //    else
        //        print("Masada bos yer yok!!!!");
    }

    //bool CanThereAnyChair()
    //{
    //    foreach (var chair in chairs)
    //        if (!chair.isFull)
    //            return true;
    //    return false;
    //}
}




//foreach (var chair in chairs)
//{
//    if (chair.isFull)
//    {
//        isThereFreeTable = false;

//    }
//    else
//    {
//        isThereFreeTable = true;
//        break;
//     

//    }

//}