using UnityEngine;
using Zenject;

public class PrefabsManagerInstaller : MonoInstaller
{
    [SerializeField] private PrefabsManager prefabsManager;

    public override void InstallBindings()
    {
        Container.Bind<PrefabsManager>().FromInstance(prefabsManager).AsSingle();
    }
}