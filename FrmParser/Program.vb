Imports System
Imports System.Text
Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())
Start:
        Text.Encoding.RegisterProvider(Text.CodePagesEncodingProvider.Instance)
        Console.WriteLine()
        Console.WriteLine("Select function:")
        Console.WriteLine("1. Cut VB6 .FRM file.")
        Console.WriteLine("2. Convert to .HTM file.")
        Dim Func1 = Console.ReadLine()
        If Func1 = "" Then End
        If Not IsNumeric(Func1) Then GoTo Start
        Select Case Func1
            Case 1
                Console.Write("Get .FRM Location" & vbCrLf & ">")
                Dim Loc1 = Console.ReadLine()
                Console.Write("Get output .TXT Location" & vbCrLf & ">")
                Dim Loc2 = Console.ReadLine()
                Console.Write("Get Start line number" & vbCrLf & ">")
                Dim Line1 = CInt(Console.ReadLine())
                Console.Write("Get End line number" & vbCrLf & ">")
                Dim Line2 = CInt(Console.ReadLine())
                Dim Str1 As String = IO.File.ReadAllText(Loc1, Text.Encoding.GetEncoding("windows-1250"))
                Dim Str2 As String = String.Join(vbCrLf, LineReader(Str1, Line1, Line2))
                IO.File.WriteAllText(Loc2, Str2, Text.Encoding.GetEncoding("windows-1250"))
            Case 2
                'Console.Write("Get input .TXT Location" & vbCrLf & ">")
                'Dim Loc3 = Console.ReadLine()
                'Console.Write("Get output .HTM Location" & vbCrLf & ">")
                'Dim Loc4 = Console.ReadLine()
                Dim Loc3 = "j:\ftp\Frame1.txt"
                Dim Loc4 = "j:\ftp\Frame1.htm"
                Dim Str3 As String = IO.File.ReadAllText(Loc3, Text.Encoding.GetEncoding("windows-1250"))
                Dim WhiteSpaceReg As Regex = New Regex("\s+")
                Dim Str4 = WhiteSpaceReg.Replace(Str3.Replace(vbCrLf, " "), " ")
                Dim InW As List(Of String) = Str4.Split(" ").ToList
                Dim DivId As New List(Of String)
                Dim Out As New StringBuilder
                Dim DivOpen As Integer = 0
                For i As Integer = 0 To InW.Count - 1
                    If InW(i) = "Begin" Then
                        DivOpen += 1
                        Select Case InW(i + 1)
                            Case "VB.Form", "VB.Timer"
                                Continue For
                            Case "VB.Label", "VB.CheckBox", "VB.CommandButton", "VB.Frame"
                                Out.Append("<div ")
                                Out.Append($"type='{InW(i + 1).Replace("VB.", "")}' ")
                                AddId(InW, i, Out, InW(i + 2), DivId)
                                AddTitle(InW, i, Out, "Caption")
                                AddAttr(InW, i, Out, "Tag")
                                AddAttr(InW, i, Out, "Top")
                                AddAttr(InW, i, Out, "Left")
                            Case "VB.TextBox"
                                Out.Append("<div ")
                                Out.Append($"type='{InW(i + 1).Replace("VB.", "")}' ")
                                AddId(InW, i, Out, InW(i + 2), DivId)
                                AddTitle(InW, i, Out, "Tag")
                                AddAttr(InW, i, Out, "Top")
                                AddAttr(InW, i, Out, "Left")
                            Case "MSDataListLib.DataCombo"
                                Out.Append("<div ")
                                Out.Append($"type='{InW(i + 1).Replace("VB.", "")}' ")
                                AddId(InW, i, Out, InW(i + 2), DivId)
                                AddTitle(InW, i, Out, "Text")
                                AddAttr(InW, i, Out, "Top")
                                AddAttr(InW, i, Out, "Left")
                            Case "MSComCtl2.DTPicker"
                                Out.Append("<div ")
                                Out.Append($"type='{InW(i + 1).Replace("VB.", "")}' ")
                                AddId(InW, i, Out, InW(i + 2), DivId)
                                AddAttr(InW, i, Out, "Top")
                                AddAttr(InW, i, Out, "Left")
                        End Select
                        If DivOpen Mod 2 = 1 Then
                            Out.Append(" >" & vbCrLf)
                        Else
                            Out.Append(" />" & vbCrLf)
                        End If
                    ElseIf InW(i) = "End" Then
                        'If i = 723 Then
                        '    Debug.Print("!")
                        'End If
                        'For l As Integer = i To Math.Min(InW.Count - 1, i + 10)
                        '    Debug.Print(String.Join(" ", InW(l)).Replace(vbCrLf, ""))
                        'Next
                        If DivOpen Mod 2 = 1 Then
                            Out.Append("</div> " & vbCrLf)
                        End If
                        DivOpen -= 1
                    End If
                    'Debug.Print($"{i},{DivOpen}:{Out.ToString}")
                Next
                IO.File.WriteAllText(Loc4, Out.ToString, Text.Encoding.GetEncoding("windows-1250"))
        End Select
        GoTo Start
    End Sub

    Sub AddId(InW As List(Of String), I As Integer, ByRef Out As StringBuilder, NewName As String, DivId As List(Of String))
        Dim ExistingName = DivId.Where(Function(X) X.StartsWith(NewName)).ToList
        If ExistingName.Count = 0 Then
            DivId.Add(NewName)
        Else
            NewName &= ExistingName.Count.ToString("D2")
            DivId.Add(NewName)
        End If
        Out.Append($"name='{NewName}' ")
        Out.Append($"id='{NewName}' ")
    End Sub

    Sub AddAttr(InW As List(Of String), I As Integer, ByRef Out As StringBuilder, TagName As String)
        For j As Integer = I + 1 To Math.Min(InW.Count - 1, I + 70)
            Debug.Print(InW(j))
            If InW(j) = TagName Then
                Out.Append($" {TagName}='{InW(j + 2)}'")
                Exit For
            End If
        Next
    End Sub

    Sub AddTitle(InW As List(Of String), I As Integer, ByRef Out As StringBuilder, TagName As String)
        For j As Integer = I + 1 To Math.Min(InW.Count - 1, I + 50)
            If InW(j) = TagName Then
                Out.Append($"title={InW(j + 2)} ")
                Dim QuotesCount As Integer = InW(j + 2).ToCharArray.Count(Function(X) X = """")
                If QuotesCount Mod 2 = 1 Then
                    For k As Integer = j + 2 + 1 To InW.Count - 1
                        Out.Append($" {InW(k)}")
                        If InW(k).Contains("""") Then
                            Exit For
                        End If
                    Next
                End If
                Exit For
            End If
        Next
    End Sub

    Function LineReader(Str1 As String, Line1 As Integer, Line2 As Integer) As List(Of String)
        Dim Out1 As New System.IO.StringReader(Str1)
        Dim Line As New List(Of String)
        Dim Count As Integer = 0
        While Out1.Peek > -1
            If Count > Line1 And Count <= Line2 Then
                Line.Add(Out1.ReadLine)
            ElseIf Count > Line2 Then
                Exit While
            Else
                Out1.ReadLine()
            End If
            Count += 1
        End While
        Return Line
    End Function
End Module
