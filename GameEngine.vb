Imports Microsoft.Extensions.Logging
Imports SDL2
Imports VisualBasicSDL.Events
Imports VisualBasicSDL.Graphics
Imports VisualBasicSDL.Input
Imports System

Namespace VisualBasicSDL
    Public NotInheritable Class GameEngine
        Implements IGameEngine

        Private Const mFixedFramesPerSecond As Single = 120.0F
        Private mIsFrameRateCapped As Boolean = True
        Private ReadOnly mLogger As ILogger(Of GameEngine)
        Private ReadOnly mGameTime As GameTime = New GameTime()
        Private ReadOnly mGameTimer As Timer = New Timer()
        Private ReadOnly mTargetElapsedTime As TimeSpan = TimeSpan.FromSeconds(1 / mFixedFramesPerSecond)
        Private ReadOnly mMaxElapsedTime As TimeSpan = TimeSpan.FromSeconds(0.5)
        Private mAccumulatedElapsedTime As TimeSpan = TimeSpan.Zero
        Public Property WindowFactory As IWindowFactory Implements IGameEngine.WindowFactory
        Public Property RendererFactory As IRendererFactory Implements IGameEngine.RendererFactory
        Public Property TextureFactory As ITextureFactory Implements IGameEngine.TextureFactory
        Public Property SurfaceFactory As ISurfaceFactory Implements IGameEngine.SurfaceFactory
        Public Property TrueTypeTextFactory As ITrueTypeTextFactory Implements IGameEngine.TrueTypeTextFactory
        Public Property EventManager As IEventManager Implements IGameEngine.EventManager
        Private Property IsActive As Boolean
        Private Property IsExiting As Boolean
        Public Property Initialize As Action Implements IGameEngine.Initialize
        Public Property LoadContent As Action Implements IGameEngine.LoadContent
        Public Property Update As Action(Of GameTime) Implements IGameEngine.Update
        Public Property Draw As Action(Of GameTime) Implements IGameEngine.Draw
        Public Property UnloadContent As Action Implements IGameEngine.UnloadContent

        Public Sub New(ByVal vWindowFactory As IWindowFactory, ByVal vRendererFactory As IRendererFactory, ByVal vTextureFactory As ITextureFactory, ByVal vSurfaceFactory As ISurfaceFactory, ByVal vTrueTypeTextFactory As ITrueTypeTextFactory, ByVal vEventManager As IEventManager, ByVal Optional vLogger As ILogger(Of GameEngine) = Nothing)
            Try
                WindowFactory = vWindowFactory
                RendererFactory = vRendererFactory
                TextureFactory = vTextureFactory
                SurfaceFactory = vSurfaceFactory
                EventManager = vEventManager
                TrueTypeTextFactory = vTrueTypeTextFactory
                mLogger = vLogger
                AddHandler EventManager.WindowClosed, AddressOf OnExiting
                AddHandler EventManager.Quitting, AddressOf OnExiting
            Catch ex As Exception
                Throw New InvalidOperationException("Ball Sack.")
            End Try
        End Sub

        Private Sub OnExiting(ByVal sender As Object, ByVal e As GameEventArgs)
            IsExiting = True
        End Sub

        Public Sub Start(ByVal types As GameEngineInitializeType) Implements IGameEngine.Start
            PerformInitialize(types)
            PerformLoadContent()

            While Not IsExiting
                Dim rawEvent As SDL.SDL_Event = New SDL.SDL_Event()

                While SDL.SDL_PollEvent(rawEvent) = 1
                    mLogger.LogTrace($"SDL_Event: {rawEvent.type.ToString()}")
                    EventManager.RaiseEvents(rawEvent)
                End While

                Tick()
            End While

            PerformUnloadContent()
            Dispose()
        End Sub

        Private Sub Tick()
            While mIsFrameRateCapped AndAlso (mAccumulatedElapsedTime < mTargetElapsedTime)
                mAccumulatedElapsedTime += mGameTimer.ElapsedTime
                mGameTimer.Start()

                If mIsFrameRateCapped AndAlso (mAccumulatedElapsedTime < mTargetElapsedTime) Then
                    Dim sleepTime As TimeSpan = mTargetElapsedTime - mAccumulatedElapsedTime
                    SDL.SDL_Delay(CUInt(sleepTime.TotalMilliseconds))
                End If
            End While

            If mAccumulatedElapsedTime > mMaxElapsedTime Then mAccumulatedElapsedTime = mMaxElapsedTime

            If mIsFrameRateCapped Then
                Dim stepCount As Integer = 0

                While mAccumulatedElapsedTime >= mTargetElapsedTime
                    mGameTime.TotalGameTime += mTargetElapsedTime
                    mAccumulatedElapsedTime -= mTargetElapsedTime
                    stepCount += 1
                    PerformUpdate(mGameTime)
                End While

                mGameTime.ElapsedGameTime = TimeSpan.FromTicks(mTargetElapsedTime.Ticks * stepCount)
            Else
                mGameTime.ElapsedGameTime = mAccumulatedElapsedTime
                mGameTime.TotalGameTime += mTargetElapsedTime
                mAccumulatedElapsedTime = TimeSpan.Zero
                PerformUpdate(mGameTime)
            End If

            PerformDraw(mGameTime)
        End Sub

        Public Sub [End]() Implements IGameEngine.End
            IsExiting = True
            EventManager.RaiseExiting(Me, EventArgs.Empty)
        End Sub

        Private Sub PerformInitialize(ByVal types As GameEngineInitializeType)
            InitializeBase(types)
            Initialize.Invoke()
        End Sub

        Private Sub InitializeBase(ByVal types As GameEngineInitializeType)
            If SDL.SDL_Init(CUInt(types)) <> 0 Then
                Throw New InvalidOperationException($"SDL_Init: {SDL.SDL_GetError()}")
            End If

            If SDL_ttf.TTF_Init() <> 0 Then
                Throw New InvalidOperationException($"TTF_Init: {SDL.SDL_GetError()}")
            End If

            Dim initImageFlags As SDL_image.IMG_InitFlags = SDL_image.IMG_InitFlags.IMG_INIT_JPG Or SDL_image.IMG_InitFlags.IMG_INIT_PNG Or SDL_image.IMG_InitFlags.IMG_INIT_TIF Or SDL_image.IMG_InitFlags.IMG_INIT_WEBP
            Dim initImageResult As Integer = SDL_image.IMG_Init(initImageFlags)

            If (initImageResult And CInt(initImageFlags)) <> CInt(initImageFlags) Then
                Throw New InvalidOperationException($"IMG_Init: {SDL.SDL_GetError()}")
            End If
        End Sub

        Private Sub PerformLoadContent()
            LoadContent.Invoke()
        End Sub

        Private Sub PerformUpdate(ByVal vGameTime As GameTime)
            Mouse.UpdateMouseState()
            Update.Invoke(vGameTime)
        End Sub

        Private Sub PerformDraw(ByVal vGameTime As GameTime)
            Draw.Invoke(vGameTime)
        End Sub

        Private Sub PerformUnloadContent()
            UnloadContent.Invoke()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub

        Private Sub Dispose(ByVal disposing As Boolean)
            SDL_ttf.TTF_Quit()
            SDL_image.IMG_Quit()
            SDL.SDL_Quit()
        End Sub

    End Class
End Namespace
