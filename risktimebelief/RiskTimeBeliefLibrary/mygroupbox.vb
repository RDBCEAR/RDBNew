Imports System.Windows.Forms
Imports System.Drawing


Public Class myGroupBox
    Inherits GroupBox

    Private _borderColor As Color
    Private _borderWidth As Integer = 1
    Private _showBorder As Boolean = True

    Public Sub New()
        MyBase.New()
        Me._borderColor = Color.Black
    End Sub

    Public Property BorderColor() As Color
        Get
            Return Me._borderColor
        End Get
        Set(ByVal value As Color)
            Me._borderColor = value
            Me.Refresh()
        End Set
    End Property

    Public Property BorderWidth() As Integer
        Get
            Return Me._borderWidth
        End Get
        Set(ByVal value As Integer)
            Me._borderWidth = value
            Me.Refresh()
        End Set
    End Property

    Public Property ShowBorder() As Boolean
        Get
            Return Me._showBorder
        End Get
        Set(ByVal value As Boolean)
            Me._showBorder = value
            Me.Refresh()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim tSize As Size = TextRenderer.MeasureText(Me.Text, Me.Font)
        Dim borderRect As Rectangle = Me.ClientRectangle
        borderRect.Y = (borderRect.Y + ((tSize.Height - _borderWidth + 1) / 2))
        borderRect.Height = (borderRect.Height - ((tSize.Height - _borderWidth + 1) / 2))
        If borderRect.Y < 0 Then
            borderRect.Y = 0
            borderRect.Height = borderRect.Height - _borderWidth
        End If
        If _showBorder = True Then
            ControlPaint.DrawBorder(e.Graphics, borderRect, _borderColor, _borderWidth, ButtonBorderStyle.Solid, _borderColor, _borderWidth, ButtonBorderStyle.Solid, _borderColor, _borderWidth, ButtonBorderStyle.Solid, _borderColor, _borderWidth, ButtonBorderStyle.Solid)
        End If
        Dim textRect As Rectangle = Me.ClientRectangle
        textRect.X = (textRect.X + 6)
        textRect.Width = tSize.Width
        textRect.Height = tSize.Height
        e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), textRect)
        e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), textRect)
    End Sub
End Class

