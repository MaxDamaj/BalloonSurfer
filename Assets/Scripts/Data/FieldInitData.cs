using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.InitData
{
    [CreateAssetMenu(menuName = "ScriptableObjects/FieldInitData")]
    public class FieldInitData : InitData
    {
        [SerializeField, Range(3f, 9f)] private int fieldLines = 3;  //Чилос полос на поле. Работает только с нечётным числом, при чётных значениях округляется вниз до нечётного
        public double scoresPerSecond = 1;
        public float fieldWidth = 60f;
        public float spawnDelayTime = 3;

        #region Fields

        public int FieldLines
        {
            get
            {
                return fieldLines % 2 == 1 ? fieldLines : fieldLines - 1;
            }
        }

        public int FieldLowerBorder
        {
            get
            {
                return -Mathf.FloorToInt(fieldLines / 2f);
            }
        }

        public int FieldUpperBorder
        {
            get
            {
                return Mathf.FloorToInt(fieldLines / 2f);
            }
        }

        public float FieldLineWidth
        {
            get
            {
                return fieldWidth / FieldLines;
            }
        }

        public int RandomLine
        {
            get
            {
                return Random.Range(MainData.GetData<FieldInitData>().FieldLowerBorder, MainData.GetData<FieldInitData>().FieldUpperBorder + 1);
            }
        }

        #endregion
    }
}
