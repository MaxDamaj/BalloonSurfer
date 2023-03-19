using BalloonSurfer.EntitySources;
using Leopotam.Ecs;

namespace BalloonSurfer.Creators
{
    public abstract class MutableCreator : EntityCreator
    {
        public abstract void Mutate(MutableSource source, EcsEntity entity);
    }
}
