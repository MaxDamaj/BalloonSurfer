using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SharedData")]
public class SharedData : ScriptableObject
{
    public double scoreValue;

    #region Instance

    private static SharedData _instance = null;
    public static SharedData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<SharedData>("SharedData");
            }

            return _instance;
        }
    }

    #endregion
}
