Imports System.IO
Public Class RayearthTool
    Dim loadForm As Boolean = False
    Dim fontName As String = "青鸟华光简粗圆"
    Public Config As String = Application.StartupPath + "\RayearthTool.ini"
    Dim fileList As String() = {"CLEFMES.BIN", "HINTMES.BIN", "ITEMMES.BIN", "WINMSG.BIN"}
    Dim fileADVList As String() = {"INITMES.BIN"}
    Dim file0List As Int32() = {407644, 417712}
    Private Sub ButtonCodePage_Click(sender As Object, e As EventArgs) Handles ButtonCodePage.Click
        My.Computer.FileSystem.CreateDirectory(TextBoxDataCodePage.Text + "\CodePage_png")
        Dim subPath = Directory.GetDirectories(TextBoxGameCodePage.Text)
        ProgressBar1.Maximum = subPath.Count + 1
        ProgressBar1.Value = 0
        For f = 0 To fileList.Count - 1
            MSG2IMG(TextBoxGameCodePage.Text + "\" + fileList(f)).Save(TextBoxDataCodePage.Text + "\CodePage_png\" + fileList(f) + ".png")
        Next
        For f = 0 To fileADVList.Count - 1
            MSG2IMG(TextBoxGameCodePage.Text + "\ADV\" + fileADVList(f)).Save(TextBoxDataCodePage.Text + "\CodePage_png\" + fileADVList(f) + ".png")
        Next
        For f = 0 To file0List.Count - 1
            MSG2IMG(TextBoxGameCodePage.Text + "\0", file0List(f)).Save(TextBoxDataCodePage.Text + "\CodePage_png\0_" + file0List(f).ToString + ".png")
        Next
        ProgressBar1.Value += 1
        For p = 0 To subPath.Count - 1
            Dim files = Directory.GetFiles(subPath(p), "*.MSG")
            For i = 0 To files.Count - 1
                MSG2IMG(files(i)).Save(TextBoxDataCodePage.Text + "\CodePage_png\" + System.IO.Path.GetFileName(files(i)) + ".png")
            Next
            ProgressBar1.Value += 1
        Next
    End Sub
    Private Sub ButtonOut_Click(sender As Object, e As EventArgs) Handles ButtonOut.Click
        My.Computer.FileSystem.CreateDirectory(TextBoxDataOut.Text + "\Script")
        My.Computer.FileSystem.CreateDirectory(TextBoxDataOut.Text + "\Text")
        My.Computer.FileSystem.CreateDirectory(TextBoxDataOut.Text + "\Data")
        Dim subPath = Directory.GetDirectories(TextBoxGameOut.Text)
        ProgressBar1.Maximum = subPath.Count + 1
        ProgressBar1.Value = 0
        For f = 0 To fileList.Count - 1
            Dim tempString = MSG2TXT(True, TextBoxDataOut.Text, TextBoxGameOut.Text + "\" + fileList(f))
            IO.File.WriteAllText(TextBoxDataOut.Text + "\SCRIPT\" + fileList(f) + ".txt", tempString(0), System.Text.Encoding.UTF8)
            If True Then
                IO.File.WriteAllText(TextBoxDataOut.Text + "\TEXT\" + fileList(f) + ".csv", tempString(1), System.Text.Encoding.UTF8)
            End If
            MSG2DAT(TextBoxDataOut.Text, TextBoxGameOut.Text + "\" + fileList(f))
        Next
        For f = 0 To fileADVList.Count - 1
            Dim tempString = MSG2TXT(True, TextBoxDataOut.Text, TextBoxGameOut.Text + "\ADV\" + fileADVList(f))
            IO.File.WriteAllText(TextBoxDataOut.Text + "\SCRIPT\" + fileADVList(f) + ".txt", tempString(0), System.Text.Encoding.UTF8)
            If True Then
                IO.File.WriteAllText(TextBoxDataOut.Text + "\TEXT\" + fileADVList(f) + ".csv", tempString(1), System.Text.Encoding.UTF8)
            End If
            MSG2DAT(TextBoxDataOut.Text, TextBoxGameOut.Text + "\ADV\" + fileADVList(f))
        Next
        For f = 0 To file0List.Count - 1
            Dim tempString = MSG2TXT(True, TextBoxDataOut.Text, TextBoxGameOut.Text + "\0", file0List(f))
            IO.File.WriteAllText(TextBoxDataOut.Text + "\SCRIPT\" + "0" + "_" + file0List(f).ToString + ".txt", tempString(0), System.Text.Encoding.UTF8)
            If True Then
                IO.File.WriteAllText(TextBoxDataOut.Text + "\TEXT\" + "0" + "_" + file0List(f).ToString + ".csv", tempString(1), System.Text.Encoding.UTF8)
            End If
        Next
        ProgressBar1.Value += 1
        For p = 0 To subPath.Count - 1
            Dim files = Directory.GetFiles(subPath(p), "*.MSG")
            For i = 0 To files.Count - 1
                Dim file As String = System.IO.Path.GetFileName(files(i))
                Dim tempString = MSG2TXT(True, TextBoxDataOut.Text, files(i))
                IO.File.WriteAllText(TextBoxDataOut.Text + "\SCRIPT\" + file + ".txt", tempString(0), System.Text.Encoding.UTF8)
                If True Then
                    IO.File.WriteAllText(TextBoxDataOut.Text + "\TEXT\" + file + ".csv", tempString(1), System.Text.Encoding.UTF8)
                End If
                MSG2DAT(TextBoxDataOut.Text, files(i))
            Next
            ProgressBar1.Value += 1
        Next
    End Sub
    Private Sub ButtonIn_Click(sender As Object, e As EventArgs) Handles ButtonIn.Click
        Dim subPath = Directory.GetDirectories(TextBoxGameIn.Text)
        ProgressBar1.Maximum = subPath.Count + 1
        ProgressBar1.Value = 0
        For f = 0 To fileList.Count - 1
            TEXT2MSG(TextBoxDataFont.Text, TextBoxDataIn.Text, TextBoxGameIn.Text + "\" + fileList(f), fontName, NumericUpDownSize.Value, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked, CheckBox1.Checked)
        Next
        For f = 0 To fileADVList.Count - 1
            TEXT2MSG(TextBoxDataFont.Text, TextBoxDataIn.Text, TextBoxGameIn.Text + "\ADV\" + fileADVList(f), fontName, NumericUpDownSize.Value, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked, CheckBox1.Checked)
        Next
        For f = 0 To file0List.Count - 1
            TEXT2MSG(TextBoxDataFont.Text, TextBoxDataIn.Text, TextBoxGameIn.Text + "\0", fontName, NumericUpDownSize.Value, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked, CheckBox1.Checked, file0List(f))
        Next
        ProgressBar1.Value += 1
        For p = 0 To subPath.Count - 1
            Dim files = Directory.GetFiles(subPath(p), "*.MSG")
            For i = 0 To files.Count - 1
                TEXT2MSG(TextBoxDataFont.Text, TextBoxDataIn.Text, files(i), fontName, NumericUpDownSize.Value, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked, CheckBox1.Checked)
            Next
            ProgressBar1.Value += 1
        Next
    End Sub
    Private Sub UpdataImage()
        If loadForm And TextBoxFont.Text.Length > 0 Then
            Dim tempImage As Bitmap
            Dim imageFile As String = TextBoxDataFont.Text + "\" + Char.ConvertToUtf32(TextBoxFont.Text(0), 0).ToString + ".png"
            If CheckBox1.Checked And IO.File.Exists(imageFile) Then
                tempImage = New Bitmap(imageFile)
            Else
                tempImage = CreateFontBitmap(TextBoxFont.Text(0), fontName, NumericUpDownSize.Value, (TextBoxFont.Text.Length * 16) + 4, 16 + 4, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked)
            End If
            Dim image1 As Bitmap = New Bitmap(16, 16)
            For y = 0 To 16 - 1
                For x = 0 To 16 - 1
                    image1.SetPixel(x, y, tempImage.GetPixel(x, y))
                Next
            Next
            Dim image2 As Bitmap = New Bitmap(TextBoxFont.Text.Length * 16, 16)
            For i = 0 To TextBoxFont.Text.Length - 1
                imageFile = TextBoxDataFont.Text + "\" + Char.ConvertToUtf32(TextBoxFont.Text(i), 0).ToString + ".png"
                If CheckBox1.Checked And IO.File.Exists(imageFile) Then
                    tempImage = New Bitmap(imageFile)
                Else
                    tempImage = CreateFontBitmap(TextBoxFont.Text(i), fontName, NumericUpDownSize.Value, (TextBoxFont.Text.Length * 16) + 4, 16 + 4, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked)
                End If
                For y = 0 To 16 - 1
                    For x = 0 To 16 - 1
                        image2.SetPixel(i * 16 + x, y, Color.FromArgb(tempImage.GetPixel(x, y).A / 16 * 16, 0, 0, 0))
                    Next
                Next
            Next
            Dim tempText = "魔法骑士"
            Dim image3 As Bitmap = New Bitmap(tempText.Length * 16, 16)
            For i = 0 To tempText.Length - 1
                imageFile = TextBoxDataFont.Text + "\" + Char.ConvertToUtf32(tempText(i), 0).ToString + ".png"
                If CheckBox1.Checked And IO.File.Exists(imageFile) Then
                    tempImage = New Bitmap(imageFile)
                Else
                    tempImage = CreateFontBitmap(tempText(i), fontName, NumericUpDownSize.Value, (tempText.Length * 16) + 4, 16 + 4, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked)
                End If
                For y = 0 To 16 - 1
                    For x = 0 To 16 - 1
                        image3.SetPixel(i * 16 + x, y, Color.FromArgb(tempImage.GetPixel(x, y).A / 16 * 16, 0, 0, 0))
                    Next
                Next
            Next
            PictureBox1.Image = image1
            PictureBox2.Image = image2
            PictureBox3.Image = image3
            tempImage.Dispose()
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFont.TextChanged
        UpdataImage()
    End Sub

    Private Sub NumericUpDownX_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownX.ValueChanged
        UpdataImage()
    End Sub

    Private Sub NumericUpDownY_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownY.ValueChanged
        UpdataImage()
    End Sub

    Private Sub NumericUpDownSize_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownSize.ValueChanged
        UpdataImage()
    End Sub

    Private Sub CheckBoxBold_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBold.CheckedChanged
        UpdataImage()
    End Sub

    Private Sub CheckBoxPixel_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPixel.CheckedChanged
        UpdataImage()
    End Sub

    Private Sub ButtonFont_Click(sender As Object, e As EventArgs) Handles ButtonFont.Click
        If FontDialog1.ShowDialog = DialogResult.OK Then
            fontName = FontDialog1.Font.Name
            WriteINI("Config", "FontName", fontName, Config)
            UpdataImage()
        End If
    End Sub

    Private Sub RayearthTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadForm = True
        TextBoxGameOut.Text = GetINI("Config", "GameOutPath", Application.StartupPath, Config)
        TextBoxGameIn.Text = GetINI("Config", "GameInPath", Application.StartupPath, Config)
        TextBoxGameCodePage.Text = GetINI("Config", "GameCodePagePath", Application.StartupPath, Config)
        TextBoxDataOut.Text = GetINI("Config", "DataOutPath", Application.StartupPath, Config)
        TextBoxDataIn.Text = GetINI("Config", "DataInPath", Application.StartupPath, Config)
        TextBoxDataCodePage.Text = GetINI("Config", "DataCodePagePath", Application.StartupPath, Config)
        TextBoxDataFont.Text = GetINI("Config", "DataFontPath", Application.StartupPath, Config)
        fontName = GetINI("Config", "FontName", Application.StartupPath, Config)
        UpdataImage()
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image.Save(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        UpdataImage()
    End Sub

    Private Sub ButtonFontOut_Click(sender As Object, e As EventArgs) Handles ButtonFontOut.Click
        Dim subPath = Directory.GetDirectories(TextBoxGameOut.Text)
        ProgressBar1.Maximum = subPath.Count + 1
        ProgressBar1.Value = 0
        For f = 0 To fileList.Count - 1
            MSG2UTF(TextBoxDataOut.Text, TextBoxGameOut.Text + "\" + fileList(f))
        Next
        For f = 0 To fileADVList.Count - 1
            MSG2UTF(TextBoxDataOut.Text, TextBoxGameOut.Text + "\ADV\" + fileADVList(f))
        Next
        For f = 0 To file0List.Count - 1
            MSG2UTF(TextBoxDataOut.Text, TextBoxGameOut.Text + "\0", file0List(f))
        Next
        ProgressBar1.Value += 1
        For p = 0 To subPath.Count - 1
            Dim files = Directory.GetFiles(subPath(p), "*.MSG")
            For i = 0 To files.Count - 1
                MSG2UTF(TextBoxDataOut.Text, files(i))
            Next
            ProgressBar1.Value += 1
        Next
    End Sub

    Private Sub ButtonCheckText_Click(sender As Object, e As EventArgs) Handles ButtonCheckText.Click
        FolderBrowserDialog1.SelectedPath = TextBoxDataIn.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Dim tempPath = FolderBrowserDialog1.SelectedPath
            Dim files = Directory.GetFiles(tempPath, "*.csv")
            Dim fileName As String = ""
            Dim debugLogText As String = ""
            ProgressBar1.Maximum = files.Count + 1
            ProgressBar1.Value = 0
            For f = 0 To files.Count - 1
                Dim fs As FileStream = New FileStream(files(f), FileMode.Open, FileAccess.Read)
                Dim br As New StreamReader(fs, System.Text.Encoding.UTF8)
                Dim tempText As String = br.ReadLine()
                Dim lineCount As Integer = 1
                Do Until tempText Is Nothing
                    Dim tempStr As String() = Split(tempText, ",")
                    Dim countParFirst As Integer = CountOccurrences(tempStr(0), "{Par}")
                    Dim countParLast As Integer = CountOccurrences(tempStr(tempStr.Count - 1), "{Par}")
                    Dim countNewlineFirst As Integer = CountOccurrences(tempStr(0), "{/n}")
                    Dim countNewlineLast As Integer = CountOccurrences(tempStr(tempStr.Count - 1), "{/n}")
                    If countParFirst <> countParLast Or countNewlineFirst > countNewlineLast Or countNewlineLast > 2 Then
                        If Not fileName = Path.GetFileNameWithoutExtension(files(f)) Then
                            If Not fileName = "" Then
                                debugLogText &= vbCrLf
                            End If
                            fileName = Path.GetFileNameWithoutExtension(files(f))
                            debugLogText &= fileName
                            debugLogText &= vbCrLf
                        End If
                        debugLogText &= lineCount.ToString
                        debugLogText &= "行   "
                        If countParFirst <> countParLast Then
                            debugLogText &= "{Par}数量不一致。"
                            debugLogText &= countParFirst.ToString
                            debugLogText &= "/"
                            debugLogText &= countParLast.ToString
                            debugLogText &= "   "
                        End If
                        If countNewlineFirst > countNewlineLast Then
                            debugLogText &= "{/n}数量缺失。"
                            debugLogText &= countNewlineFirst.ToString
                            debugLogText &= "/"
                            debugLogText &= countNewlineLast.ToString
                            debugLogText &= "   "
                        End If
                        If countNewlineLast > 2 Then
                            debugLogText &= "{/n}数量溢出。"
                            debugLogText &= countNewlineLast.ToString
                            debugLogText &= "   "
                        End If
                        debugLogText &= Strings.Left(tempStr(0), 10)
                        debugLogText &= vbCrLf
                    End If
                    tempText = br.ReadLine()
                    lineCount += 1
                Loop
                ProgressBar1.Value += 1
            Next
            IO.File.WriteAllText(tempPath + "\DebugLog.txt", debugLogText, System.Text.Encoding.UTF8)
        End If
    End Sub

    Private Sub ButtonGameOut_Click(sender As Object, e As EventArgs) Handles ButtonGameOut.Click
        FolderBrowserDialog1.SelectedPath = TextBoxGameOut.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBoxGameOut.Text = FolderBrowserDialog1.SelectedPath
            WriteINI("Config", "GameOutPath", TextBoxGameOut.Text, Config)
        End If
    End Sub

    Private Sub ButtonGameIn_Click(sender As Object, e As EventArgs) Handles ButtonGameIn.Click
        FolderBrowserDialog1.SelectedPath = TextBoxGameIn.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBoxGameIn.Text = FolderBrowserDialog1.SelectedPath
            WriteINI("Config", "GameInPath", TextBoxGameIn.Text, Config)
        End If
    End Sub
    Private Sub ButtonGameCodePage_Click(sender As Object, e As EventArgs) Handles ButtonGameCodePage.Click
        FolderBrowserDialog1.SelectedPath = TextBoxGameCodePage.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBoxGameCodePage.Text = FolderBrowserDialog1.SelectedPath
            WriteINI("Config", "GameCodePagePath", TextBoxGameCodePage.Text, Config)
        End If
    End Sub
    Private Sub ButtonDataOut_Click(sender As Object, e As EventArgs) Handles ButtonDataOut.Click
        FolderBrowserDialog1.SelectedPath = TextBoxDataOut.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBoxDataOut.Text = FolderBrowserDialog1.SelectedPath
            WriteINI("Config", "DataOutPath", TextBoxDataOut.Text, Config)
        End If
    End Sub

    Private Sub ButtonDataIn_Click(sender As Object, e As EventArgs) Handles ButtonDataIn.Click
        FolderBrowserDialog1.SelectedPath = TextBoxDataIn.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBoxDataIn.Text = FolderBrowserDialog1.SelectedPath
            WriteINI("Config", "DataInPath", TextBoxDataIn.Text, Config)
        End If
    End Sub

    Private Sub ButtonDataCodePage_Click(sender As Object, e As EventArgs) Handles ButtonDataCodePage.Click
        FolderBrowserDialog1.SelectedPath = TextBoxDataCodePage.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBoxDataCodePage.Text = FolderBrowserDialog1.SelectedPath
            WriteINI("Config", "DataCodePagePath", TextBoxDataCodePage.Text, Config)
        End If
    End Sub

    Private Sub ButtonDataFont_Click(sender As Object, e As EventArgs) Handles ButtonDataFont.Click
        FolderBrowserDialog1.SelectedPath = TextBoxDataFont.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBoxDataFont.Text = FolderBrowserDialog1.SelectedPath
            WriteINI("Config", "DataFontPath", TextBoxDataFont.Text, Config)
        End If
    End Sub

    Private Sub ButtonDebugIn_Click(sender As Object, e As EventArgs) Handles ButtonDebugIn.Click
        Dim subPath = Directory.GetDirectories(TextBoxGameIn.Text)
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 1
        Dim files = Directory.GetFiles(TextBoxGameIn.Text, TextBoxDebug.Text)
        Dim SpecifiedFile = TextBoxGameIn.Text + "\STAGE01\ST010.MSG"
        For i = 0 To files.Count - 1
            TEXT2MSG(TextBoxDataFont.Text, TextBoxDataIn.Text, files(i), fontName, NumericUpDownSize.Value, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked, CheckBox1.Checked, SpecifiedFile)
        Next
        For p = 0 To subPath.Count - 1
            files = Directory.GetFiles(subPath(p), TextBoxDebug.Text)
            For i = 0 To files.Count - 1
                TEXT2MSG(TextBoxDataFont.Text, TextBoxDataIn.Text, files(i), fontName, NumericUpDownSize.Value, NumericUpDownX.Value, NumericUpDownY.Value, CheckBoxBold.Checked, CheckBoxPixel.Checked, CheckBox1.Checked, SpecifiedFile)
            Next
        Next
        ProgressBar1.Value = ProgressBar1.Maximum
    End Sub

End Class
