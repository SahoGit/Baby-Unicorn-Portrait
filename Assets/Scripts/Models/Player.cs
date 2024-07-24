using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    #region Variables, Constants & Initializers

    public GameObject makeup;
    #endregion


    public void SetMakeup(GameObject makeup)
    {
        this.makeup = makeup;
    }

    public GameObject GetMakeup()
    {
        return this.makeup;
    }
}
