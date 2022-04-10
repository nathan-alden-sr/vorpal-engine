using System.Reflection;
using System.Windows;
using Autofac;
using Stylet;
using VorpalEngine.Samples.EngineTest.Views.Root;

namespace VorpalEngine.Samples.EngineTest;

public class AutofacBootstrapper<TRootViewModel> : BootstrapperBase
    where TRootViewModel : class
{
    private IContainer? _container;
    private TRootViewModel? _rootViewModel;

    public sealed override object GetInstance(Type type)
        => _container!.Resolve(type);

    public override void Dispose()
    {
        ScreenExtensions.TryDispose(_rootViewModel);

        _container?.Dispose();

        GC.SuppressFinalize(this);

        base.Dispose();
    }

    protected sealed override void ConfigureBootstrapper()
    {
        ContainerBuilder containerBuilder = new();

        // Register host views and view-models

        _ = containerBuilder.RegisterType<RootView>().AsSelf().ExternallyOwned();
        _ = containerBuilder.RegisterType<RootViewModel>().AsSelf().ExternallyOwned();

        // Register Stylet components

        ViewManagerConfig viewManagerConfig =
            new()
            {
                ViewFactory = GetInstance,
                ViewAssemblies = new List<Assembly> { typeof(App).Assembly }
            };

        _ = containerBuilder.RegisterType<MessageBoxViewModel>().As<IMessageBoxViewModel>().ExternallyOwned();
        _ = containerBuilder.RegisterInstance<IViewManager>(new ViewManager(viewManagerConfig));
        _ = containerBuilder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
        _ = containerBuilder.RegisterInstance<IWindowManagerConfig>(this).ExternallyOwned();

        // Build the container
        _container = containerBuilder.Build();
    }

    protected override void Launch()
        => DisplayRootView(_rootViewModel = (TRootViewModel)GetInstance(typeof(TRootViewModel)));

    protected override void OnExit(ExitEventArgs e)
        => _container?.Dispose();
}
