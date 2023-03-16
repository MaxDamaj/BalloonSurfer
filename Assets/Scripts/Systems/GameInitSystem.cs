using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitSystem : IEcsPreInitSystem, IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem, IEcsPostDestroySystem
{
    private EcsWorld _world = null;


    public void PreInit()
    {
        
    }

    public void Init()
    {
        var player = _world.NewEntity();
        var moveSideComponent = player.Get<MoveSide>();

        var playerPrefab = GameObject.Instantiate(MainData.Instance.playerInitData.prefab, Vector3.zero, Quaternion.identity);
        moveSideComponent.speed = MainData.Instance.playerInitData.moveSideSpeed;
    }

    public void Run()
    {
        
    }

    public void Destroy()
    {
        
    }

    public void PostDestroy()
    {
        
    }
}
