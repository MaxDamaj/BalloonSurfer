using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.InitData
{
    [CreateAssetMenu(menuName = "ScriptableObjects/MainData")]
    public class MainData : ScriptableObject
    {
        public PlayerInitData playerInitData;
        public EnemiesInitData enemiesInitData;
        public FieldInitData fieldInitData;
        public BackgroundsInitData backgroundsInitData;

        #region Instance

        private static MainData _instance = null;
        public static MainData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<MainData>("MainData");
                }

                return _instance;
            }
        }

        #endregion
    }
}
