Imports System
Imports VisualBasicSDL.Events
Imports VisualBasicSDL.Graphics

Namespace VisualBasicSDL
    Public Interface IGameEngine
        Inherits IDisposable

        Property Initialize As Action
        Property LoadContent As Action
        Property Update As Action(Of GameTime)
        Property Draw As Action(Of GameTime)
        Property UnloadContent As Action
        Property WindowFactory As IWindowFactory
        Property RendererFactory As IRendererFactory
        Property TextureFactory As ITextureFactory
        Property SurfaceFactory As ISurfaceFactory
        Property TrueTypeTextFactory As ITrueTypeTextFactory
        Property EventManager As IEventManager
        Sub Start(ByVal initilizeTypes As GameEngineInitializeType)
        Sub [End]()
    End Interface
End Namespace