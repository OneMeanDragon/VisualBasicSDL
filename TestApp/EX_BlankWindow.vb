Imports Microsoft.Extensions.Logging
Imports VisualBasicSDL
Imports VisualBasicSDL.Graphics
Imports VisualBasicSDL.Events
Imports System.Linq                     ' needed for EventArgs.mMouseButtonsPressed.Count in MouseMoving event

Imports SDL2

Namespace EX_BlankWindow

    Public Class FPSCounter
        Private Const MAX_SPAN As Integer = 60
        Private HitMaxSpan As Boolean = False
        Private IndexPos As Integer = 0
        Private mTimeSpanned(MAX_SPAN) As Double

        Private mPreviousTick As Double = 0

        Public Sub New()
            mPreviousTick = SDL.SDL_GetTicks()
        End Sub

        Public Sub EndFrame()
            Dim vCurrentTick As Double = SDL.SDL_GetTicks()
            mTimeSpanned(IndexPos) = (vCurrentTick - mPreviousTick)
            IndexPos += 1
            If IndexPos > MAX_SPAN Then
                HitMaxSpan = True
                IndexPos = 0
            End If
            mPreviousTick = vCurrentTick
        End Sub
        Private ReadOnly Property TotalFramesIn As Integer
            Get
                If HitMaxSpan Then
                    Return MAX_SPAN
                Else
                    Return IndexPos
                End If
            End Get
        End Property
        Public ReadOnly Property CurrentFPS As String
            Get
                If TotalFramesIn = 0 Then
                    Return "0"
                Else
                    Dim locSpan As Double
                    For i As Integer = 0 To TotalFramesIn
                        locSpan += mTimeSpanned(i)
                    Next
                    locSpan /= TotalFramesIn
                    If locSpan > 0 Then
                        Return (1000 / locSpan).ToString
                    Else
                        Return "0"
                    End If
                End If
            End Get
        End Property
    End Class

    Public Class MainGame : Implements IGame

        Private ReadOnly mLogger As ILogger(Of MainGame)
        Private mEngine As IGameEngine
        Private mWindow As IWindow
        Private mRenderer As IRenderer

        ' Font holder
        Private FPSText As TrueTypeText
        Private mFPSCounter As New FPSCounter
        Private MouseCoords As TrueTypeText

        ' Textures
        Private mImageSig As Texture
        Private mImageIcon As Texture
        Private mImageIcon2 As Texture

        Public Sub New(vEngine As IGameEngine, Optional vLogger As ILogger(Of MainGame) = Nothing)
            Me.mEngine = vEngine
            Me.mLogger = vLogger
            With mEngine
                .Initialize = Sub() Initialize()
                .LoadContent = Sub() LoadContent()
                .Update = Sub(gameTime) Update(gameTime)
                .Draw = Sub(gameTime) Draw(gameTime)
                .UnloadContent = Sub() UnloadContent()
            End With
        End Sub

        Public Sub Run() Implements IGame.Run
            mEngine.Start(GameEngineInitializeType.Everything)
        End Sub

        Private Sub Initialize()
            mWindow = mEngine.WindowFactory.CreateWindow("Example 3 - Event Handling")
            mRenderer = mEngine.RendererFactory.CreateRenderer(mWindow)
            mRenderer.SetRenderLogicalSize(1280, 720)
            mRenderer.SetDrawColor(37, 37, 117, 255)

            ' Textures
            Dim surImageSig As Surface = New Surface("Content/ImageOfSig.bmp", SurfaceType.BMP)
            Dim SurImageIcon As Surface = New Surface("Content/botnet.png", SurfaceType.PNG)
            Dim SurImageIcon2 As Surface = New Surface("Content/plug.bmp", SurfaceType.BMP)
            ' Creates a GPU-driven SDL texture using the initialized renderer and created surface
            mImageSig = New Texture(mRenderer, surImageSig)
            mImageIcon = New Texture(mRenderer, SurImageIcon)
            mImageIcon2 = New Texture(mRenderer, SurImageIcon2)

            ' Set FPS Font file etc
            FPSText = mEngine.TrueTypeTextFactory.CreateTrueTypeText(mRenderer, "Content/z3.ttf", "FPS: 0", 20, Colors.White, 0)
            MouseCoords = mEngine.TrueTypeTextFactory.CreateTrueTypeText(mRenderer, "Content/z3.ttf", "MouseCoords X: 0, Y: 0", 20, Colors.White, 0)


            ' Keyboard Events
            AddHandler mEngine.EventManager.KeyReleased, AddressOf KeyReleased
            AddHandler mEngine.EventManager.KeyPressed, AddressOf KeyPressed

            ' Mouse Events
            AddHandler mEngine.EventManager.MouseButtonPressed, AddressOf MouseButtonPressed
            AddHandler mEngine.EventManager.MouseButtonReleased, AddressOf MouseButtonReleased
            AddHandler mEngine.EventManager.MouseWheelScrolling, AddressOf MouseWheelScrolling
            AddHandler mEngine.EventManager.MouseMoving, AddressOf MouseMoving

            ' Window events
            'AddHandler mEngine.EventManager.WindowEverythingElse, AddressOf WindowEverythingElse

        End Sub

        ' Window Events
        'Public Sub WindowEverythingElse(ByVal sender As Object, ByVal EventArgs As WindowEventArgs)
        '    mLogger.LogTrace($"WindowEverythingElse event: WindowID = {EventArgs.mWindowID}.")
        'End Sub

        ' Mouse Events
        Public Sub MouseButtonPressed(ByVal sender As Object, ByVal EventArgs As MouseButtonEventArgs)
            mLogger.LogTrace($"MouseButtonPressed event: State = {EventArgs.mState}, MouseButton = {EventArgs.mMouseButton}.")
        End Sub
        Public Sub MouseButtonReleased(ByVal sender As Object, ByVal EventArgs As MouseButtonEventArgs)
            mLogger.LogTrace($"MouseButtonReleased event: State = {EventArgs.mState}, MouseButton = {EventArgs.mMouseButton}.")
        End Sub
        Public Sub MouseWheelScrolling(ByVal sender As Object, ByVal EventArgs As MouseWheelEventArgs)
            ' Positive Vertical Scroll is Scroll Up higher the value faster you scrolled, Negative is Scroll Down Lesser the value faster you scrolled
            ' note: I have never seen a Horizontal Scroll device on a mouse, is there a ball scroll?
            mLogger.LogTrace($"MouseWheelScrolling event: Type = {EventArgs.mEventType}, HorizontalScrollAmount = {EventArgs.mHorizontalScrollAmount}, VerticalScrollAmount = {EventArgs.mVerticalScrollAmount}.")
        End Sub
        Public Sub MouseMoving(ByVal sender As Object, ByVal EventArgs As MouseMotionEventArgs)
            ' Apparently SDL dosent capture right mouse button being held as a mousepressed while moving
            ' it does however count middle mouse and left mouse buttons
            mLogger.LogTrace($"MouseMoving event: Type = {EventArgs.mEventType}, MouseButtonsPressed = {EventArgs.mMouseButtonsPressed.Count}, MouseX = {EventArgs.mRelativeToWindowX}, MouseY = {EventArgs.mRelativeToWindowY}.")
            MouseCoords.UpdateText("MouseCoords X: " & EventArgs.mRelativeToWindowX & ", Y: " & EventArgs.mRelativeToWindowY)
        End Sub


        ' Keyboard Events.
        Public Sub KeyReleased(ByVal sender As Object, ByVal EventArgs As KeyboardEventArgs)
            mLogger.LogTrace($"Key released event: State = {EventArgs.mState}, VirtualKey = {EventArgs.mKeyInformation.mVirtualKey}, PhysicalKey = {EventArgs.mKeyInformation.mPhysicalKey}.")
        End Sub
        Public Sub KeyPressed(ByVal sender As Object, ByVal EventArgs As KeyboardEventArgs)
            mLogger.LogTrace($"Key pressed event: State = {EventArgs.mState}, VirtualKey = {EventArgs.mKeyInformation.mVirtualKey}, PhysicalKey = {EventArgs.mKeyInformation.mPhysicalKey}.")
        End Sub

        Private Sub LoadContent()
            '
        End Sub

        Private Sub Update(vGameTime As GameTime)
            '

            FPSText.UpdateText("FPS: " & mFPSCounter.CurrentFPS)

        End Sub

        Private Sub Draw(vGameTime As GameTime)
            mRenderer.ClearScreen()

            mImageSig.Draw(0, mImageSig.Width, -45, New Vector2D(mImageSig.Width / 2, mImageSig.Height / 2))
            mImageSig.Draw(300, 300, 45, New Vector2D(mImageSig.Width / 2, mImageSig.Height / 2))
            mImageIcon.Draw(700, 400)
            mImageIcon2.Draw(800, 600, New Rectangle(0, 0, 50, 50))

            'FPSText.UpdateText("FPS: " & mFPSCounter.CurrentFPS)
            FPSText.Texture.Draw(3, 1)
            MouseCoords.Texture.Draw(3, FPSText.Texture.Height + 2)

            mRenderer.RenderPresent()
            mFPSCounter.EndFrame()
        End Sub

        Private Sub UnloadContent()
            mImageSig.Dispose()
            mImageIcon.Dispose()
            mImageIcon2.Dispose()


            FPSText.Dispose()
            MouseCoords.Dispose()
        End Sub
    End Class

End Namespace