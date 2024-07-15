using UnityEngine;
using Zenject;

public class SearchFreeCellsInstaller : MonoInstaller
{
    [SerializeField] private SearchSuitableCell searchSuitableCell;

    public override void InstallBindings()
    {
        Container.Bind<SearchSuitableCell>().FromInstance(searchSuitableCell).AsSingle();
    }
}