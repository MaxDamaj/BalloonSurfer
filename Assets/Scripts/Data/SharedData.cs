using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.InitData
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SharedData")]
    public class SharedData : ScriptableObject
    {
        public double scoreValue;
        public int currentBackIndex;
        public bool isGamePaused;

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

        public int RoundedScoreValue
        {
            get
            {
                return (int)scoreValue;
            }
        }
    }
}
