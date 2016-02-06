Imports System.IO
Module Module1

    Sub Main()
        Try
            Dim CurrentFolder As String = Path.GetDirectoryName(Process.GetCurrentProcess.MainModule.FileName)
            Dim AllTheFiles As String() = IO.Directory.GetFiles(CurrentFolder, "*.tga")
            If AllTheFiles.Length = 0 Then
                Throw New System.Exception("There are no tga files in this folder")
            End If
            If File.Exists("output.txt") Then
                File.Delete("output.txt")
                File.Create("output.txt").Close()
            Else
                File.Create("output.txt").Close()
            End If

            'This Is AllTheFiles "defaultpack" writer
            For Each SingleFile As String In AllTheFiles
                Using w As StreamWriter = File.AppendText("output.txt")
                    w.WriteLine("[""" & Path.GetFileName(SingleFile).ToString & """]=""Interface\\AddOns\\twemo\\" & Path.GetFileName(SingleFile).ToString & ":28:28"",")
                    If Array.IndexOf(AllTheFiles, SingleFile) = Array.IndexOf(AllTheFiles, AllTheFiles.Last) Then
                        w.WriteLine("----------------------------------------------------------")
                        w.WriteLine("----------------------------------------------------------")
                    End If
                End Using
            Next

            'This is AllTheFiles "emoticons" writer
            For Each SingleFile As String In AllTheFiles
                Using w As StreamWriter = File.AppendText("output.txt")
                    w.WriteLine("[""" & Path.GetFileNameWithoutExtension(SingleFile) & """]=""" & Path.GetFileNameWithoutExtension(SingleFile) & """,")
                End Using
            Next

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Console.ReadKey(True)
        End Try




    End Sub
End Module
