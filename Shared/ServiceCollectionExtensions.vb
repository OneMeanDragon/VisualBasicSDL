Imports System
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.DependencyInjection.Extensions
Imports VisualBasicSDL.Events
Imports VisualBasicSDL.Graphics
Imports System.Runtime.CompilerServices

Namespace VisualBasicSDL.[Shared]
    Module SharpGameServiceCollectionExtensions
        <Extension()>
        Function AddSharpGame(Of T As {Class, IGame})(ByVal services As IServiceCollection) As IServiceCollection
            If services Is Nothing Then
                Throw New ArgumentNullException(NameOf(services))
            End If

            services.TryAdd(ServiceDescriptor.Singleton(Of IGame, T)())
            services.TryAdd(ServiceDescriptor.Singleton(Of IGameEngine, GameEngine)())
            services.TryAdd(ServiceDescriptor.Singleton(Of IWindowFactory, WindowFactory)())
            services.TryAdd(ServiceDescriptor.Singleton(Of IRendererFactory, RendererFactory)())
            services.TryAdd(ServiceDescriptor.Singleton(Of ISurfaceFactory, SurfaceFactory)())
            services.TryAdd(ServiceDescriptor.Singleton(Of ITextureFactory, TextureFactory)())
            services.TryAdd(ServiceDescriptor.Singleton(Of ITrueTypeTextFactory, TrueTypeTextFactory)())
            services.TryAdd(ServiceDescriptor.Singleton(Of IEventManager, EventManager)())
            Return services
        End Function
    End Module
End Namespace
