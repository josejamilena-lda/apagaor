Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oreja As New Net.HttpListener

        oreja.Start()

        oreja.Prefixes.Add("http://localhost:8080/apaga/")
        oreja.Prefixes.Add("http://localhost:8080/cierra/")

        Dim context As Net.HttpListenerContext

        Do

            context = oreja.GetContext()

            Dim file As String = context.Request.Url.LocalPath

            If file = "/cierra" Then

                'MsgBox("CIERRA")

                For Each p As Process In System.Diagnostics.Process.GetProcessesByName("chrome")
                    Try
                        p.CloseMainWindow()
                        'p.WaitForExit()
                    Catch ex As Exception

                    End Try
                Next

            End If

            If file = "/apaga" Then

                'MsgBox("APAGA")

                For Each p As Process In System.Diagnostics.Process.GetProcessesByName("chrome")
                    Try
                        p.CloseMainWindow()
                        'p.WaitForExit()
                    Catch ex As Exception

                    End Try
                Next

                System.Diagnostics.Process.Start("ShutDown", "-t 0 -s -f")

            End If

        Loop While True

    End Sub

End Class
