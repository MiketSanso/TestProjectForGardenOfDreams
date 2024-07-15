using UnityEngine;
using TMPro;
using Zenject;

public class ReloadingTextInstaller : MonoInstaller
{
    [SerializeField] private TMP_Text reloadingText;

    public override void InstallBindings()
    {
        Container.Bind<TMP_Text>().FromInstance(reloadingText).AsSingle();
    }
}
