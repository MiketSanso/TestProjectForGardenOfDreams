using UnityEngine;
using Zenject;

public class CricleAgressionPlayerInstaller : MonoInstaller
{
    [SerializeField] private CircleLaunchingEnemyAggression circleAgressive;

    public override void InstallBindings()
    {
        Container.Bind<CircleLaunchingEnemyAggression>().FromInstance(circleAgressive).AsSingle();
    }
}
