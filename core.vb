Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Text

Module core
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    Public Function GetINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As String
        Dim Str As String = LSet(Str, 256)
        GetPrivateProfileString(Section, AppName, lpDefault, Str, Len(Str), FileName)
        Return Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1)
    End Function
    Public Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As Long
        WriteINI = WritePrivateProfileString(Section, AppName, lpDefault, FileName)
    End Function
    Public Function MSG2IMG(fullFile As String, Optional offset As Int32 = 0) As Bitmap
        Dim fs As FileStream = New FileStream(fullFile, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        fs.Seek(offset, SeekOrigin.Begin)
        Dim A1 As UInt16 = br.ReadByte
        Dim A2 As UInt16 = br.ReadByte
        Dim A3 As UInt16 = br.ReadByte
        Dim A4 As UInt16 = br.ReadByte
        Dim AA As UInt32 = A1 * 16777216 + A2 * 65536 + A3 * 256 + A4
        Dim B1 As UInt16 = br.ReadByte
        Dim B2 As UInt16 = br.ReadByte
        Dim B3 As UInt16 = br.ReadByte
        Dim B4 As UInt16 = br.ReadByte
        Dim BB As UInt32 = B1 * 16777216 + B2 * 65536 + B3 * 256 + B4
        Dim C1 As UInt16 = br.ReadByte
        Dim C2 As UInt16 = br.ReadByte
        Dim C3 As UInt16 = br.ReadByte
        Dim C4 As UInt16 = br.ReadByte
        Dim CC As UInt32 = C1 * 16777216 + C2 * 65536 + C3 * 256 + C4
        fs.Seek(AA + offset, SeekOrigin.Begin)
        Dim D1 As UInt16 = br.ReadByte
        Dim D2 As UInt16 = br.ReadByte
        Dim D3 As UInt16 = br.ReadByte
        Dim D4 As UInt16 = br.ReadByte
        Dim DD As UInt32 = D1 * 16777216 + D2 * 65536 + D3 * 256 + D4
        Dim num As Int16 = DD / 4
        Dim passage(num - 1) As UInt32
        fs.Seek(AA + offset, SeekOrigin.Begin)
        For i = 0 To num - 1
            Dim I1 As UInt16 = br.ReadByte
            Dim I2 As UInt16 = br.ReadByte
            Dim I3 As UInt16 = br.ReadByte
            Dim I4 As UInt16 = br.ReadByte
            Dim II As UInt32 = I1 * 16777216 + I2 * 65536 + I3 * 256 + I4
            passage(i) = II + AA
        Next
        num = (CC - BB) / 128
        Dim colors(16 - 1) As Color
        For i = 0 To colors.Count - 1
            If i = 0 Then
                colors(i) = Color.FromArgb(0, 0, 0, 0)
            Else
                colors(i) = Color.FromArgb((16 - i) * 16, 0, 0, 0)
            End If
        Next
        Dim fonts(num - 1) As Bitmap
        fs.Seek(BB + offset, SeekOrigin.Begin)
        For i = 0 To num - 1
            fonts(i) = New Bitmap(16, 16)
            For y = 0 To fonts(i).Height - 1
                For x = 0 To (fonts(i).Width / 2) - 1
                    Dim index As Byte = br.ReadByte
                    Dim index2 = index Mod 16
                    Dim index1 = (index - index2) / 16
                    fonts(i).SetPixel(2 * x, y, colors(index1))
                    fonts(i).SetPixel(2 * x + 1, y, colors(index2))
                Next
            Next
        Next
        Dim h As Int16 = (((fonts.Count - 1) - ((fonts.Count - 1) Mod 16)) / 16 + 1) * 16
        Dim tempImage As Bitmap = New Bitmap(256, h)
        For i = 0 To fonts.Count - 1
            Dim n As Int16 = i Mod 16
            Dim l As Int16 = (i - n) / 16
            For y = 0 To fonts(i).Height - 1
                For x = 0 To fonts(i).Width - 1
                    tempImage.SetPixel(n * 16 + x, l * 16 + y, fonts(i).GetPixel(x, y))
                Next
            Next
        Next
        MSG2IMG = tempImage
        br.Close()
        fs.Close()
    End Function

    Public Function MSG2TXT(separate As Boolean, dataPath As String, fullFile As String, Optional offset As Int32 = 0) As String()
        Dim file As String = System.IO.Path.GetFileName(fullFile)
        Dim fs As FileStream = New FileStream(fullFile, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        Dim suffix As String = ""
        If offset > 0 Then
            suffix = "_" + offset.ToString
        End If
        Dim cpFile As String = dataPath + "\CodePage" + "\" + file + suffix + ".txt"
        If file.Contains("ST") And Not IO.File.Exists(cpFile) Then
            cpFile = dataPath + "\CodePage" + "\" + Mid(file, 1, 4) + "0" + Mid(file, 6) + suffix + ".txt"
        End If
        If Not IO.File.Exists(cpFile) Then
            cpFile = dataPath + "\CodePage" + "\" + "NULL" + ".txt"
        End If
        Dim fsc As FileStream = New FileStream(cpFile, FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fsc, System.Text.Encoding.UTF8)
        fs.Seek(offset, SeekOrigin.Begin)
        Dim A1 As UInt16 = br.ReadByte
        Dim A2 As UInt16 = br.ReadByte
        Dim A3 As UInt16 = br.ReadByte
        Dim A4 As UInt16 = br.ReadByte
        Dim AA As UInt32 = A1 * 16777216 + A2 * 65536 + A3 * 256 + A4
        Dim B1 As UInt16 = br.ReadByte
        Dim B2 As UInt16 = br.ReadByte
        Dim B3 As UInt16 = br.ReadByte
        Dim B4 As UInt16 = br.ReadByte
        Dim BB As UInt32 = B1 * 16777216 + B2 * 65536 + B3 * 256 + B4
        Dim C1 As UInt16 = br.ReadByte
        Dim C2 As UInt16 = br.ReadByte
        Dim C3 As UInt16 = br.ReadByte
        Dim C4 As UInt16 = br.ReadByte
        Dim CC As UInt32 = C1 * 16777216 + C2 * 65536 + C3 * 256 + C4
        fs.Seek(AA + offset, SeekOrigin.Begin)
        Dim D1 As UInt16 = br.ReadByte
        Dim D2 As UInt16 = br.ReadByte
        Dim D3 As UInt16 = br.ReadByte
        Dim D4 As UInt16 = br.ReadByte
        Dim DD As UInt32 = D1 * 16777216 + D2 * 65536 + D3 * 256 + D4
        Dim num As Int16 = DD / 4
        Dim passage(num - 1) As UInt32
        fs.Seek(AA + offset, SeekOrigin.Begin)
        For i = 0 To num - 1
            Dim I1 As UInt16 = br.ReadByte
            Dim I2 As UInt16 = br.ReadByte
            Dim I3 As UInt16 = br.ReadByte
            Dim I4 As UInt16 = br.ReadByte
            Dim II As UInt32 = I1 * 16777216 + I2 * 65536 + I3 * 256 + I4
            passage(i) = II + AA + offset
        Next
        num = (CC - BB) / 128
        Dim line As Int16 = ((num - 1) - (num - 1) Mod 16) / 16 + 1
        Dim codeText(line - 1) As String
        For i = 0 To line - 1
            codeText(i) = sr.ReadLine()
        Next
        Dim script As String = ""
        Dim text As String = ""
        Dim textIndex As Int16 = 0
        Dim characters As Boolean = False
        Dim parBegin As Boolean = False
        script += "#" + passage.Count.ToString
        script += vbCrLf
        Do Until fs.Position >= BB + offset
            For i = 0 To passage.Count - 1
                If fs.Position = passage(i) Then
                    script += "{passage}"
                    script += "{" + i.ToString + "}"
                    script += vbCrLf
                    parBegin = True
                End If
            Next
            Dim b = br.ReadByte
            If b > 32 Then
                Dim index As Int16 = b - 33
                Dim n = index Mod 16
                Dim l = (index - n) / 16
                If separate Then
                    If Not characters Then
                        script += "{text}"
                        script += "{" + textIndex.ToString + "}"
                        If parBegin Then
                            text += "{Par}"
                            parBegin = False
                        End If
                    End If
                    characters = True
                    text += codeText(l)(n)
                Else
                    script += codeText(l)(n)
                End If
            Else
                If separate Then
                    If {5, 16, 28, 29, 30, 31}.Contains(b) Then
                        If Not characters Then
                            script += "{text}"
                            script += "{" + textIndex.ToString + "}"
                            If parBegin Then
                                text += "{Par}"
                                parBegin = False
                            End If
                        End If
                        characters = True
                    ElseIf {10}.Contains(b) Then
                    Else
                        If characters Then
                            text += vbCrLf
                            textIndex += 1
                        End If
                        characters = False
                    End If
                End If
                Select Case b
                    Case 0
                        script += "{end}"
                        script += vbCrLf
                    Case 1
                        script += "{/r}"
                    Case 2
                        script += "{/p}"
                    Case 4 '?
                        script += "{u4}"
                    Case 5
                        If separate Then
                            text += "{var" + br.ReadByte.ToString + "}"
                        Else
                            script += "{var}"
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                    Case 6
                        script += "{u6}"
                        Dim temp As Byte = br.ReadByte
                        script += "{" + temp.ToString + "}"
                        If temp > 127 Then
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                        script += vbCrLf
                    Case 10
                        If separate And characters Then
                            text += "{/n}"
                        Else
                            script += "{/n}"
                            script += vbCrLf
                        End If
                    Case 12
                        script += "{/f}"
                        script += vbCrLf
                    Case 13
                        script += "{size}"
                        script += "{" + br.ReadByte.ToString + "}"
                        script += "{" + br.ReadByte.ToString + "}"
                    Case 15
                        script += "{height}"
                        script += "{" + br.ReadByte.ToString + "}"
                    Case 16
                        If separate Then
                            text += " "
                        Else
                            script += " "
                        End If
                    Case 17
                        script += "{face}"
                        Dim temp As Byte = br.ReadByte
                        script += "{pos" + temp.ToString + "}"
                        If temp < 6 Then
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                        Do
                            temp = br.ReadByte
                            If temp = 0 Then
                                script += "{end}"
                            Else
                                script += "{e" + temp.ToString + "}"
                            End If
                        Loop Until temp = 0
                        script += vbCrLf
                    Case 18
                        script += "{voice}"
                        Dim temp As Byte = br.ReadByte
                        script += "{" + temp.ToString + "}"
                        If temp > 127 Then
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                        script += vbCrLf
                    Case 19 '选项列表
                        script += "{select}"
                        Dim temp As Byte = br.ReadByte
                        script += "{" + temp.ToString + "}"
                        If temp = 0 Then
                            script += "{" + br.ReadByte.ToString + "}"
                            script += "{" + br.ReadByte.ToString + "}"
                        Else
                            For s = 0 To temp - 1
                                script += "{" + br.ReadByte.ToString + "}"
                            Next
                        End If
                        script += vbCrLf
                    Case 20
                        script += "{u20}"
                        Dim temp As Byte = br.ReadByte
                        script += "{" + temp.ToString + "}"
                        If temp > 127 Then
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                        temp = br.ReadByte
                        If temp = 0 Then
                            script += "{end}"
                        Else
                            script += "{" + temp.ToString + "}"
                        End If
                        script += vbCrLf
                    Case 21
                        script += "{u21}"
                        Dim temp As Byte = br.ReadByte
                        script += "{" + temp.ToString + "}"
                        If temp > 127 Then
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                        temp = br.ReadByte
                        script += "{" + temp.ToString + "}"
                        If temp > 127 Then
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                        script += vbCrLf
                    Case 22
                        script += "{u22}"
                        Dim temp As Byte = br.ReadByte
                        script += "{" + temp.ToString + "}"
                        If temp > 127 Then
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                        temp = br.ReadByte
                        script += "{" + temp.ToString + "}"
                        If temp > 127 Then
                            script += "{" + br.ReadByte.ToString + "}"
                        End If
                    Case 23
                        script += "{u23}"
                        script += "{" + br.ReadByte.ToString + "}"
                        script += "{" + br.ReadByte.ToString + "}"
                        script += vbCrLf
                    Case 28
                        Dim index As Int16 = br.ReadByte + 223
                        Dim n = index Mod 16
                        Dim l = (index - n) / 16
                        If separate Then
                            text += codeText(l)(n)
                        Else
                            script += codeText(l)(n)
                        End If
                    Case 29
                        Dim index As Int16 = br.ReadByte + 479
                        Dim n = index Mod 16
                        Dim l = (index - n) / 16
                        If separate Then
                            text += codeText(l)(n)
                        Else
                            script += codeText(l)(n)
                        End If
                    Case 30
                        Dim index As Int16 = br.ReadByte + 735
                        Dim n = index Mod 16
                        Dim l = (index - n) / 16
                        If separate Then
                            text += codeText(l)(n)
                        Else
                            script += codeText(l)(n)
                        End If
                    Case 31
                        Dim index As Int16 = br.ReadByte + 991
                        Dim n = index Mod 16
                        Dim l = (index - n) / 16
                        If separate Then
                            text += codeText(l)(n)
                        Else
                            script += codeText(l)(n)
                        End If
                    Case 32 '选项
                        script += "{case}"
                    Case Else
                        script += "{/u" + b.ToString + "}"
                End Select
            End If
        Loop
        MSG2TXT = {script, text}
        br.Close()
        fs.Close()
        sr.Close()
        fsc.Close()
    End Function
    Public Sub TEXT2MSG(fontPath As String, dataPath As String, fullFile As String, FontName As String, FontSize As Int16, OffsetX As Int16, OffsetY As Int16, IsBold As Boolean, IsPixel As Boolean, reSymbol As Boolean, Optional Offset As Int32 = 0, Optional SpecifiedFile As String = "")
        Dim file As String = System.IO.Path.GetFileName(fullFile)
        Dim excludeData As Boolean = False
        Dim excludeStatus As Boolean = False
        Dim textFile As String = file
        Dim scriptFile As String = file
        Dim codePage As String() = {}
        Dim lineText As String() = {}
        Dim iniFile As String = dataPath + "\FaceFix\" + file + ".ini"
        Dim fileMax As UInt32 = 196608
        If textFile.Contains("ST") And Not IO.File.Exists(dataPath + "\Text\" + textFile + ".csv") Then
            textFile = Mid(file, 1, 4) + "0" + Mid(file, 6)
        End If
        If IO.File.Exists(iniFile) Then
            excludeData = True
        End If
        If Offset > 0 Then
            textFile = textFile + "_" + Offset.ToString
            scriptFile = scriptFile + "_" + Offset.ToString
        End If
        If IO.File.Exists(dataPath + "\Text\" + textFile + ".csv") Then
            Dim fsc As FileStream = New FileStream(dataPath + "\Text\" + textFile + ".csv", FileMode.Open, FileAccess.Read)
            Dim brc As New StreamReader(fsc, System.Text.Encoding.UTF8)
            Dim tempText As String = brc.ReadLine()
            Do Until tempText Is Nothing
                ReDim Preserve lineText(lineText.Count)
                Dim tempStr As String() = Split(tempText, ",")
                lineText(lineText.Count - 1) = tempStr(tempStr.Count - 1)
                For i = 0 To lineText(lineText.Count - 1).Length - 1
                    Dim contains As Boolean = False
                    If lineText(lineText.Count - 1)(i) = " " Then
                        contains = True
                    ElseIf lineText(lineText.Count - 1)(i) = "{" Then
                        Dim temp As String
                        Do
                            i += 1
                            temp = lineText(lineText.Count - 1)(i)
                        Loop Until temp = "}"
                        contains = True
                    Else
                        For c = 0 To codePage.Count - 1
                            If lineText(lineText.Count - 1)(i) = codePage(c) Then
                                contains = True
                                Exit For
                            End If
                        Next
                    End If
                    If Not contains And codePage.Count < 1246 Then
                        ReDim Preserve codePage(codePage.Count)
                        codePage(codePage.Count - 1) = lineText(lineText.Count - 1)(i)
                    End If
                Next
                tempText = brc.ReadLine()
            Loop
            brc.Close()
            fsc.Close()
        Else
            If True Then
                Exit Sub
            End If
        End If
        Dim head As UInt32() = {12, 0, 0}
        If Not SpecifiedFile = "" Then
            fullFile = SpecifiedFile
        End If
        Dim fs As FileStream
        If Offset > 0 Then
            fs = New FileStream(fullFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim br As New BinaryReader(fs)
            fs.Seek(Offset + 8, SeekOrigin.Begin)
            Dim M1 As UInt16 = br.ReadByte
            Dim M2 As UInt16 = br.ReadByte
            Dim M3 As UInt16 = br.ReadByte
            Dim M4 As UInt16 = br.ReadByte
            fileMax = M1 * 16777216 + M2 * 65536 + M3 * 256 + M4
        Else
            fs = New FileStream(fullFile, FileMode.Create, FileAccess.Write)
        End If
        Dim bw As New BinaryWriter(fs)
        fs.Seek(head(0) + Offset, SeekOrigin.Begin)
        Dim fss As FileStream = New FileStream(dataPath + "\Script\" + scriptFile + ".txt", FileMode.Open, FileAccess.Read)
        Dim brs As New StreamReader(fss, System.Text.Encoding.UTF8)
        Dim num As Int16 = Convert.ToInt16(Split(brs.ReadLine(), "#")(1))
        Dim passage(num - 1) As UInt32
        Dim excludeTempPos As Byte = 0
        fs.Seek(passage.Count * 4, SeekOrigin.Current)
        Dim charText As String = brs.ReadLine
        Do Until charText Is Nothing
            For n = 0 To charText.Length - 1
                If charText(n) = "{" Then
                    Dim str As String = ""
                    Dim temp As String
                    Do
                        n += 1
                        temp = charText(n)
                        If Not temp = "}" Then
                            str += temp
                        End If
                    Loop Until temp = "}"
                    If excludeStatus Then
                        If Mid(str, 1, 3) = "pos" Then
                            excludeTempPos = Convert.ToByte(Split(str, "pos")(1))
                        ElseIf Mid(str, 1, 1) = "e" And Not str = "end" Then
                        Else
                            Select Case str
                                Case "end"
                                    excludeStatus = False
                                Case Else
                                    Dim tempIndex As Byte = Convert.ToByte(str)
                                    Dim faceConfigValue As String = GetINI("Pointer", "Face" + tempIndex.ToString(), "", iniFile)
                                    If Not String.IsNullOrEmpty(faceConfigValue) Then
                                        Dim parsedValue As Byte
                                        If Byte.TryParse(faceConfigValue, parsedValue) Then
                                            tempIndex = parsedValue
                                        Else
                                            Exit Select
                                        End If
                                    End If
                                    bw.Write({17})
                                    bw.Write({excludeTempPos})
                                    bw.Write({tempIndex})
                                    excludeStatus = False
                            End Select
                        End If
                    Else
                        If Mid(str, 1, 3) = "pos" Then
                            bw.Write({Convert.ToByte(Split(str, "pos")(1))})
                        ElseIf Mid(str, 1, 1) = "e" And Not str = "end" Then
                            bw.Write({Convert.ToByte(Split(str, "e")(1))})
                        ElseIf Mid(str, 1, 2) = "/u" Then
                            bw.Write({Convert.ToByte(Split(str, "/u")(1))})
                        ElseIf Mid(str, 1, 1) = "u" Then
                            bw.Write({Convert.ToByte(Split(str, "u")(1))})
                        Else
                            Select Case str
                                Case "passage"
                                    Dim index As String = ""
                                    n += 1
                                    temp = charText(n)
                                    If temp = "{" Then
                                        Do
                                            n += 1
                                            temp = charText(n)
                                            If Not temp = "}" Then
                                                index += temp
                                            End If
                                        Loop Until temp = "}"
                                    Else
                                        MsgBox(file + "_" + fss.Position.ToString) '报错
                                    End If
                                    passage(Convert.ToInt16(index)) = fs.Position - Offset - head(0)
                                Case "text"
                                    Dim indexText As String = ""
                                    n += 1
                                    temp = charText(n)
                                    If temp = "{" Then
                                        Do
                                            n += 1
                                            temp = charText(n)
                                            If Not temp = "}" Then
                                                indexText += temp
                                            End If
                                        Loop Until temp = "}"
                                    Else
                                        MsgBox(file + "_" + fss.Position.ToString) '报错
                                    End If
                                    Dim index As UInt16 = Convert.ToUInt16(indexText)
                                    For i = 0 To lineText(index).Count - 1
                                        If lineText(index)(i) = "{" Then
                                            Dim flag As String = ""
                                            Do
                                                i += 1
                                                temp = lineText(index)(i)
                                                If Not temp = "}" Then
                                                    flag += temp
                                                End If
                                            Loop Until temp = "}"
                                            If flag = "/n" Then
                                                bw.Write({10})
                                            ElseIf Mid(flag, 1, 3) = "var" Then
                                                bw.Write({5})
                                                bw.Write({Convert.ToByte(Split(flag, "var")(1))})
                                            Else
                                            End If
                                        ElseIf lineText(index)(i) = " " Then
                                            bw.Write({16})
                                        Else
                                            For c = 0 To codePage.Count - 1
                                                If codePage(c) = lineText(index)(i) Then
                                                    If c > 990 Then
                                                        bw.Write({31})
                                                        bw.Write({Convert.ToByte(c - 991)})
                                                    ElseIf c > 734 Then
                                                        bw.Write({30})
                                                        bw.Write({Convert.ToByte(c - 735)})
                                                    ElseIf c > 478 Then
                                                        bw.Write({29})
                                                        bw.Write({Convert.ToByte(c - 479)})
                                                    ElseIf c > 222 Then
                                                        bw.Write({28})
                                                        bw.Write({Convert.ToByte(c - 223)})
                                                    Else
                                                        bw.Write({Convert.ToByte(c + 33)})
                                                    End If
                                                    Exit For
                                                End If
                                            Next
                                        End If
                                    Next
                                Case "end"
                                    bw.Write({0})
                                Case "/r"
                                    bw.Write({1})
                                Case "/p"
                                    bw.Write({2})
                                Case "var"
                                    bw.Write({5})
                                Case "/n"
                                    bw.Write({10})
                                Case "/f"
                                    bw.Write({12})
                                Case "size"
                                    bw.Write({13})
                                Case "height"
                                    bw.Write({15})
                                Case "face"
                                    If excludeData Then
                                        excludeTempPos = 0
                                        excludeStatus = True
                                    Else
                                        bw.Write({17})
                                    End If
                                Case "voice"
                                    bw.Write({18})
                                Case "select"
                                    bw.Write({19})
                                Case "case"
                                    bw.Write({32})
                                Case Else
                                    bw.Write({Convert.ToByte(str)})
                            End Select
                        End If
                    End If
                ElseIf charText(n) = " " Then
                    bw.Write({16})
                ElseIf Convert.ToByte(charText(n)) > 32 Then
                    For c = 0 To codePage.Count - 1
                        If codePage(c) = charText(n) Then
                            If c > 990 Then
                                bw.Write({31})
                                bw.Write({Convert.ToByte(c - 991)})
                            ElseIf c > 734 Then
                                bw.Write({30})
                                bw.Write({Convert.ToByte(c - 735)})
                            ElseIf c > 478 Then
                                bw.Write({29})
                                bw.Write({Convert.ToByte(c - 479)})
                            ElseIf c > 222 Then
                                bw.Write({28})
                                bw.Write({Convert.ToByte(c - 223)})
                            Else
                                bw.Write({Convert.ToByte(c + 33)})
                            End If
                            Exit For
                        End If
                    Next
                Else
                End If
            Next
            charText = brs.ReadLine
        Loop
        brs.Close()
        fss.Close()
        Dim posMod As Int16 = (fs.Position - Offset - head(0)) Mod 16
        If posMod > 0 Then
            For i = 0 To 15 - posMod
                bw.Write({0})
            Next
        End If
        head(1) = fs.Position - Offset
        For i = 0 To codePage.Count - 1
            Dim fontImage As Bitmap
            Dim imageFile As String = fontPath + "\" + Char.ConvertToUtf32(codePage(i), 0).ToString + ".png"
            If reSymbol And IO.File.Exists(imageFile) Then
                fontImage = New Bitmap(imageFile)
            Else
                fontImage = CreateFontBitmap(codePage(i), FontName, FontSize, 16, 16, OffsetX, OffsetY, IsBold, IsPixel)
            End If
            For y = 0 To fontImage.Height - 1
                Dim BitmapPx(fontImage.Width) As Byte
                For x = 0 To fontImage.Width - 1
                    Dim c = fontImage.GetPixel(x, y).A \ 16
                    If c > 0 Then
                        c = 16 - c
                    End If
                    BitmapPx(x) = c
                Next
                For x = 0 To fontImage.Width / 2 - 1
                    Dim BitmapByte As Byte = BitmapPx(x * 2) * 16 + BitmapPx(x * 2 + 1)
                    bw.Write(BitmapByte)
                Next
            Next
        Next
        If Offset > 0 Then
            Do Until fs.Position >= Offset + fileMax
                bw.Write({0})
            Loop
        End If
        head(2) = fs.Position - Offset
        If IO.File.Exists(dataPath + "\Data\" + file + ".dat") Then
            Dim fsd As FileStream = New FileStream(dataPath + "\Data\" + file + ".dat", FileMode.Open, FileAccess.Read)
            Dim brd As New BinaryReader(fsd)
            Do Until fsd.Position >= fsd.Length Or fs.Position >= Offset + fileMax
                bw.Write({brd.ReadByte})
            Loop
            brd.Close()
            fsd.Close()
        End If
        If Not excludeData And Offset = 0 And fs.Position >= fileMax Then
            MsgBox(file)
        End If
        fs.Seek(Offset, SeekOrigin.Begin)
        For i = 0 To head.Count - 1
            Dim t1c = head(i) Mod 16777216
            Dim t0 As Byte = (head(i) - t1c) / 16777216
            Dim t2c = t1c Mod 65536
            Dim t1 As Byte = (t1c - t2c) / 65536
            Dim t3 As Byte = t2c Mod 256
            Dim t2 As Byte = (t2c - t3) / 256
            bw.Write(t0)
            bw.Write(t1)
            bw.Write(t2)
            bw.Write(t3)
        Next
        For i = 0 To passage.Count - 1
            Dim t1c = passage(i) Mod 16777216
            Dim t0 As Byte = (passage(i) - t1c) / 16777216
            Dim t2c = t1c Mod 65536
            Dim t1 As Byte = (t1c - t2c) / 65536
            Dim t3 As Byte = t2c Mod 256
            Dim t2 As Byte = (t2c - t3) / 256
            bw.Write(t0)
            bw.Write(t1)
            bw.Write(t2)
            bw.Write(t3)
        Next
        bw.Close()
        fs.Close()
    End Sub

    Public Sub MSG2UTF(dataPath As String, fullFile As String, Optional offset As Int32 = 0)
        Dim file As String = System.IO.Path.GetFileName(fullFile)
        Dim suffix As String = ""
        If offset > 0 Then
            suffix = "_" + offset.ToString
        End If
        Dim cpFile As String = dataPath + "\CodePage" + "\" + file + suffix + ".txt"
        If file.Contains("ST") And Not IO.File.Exists(cpFile) Then
            cpFile = dataPath + "\CodePage" + "\" + Mid(file, 1, 4) + "0" + Mid(file, 6) + suffix + ".txt"
        End If
        If Not IO.File.Exists(cpFile) Then
            cpFile = dataPath + "\CodePage" + "\" + "NULL" + ".txt"
        End If
        Dim fss As FileStream = New FileStream(cpFile, FileMode.Open, FileAccess.Read)
        Dim brs As New StreamReader(fss, System.Text.Encoding.UTF8)

        Dim fs As FileStream = New FileStream(fullFile, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        fs.Seek(offset, SeekOrigin.Begin)
        Dim A1 As UInt16 = br.ReadByte
        Dim A2 As UInt16 = br.ReadByte
        Dim A3 As UInt16 = br.ReadByte
        Dim A4 As UInt16 = br.ReadByte
        Dim AA As UInt32 = A1 * 16777216 + A2 * 65536 + A3 * 256 + A4
        Dim B1 As UInt16 = br.ReadByte
        Dim B2 As UInt16 = br.ReadByte
        Dim B3 As UInt16 = br.ReadByte
        Dim B4 As UInt16 = br.ReadByte
        Dim BB As UInt32 = B1 * 16777216 + B2 * 65536 + B3 * 256 + B4
        Dim C1 As UInt16 = br.ReadByte
        Dim C2 As UInt16 = br.ReadByte
        Dim C3 As UInt16 = br.ReadByte
        Dim C4 As UInt16 = br.ReadByte
        Dim CC As UInt32 = C1 * 16777216 + C2 * 65536 + C3 * 256 + C4
        Dim num As Int16 = (CC - BB) / 128
        Dim line As Int16 = ((num - 1) - (num - 1) Mod 16) / 16 + 1
        Dim codeText(line - 1) As String
        For i = 0 To line - 1
            codeText(i) = brs.ReadLine()
        Next
        brs.Close()
        fss.Close()
        Dim colors(16 - 1) As Color
        For i = 0 To colors.Count - 1
            If i = 0 Then
                colors(i) = Color.FromArgb(0, 0, 0, 0)
            Else
                colors(i) = Color.FromArgb((16 - i) * 16, 0, 0, 0)
            End If
        Next
        Dim fonts(num - 1) As Bitmap
        fs.Seek(BB + offset, SeekOrigin.Begin)
        For i = 0 To num - 1
            fonts(i) = New Bitmap(16, 16)
            For y = 0 To fonts(i).Height - 1
                For x = 0 To (fonts(i).Width / 2) - 1
                    Dim index As Byte = br.ReadByte
                    Dim index2 = index Mod 16
                    Dim index1 = (index - index2) / 16
                    fonts(i).SetPixel(2 * x, y, colors(index1))
                    fonts(i).SetPixel(2 * x + 1, y, colors(index2))
                Next
            Next
        Next
        My.Computer.FileSystem.CreateDirectory(dataPath + "\Font\")
        My.Computer.FileSystem.CreateDirectory(dataPath + "\Font\General")
        For i = 0 To fonts.Count - 1
            Dim n = i Mod 16
            Dim l = (i - n) / 16
            If IO.File.Exists(dataPath + "\Font\General\" + Char.ConvertToUtf32(codeText(l)(n), 0).ToString + ".png") Then
                Dim tempImage As Bitmap = New Bitmap(dataPath + "\Font\General\" + Char.ConvertToUtf32(codeText(l)(n), 0).ToString + ".png")
                Dim difference As Boolean = False
                For x = 0 To fonts(i).Width - 1
                    For y = 0 To fonts(i).Height - 1
                        If Not fonts(i).GetPixel(x, y).A = tempImage.GetPixel(x, y).A Then
                            difference = True
                            Exit For
                        End If
                    Next
                    If difference Then
                        Exit For
                    End If
                Next
                If difference Then
                    My.Computer.FileSystem.CreateDirectory(dataPath + "\Font\" + file + suffix)
                    fonts(i).Save（dataPath + "\Font\" + file + suffix + "\" + (l + 1).ToString + "×" + (n + 1).ToString + "_" + Char.ConvertToUtf32(codeText(l)(n), 0).ToString + ".png"）
                End If
            Else
                fonts(i).Save（dataPath + "\Font\General\" + Char.ConvertToUtf32(codeText(l)(n), 0).ToString + ".png"）
            End If
            fonts(i).Dispose()
        Next
        br.Close()
        fs.Close()
    End Sub

    Public Sub MSG2DAT(dataPath As String, fullFile As String)
        Dim file As String = System.IO.Path.GetFileName(fullFile)
        Dim fs As FileStream = New FileStream(fullFile, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        fs.Seek(8, SeekOrigin.Begin)
        Dim C1 As UInt16 = br.ReadByte
        Dim C2 As UInt16 = br.ReadByte
        Dim C3 As UInt16 = br.ReadByte
        Dim C4 As UInt16 = br.ReadByte
        Dim CC As UInt32 = C1 * 16777216 + C2 * 65536 + C3 * 256 + C4
        fs.Seek(CC, SeekOrigin.Begin)
        If fs.Position < fs.Length Then
            Dim fsd As FileStream = New FileStream(dataPath + "\Data\" + file + ".dat", FileMode.Create, FileAccess.Write)
            Dim bwd As New BinaryWriter(fsd)
            Do
                bwd.Write({br.ReadByte})
            Loop Until fs.Position >= fs.Length
            bwd.Close()
            fsd.Close()
        End If
        br.Close()
        fs.Close()
    End Sub
    Public Function CreateFontBitmap(Text As String, FontName As String, FontSize As Int16, Width As Int16, Height As Int16, OffsetX As Int16, OffsetY As Int16, IsBold As Boolean, IsPixel As Boolean) As Bitmap
        CreateFontBitmap = Nothing
        Dim font As Font
        If IsBold Then
            font = New Font(FontName, FontSize, FontStyle.Bold, GraphicsUnit.Pixel)
        Else
            font = New Font(FontName, FontSize, FontStyle.Regular, GraphicsUnit.Pixel)
        End If
        Dim brush As SolidBrush
        brush = New SolidBrush(Color.Black)
        CreateFontBitmap = New Bitmap(Width, Height)
        Dim g As Graphics
        g = Graphics.FromImage(CreateFontBitmap)
        Dim rect As RectangleF
        rect = New RectangleF(OffsetX, OffsetY, Width + 4, Height + 4)
        If IsPixel Then
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixel
        Else
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        End If
        g.DrawString(Text, font, brush, rect)
        g.Dispose()
    End Function
    Public Function CountOccurrences(source As String, find As String) As Integer
        Dim count As Integer = 0
        Dim index As Integer = 0
        While index < source.Length
            index = source.IndexOf(find, index, StringComparison.Ordinal)
            If index = -1 Then Exit While
            count += 1
            index += find.Length
        End While
        Return count
    End Function
    Private Function CompressData(src As Byte()) As Byte()
        If src.Length Mod 2 <> 0 Then
            Array.Resize(src, src.Length + 1)
            src(src.Length - 1) = 0
        End If
        Dim srcWords As New List(Of UShort)()
        For i As Integer = 0 To src.Length - 1 Step 2
            srcWords.Add(CUShort(src(i)) << 8 Or src(i + 1))
        Next
        Dim dst As New List(Of Byte)()
        Dim pos As Integer = 0
        While pos < srcWords.Count
            Dim chunkOps As New List(Of (IsLiteral As Boolean, Value As UShort))()
            Dim tempPos As Integer = pos
            For opIdx As Integer = 0 To 15
                If tempPos >= srcWords.Count Then Exit For
                Dim bestLen As Integer = 0
                Dim bestDisp As Integer = 0
                Dim startSearch As Integer = Math.Max(0, tempPos - 1024)
                Dim currentWord As UShort = srcWords(tempPos)
                Dim maxMatchLen As Integer = Math.Min(64, srcWords.Count - tempPos)
                Dim foundMatch As Boolean = False
                If maxMatchLen >= 1 Then
                    For i As Integer = tempPos - 1 To startSearch Step -1
                        If srcWords(i) = currentWord Then
                            Dim matchLen As Integer = 1
                            While matchLen < maxMatchLen AndAlso srcWords(i + matchLen) = srcWords(tempPos + matchLen)
                                matchLen += 1
                            End While

                            If matchLen > bestLen Then
                                bestLen = matchLen
                                bestDisp = (i - tempPos) * 2
                                If bestLen = 64 Then Exit For
                            End If
                        End If
                    Next
                    If bestLen >= 1 Then
                        Dim dispVal As Integer = bestDisp + &H800
                        Dim lenVal As Integer = bestLen - 1
                        Dim val As UShort = CUShort(((dispVal And &H7FE) << 5) Or (lenVal And &H3F))
                        If val <> 0 Then
                            chunkOps.Add((False, val))
                            tempPos += bestLen
                            foundMatch = True
                        End If
                    End If
                End If
                If Not foundMatch Then
                    chunkOps.Add((True, srcWords(tempPos)))
                    tempPos += 1
                End If
            Next
            Dim flags As UShort = 0
            For i As Integer = 0 To chunkOps.Count - 1
                If chunkOps(i).IsLiteral Then
                    flags = CUShort(flags Or (1 << (15 - i)))
                End If
            Next
            dst.Add(CByte(flags >> 8))
            dst.Add(CByte(flags And &HFF))
            For Each op In chunkOps
                dst.Add(CByte(op.Value >> 8))
                dst.Add(CByte(op.Value And &HFF))
            Next
            pos = tempPos
        End While
        dst.Add(0) ' Flags = 0
        dst.Add(0)
        dst.Add(0) ' Ref = 0 (结束标志)
        dst.Add(0)
        Return dst.ToArray()
    End Function
    Private Function DecompressData(src As Byte()) As Byte()
        If src Is Nothing OrElse src.Length = 0 Then Return New Byte() {}
        Dim srcPos As Integer = 0
        Dim dst As New List(Of Byte)()
        Dim cmpFlgCtr As Integer = 16
        Dim cmpFlg As UShort = 0
        While srcPos < src.Length
            If cmpFlgCtr = 16 Then
                If srcPos + 2 > src.Length Then Exit While
                cmpFlg = CUShort(src(srcPos)) << 8 Or src(srcPos + 1)
                srcPos += 2
                cmpFlgCtr = 0
            End If
            cmpFlgCtr += 1
            Dim isLiteral As Boolean = (cmpFlg And &H8000) <> 0
            cmpFlg = CUShort((cmpFlg << 1) And &HFFFF)
            If srcPos + 2 > src.Length Then Exit While
            Dim val As UShort = CUShort(src(srcPos)) << 8 Or src(srcPos + 1)
            srcPos += 2
            If isLiteral Then
                dst.Add(CByte(val >> 8))
                dst.Add(CByte(val And &HFF))
            Else
                If val = 0 Then Exit While
                Dim dispEncoded As Integer = (val >> 5) And &H7FE
                Dim disp As Integer = dispEncoded - &H800
                Dim copySrcPos As Integer = dst.Count + disp
                Dim count As Integer = (val And &H3F) + 1
                For i As Integer = 1 To count
                    Dim word As UShort = 0
                    If copySrcPos >= 0 AndAlso copySrcPos + 2 <= dst.Count Then
                        word = CUShort(dst(copySrcPos)) << 8 Or dst(copySrcPos + 1)
                    End If
                    dst.Add(CByte(word >> 8))
                    dst.Add(CByte(word And &HFF))
                    copySrcPos += 2
                Next
            End If
        End While
        Return dst.ToArray()
    End Function

    Public Sub UnpackBinFile(filePath As String, outputDir As String)
        If Not File.Exists(filePath) Then
            Return
        End If
        If Not Directory.Exists(outputDir) Then
            Directory.CreateDirectory(outputDir)
        End If
        Dim fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs, Encoding.ASCII)
        Dim num As UInteger = IPAddress.NetworkToHostOrder(br.ReadInt32())
        Dim sizes As New List(Of UInteger)()
        For i As Integer = 0 To num - 1
            sizes.Add(IPAddress.NetworkToHostOrder(br.ReadInt32()))
        Next
        fs.Seek(num * 4 + 4, SeekOrigin.Begin)
        For i As Integer = 0 To num - 1
            Dim size As Integer = CInt(sizes(i))
            Dim compressedData As Byte() = br.ReadBytes(size)
            If compressedData.Length <> size Then
                Continue For
            End If
            Dim decompressedData As Byte() = DecompressData(compressedData)
            Dim outName As String = Path.Combine(outputDir, $"head_{i:00}.dat")
            Dim colorNum As Integer = decompressedData(2) * 256 + decompressedData(3)
            Dim width As Integer = decompressedData(4) * 256 + decompressedData(5)
            Dim height As Integer = decompressedData(6) * 256 + decompressedData(7)
            Dim begin As Integer = decompressedData(8) * 16777216 + decompressedData(9) * 65535 + decompressedData(10) * 256 + decompressedData(11)
            Dim data(begin - 1) As Byte
            Array.Copy(decompressedData, data, begin)
            File.WriteAllBytes(outName, data)
            Dim colors As Color() = PAL2COL(decompressedData, 16, colorNum)
            Dim tempBitmap = New Bitmap(width, height)
            For y = 0 To height - 1
                For x = 0 To width - 1
                    Dim a As Byte = decompressedData(begin + width * y + x)
                    tempBitmap.SetPixel(x, y, colors(a))
                Next
            Next
            tempBitmap.Save(Path.Combine(outputDir, $"image_{i:00}.png"))
        Next
        br.Close()
        fs.Close()
    End Sub
    Public Function PAL2COL(data As Byte(), Optional begin As Int32 = 0, Optional num As Int16 = 256) As Color()
        Dim tempColor(num - 1) As Color
        For i = 0 To num - 1
            Dim str1 As String = Convert.ToString(data(begin + i * 2), 2)
            Do Until str1.Length >= 8
                str1 = "0" + str1
            Loop
            Dim str2 As String = Convert.ToString(data(begin + i * 2 + 1), 2)
            Do Until str2.Length >= 8
                str2 = "0" + str2
            Loop
            Dim str = str1 + str2
            Dim B5 As String = Mid(str, 2, 5)
            Dim G5 As String = Mid(str, 7, 5)
            Dim R5 As String = Mid(str, 12, 5)
            tempColor(i) = Color.FromArgb(Convert.ToInt32(R5 + "000", 2), Convert.ToInt32(G5 + "000", 2), Convert.ToInt32(B5 + "000", 2))
        Next
        PAL2COL = tempColor
    End Function
    Public Sub PackToBinFile(inputDir As String, outputFilename As String)
        Dim files As String() = Directory.GetFiles(inputDir, "head_*.dat")
        Array.Sort(files)
        If files.Length = 0 Then
            Return
        End If
        Dim chunks As New List(Of Byte())()
        For Each fname In files
            Dim blob As Byte() = File.ReadAllBytes(fname)
            Dim colorNum As Integer = blob(2) * 256 + blob(3)
            Dim width As Integer = blob(4) * 256 + blob(5)
            Dim height As Integer = blob(6) * 256 + blob(7)
            Dim begin As Integer = blob.Count
            Dim colors As Color() = PAL2COL(blob, 16, colorNum)
            Dim imageFile As String = Path.Combine(inputDir, "image_" + Path.GetFileNameWithoutExtension(fname).Substring(5) + ".png")
            Dim image As Bitmap = New Bitmap(imageFile)
            image = ConvertImageToPalette(image, colors)
            ReDim Preserve blob(blob.Length + width * height - 1)
            For y = 0 To height - 1
                For x = 0 To width - 1
                    Dim color = image.GetPixel(x, y)
                    For c = 0 To colors.Count - 1
                        If color.ToArgb = colors(c).ToArgb Then
                            blob(begin + y * width + x) = c
                        End If
                    Next
                Next
            Next
            chunks.Add(CompressData(blob))
        Next
        Dim fs As New FileStream(outputFilename, FileMode.Create, FileAccess.Write)
        Dim bw As New BinaryWriter(fs, Encoding.ASCII)
        Dim numImages As UInteger = CUInt(chunks.Count)
        bw.Write(IPAddress.HostToNetworkOrder(CInt(numImages)))
        For Each chunk In chunks
            bw.Write(IPAddress.HostToNetworkOrder(chunk.Length))
        Next
        For Each chunk In chunks
            bw.Write(chunk)
        Next
        bw.Close()
        fs.Close()
    End Sub
    Public Function RGB24ToByte(Color As Color) As Byte()
        Dim R As String = Convert.ToString(Color.R, 2)
        Dim G As String = Convert.ToString(Color.G, 2)
        Dim B As String = Convert.ToString(Color.B, 2)
        Do Until R.Length >= 8
            R = "0" + R
        Loop
        Do Until G.Length >= 8
            G = "0" + G
        Loop
        Do Until B.Length >= 8
            B = "0" + B
        Loop
        Dim A1 As String = "0"
        If Color.A > 0 Then
            A1 = "1"
        End If
        Dim R5 As String = Mid(R, 1, 5)
        Dim G5 As String = Mid(G, 1, 5)
        Dim B5 As String = Mid(B, 1, 5)
        Dim d = Convert.ToUInt16(A1 + B5 + G5 + R5, 2)
        Dim d2 = d Mod 256
        Dim d1 = (d - d Mod 256) / 256
        RGB24ToByte = {d2, d1}
    End Function
    Public Function ConvertImageToPalette(image As Image, palette As Color()) As Image
        Dim bmp As New Bitmap(image)
        Dim width As Integer = bmp.Width
        Dim height As Integer = bmp.Height
        Dim rect As New Rectangle(0, 0, width, height)
        Dim bmpData As BitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
        Dim bytesPerPixel As Integer = 4
        Dim stride As Integer = bmpData.Stride
        Dim scan0 As IntPtr = bmpData.Scan0
        Dim pixels As Byte() = New Byte(stride * height - 1) {}
        System.Runtime.InteropServices.Marshal.Copy(scan0, pixels, 0, pixels.Length)
        Dim paletteR As Integer() = New Integer(palette.Length - 1) {}
        Dim paletteG As Integer() = New Integer(palette.Length - 1) {}
        Dim paletteB As Integer() = New Integer(palette.Length - 1) {}
        For i As Integer = 0 To palette.Length - 1
            paletteR(i) = palette(i).R
            paletteG(i) = palette(i).G
            paletteB(i) = palette(i).B
        Next
        For y As Integer = 0 To height - 1
            For x As Integer = 0 To width - 1
                Dim index As Integer = y * stride + x * bytesPerPixel
                Dim b As Integer = pixels(index)
                Dim g As Integer = pixels(index + 1)
                Dim r As Integer = pixels(index + 2)
                Dim a As Integer = pixels(index + 3)
                Dim minDistance As Long = Long.MaxValue
                Dim bestColor As Color = palette(0)
                For i As Integer = 0 To palette.Length - 1
                    Dim dr As Integer = r - paletteR(i)
                    Dim dg As Integer = g - paletteG(i)
                    Dim db As Integer = b - paletteB(i)
                    Dim distance As Long = dr * dr + dg * dg + db * db
                    If distance < minDistance Then
                        minDistance = distance
                        bestColor = palette(i)
                    End If
                Next
                pixels(index) = bestColor.B
                pixels(index + 1) = bestColor.G
                pixels(index + 2) = bestColor.R
                pixels(index + 3) = a
            Next
        Next
        System.Runtime.InteropServices.Marshal.Copy(pixels, 0, scan0, pixels.Length)
        bmp.UnlockBits(bmpData)
        Return CType(bmp.Clone(), Image)
    End Function
End Module
