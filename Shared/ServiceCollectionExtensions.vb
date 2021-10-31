Imports System
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.DependencyInjection.Extensions
Imports VisualBasicSDL.Events
Imports VisualBasicSDL.Graphics
Imports System.Runtime.CompilerServices

Namespace VisualBasicSDL.[Shared]
    Module SharpGameServiceCollectionExtensions
        <Extension()>
        Function AddSharpGame(Of T As {Class, IGame})(ByVal vServices As IServiceCollection) As IServiceCollection
            If vServices Is Nothing Then
                Throw New ArgumentNullException(NameOf(vServices))
            End If

            vServices.TryAdd(ServiceDescriptor.Singleton(Of IGame, T)())
            vServices.TryAdd(ServiceDescriptor.Singleton(Of IGameEngine, GameEngine)())
            vServices.TryAdd(ServiceDescriptor.Singleton(Of IWindowFactory, WindowFactory)())
            vServices.TryAdd(ServiceDescriptor.Singleton(Of IRendererFactory, RendererFactory)())
            vServices.TryAdd(ServiceDescriptor.Singleton(Of ISurfaceFactory, SurfaceFactory)())
            vServices.TryAdd(ServiceDescriptor.Singleton(Of ITextureFactory, TextureFactory)())
            vServices.TryAdd(ServiceDescriptor.Singleton(Of ITrueTypeTextFactory, TrueTypeTextFactory)())
            vServices.TryAdd(ServiceDescriptor.Singleton(Of IEventManager, EventManager)())
            Return vServices
        End Function
    End Module
End Namespace
