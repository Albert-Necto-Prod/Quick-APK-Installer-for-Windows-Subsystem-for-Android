Public Class Form1
    Declare Function AllocConsole Lib "kernel32.dll" () As Boolean
    Dim p As Process = New Process()
    Dim psi As New ProcessStartInfo()
    Dim WorkingDirectory, CurUser, UserIP As String
    Dim cmdpath As String
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Install.Click
        psi.Verb = "runas"
        psi.FileName = "cmd.exe"
        cmdpath = ("platform-tools")
        WorkingDirectory = "C:\Users\" + CurUser + "\" + cmdpath
        psi.WorkingDirectory = WorkingDirectory
        psi.Arguments = cmdpath
        psi.UseShellExecute = False
        psi.RedirectStandardInput = True
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.WindowStyle = ProcessWindowStyle.Hidden
        p.StartInfo = psi
        p.Start()
        p.StandardInput.WriteLine("adb connect " + UserIP)
        p.StandardInput.WriteLine("adb  install -t " + OpenFileDialog1.FileName)
        Label5.Text = Await (p.StandardOutput.ReadLineAsync)
        Label5.Text = "Application installed succesfully"
        MessageBox.Show(" Please check out the result :)", "Operation completed")
        Application.Exit()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_wsastart As Process = New Process()
        Dim psi_wsa As New ProcessStartInfo()
        UserIP = TextBox2.Text
        TextBox1.Text = " "
        Install.Enabled = False
        If Not AllocConsole() Then
            MessageBox.Show("Failed to load console")
        End If
        Console.WindowHeight = 5
        Console.WindowWidth = 1
        Label5.Text = "Working"
        Dim WSHNetwork = CreateObject("WScript.Network")
        CurUser = SystemInformation.UserName
        psi_wsa.Verb = "runas"
        psi_wsa.FileName = "cmd.exe"
        WorkingDirectory = "C:\WINDOWS\system32\"
        psi_wsa.WorkingDirectory = WorkingDirectory
        psi_wsa.UseShellExecute = False
        psi_wsa.RedirectStandardInput = True
        psi_wsa.RedirectStandardOutput = True
        psi_wsa.RedirectStandardError = True
        psi_wsa.WindowStyle = ProcessWindowStyle.Hidden
        p_wsastart.StartInfo = psi_wsa
        p_wsastart.Start()
        p_wsastart.StandardInput.WriteLine("WsaClient /launch wsa://{packagename} ")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Form2 As New Form2
        Form2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            UserIP = TextBox2.Text
            Label5.Text = "Connected to IP"
        End Sub

        Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
            OpenFileDialog1.FileName = "*.apk"
            OpenFileDialog1.ShowDialog()
            OpenFileDialog1.InitialDirectory = "c:\\"
            TextBox1.Text = OpenFileDialog1.FileName
            OpenFileDialog1.FileName = Chr(34) + OpenFileDialog1.FileName + Chr(34)
            Install.Enabled = True
        End Sub


    End Class
