using BalloonSurfer.Creators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.EntitySources
{
    public abstract class MutableSource : EntitySource
    {
        public new MutableCreator Creator { get; protected set; }
    }
}
