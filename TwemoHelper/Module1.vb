Imports System.IO
Module Module1

    Sub Main()
        Try
            Dim CurrentFolder As String = Path.GetDirectoryName(Process.GetCurrentProcess.MainModule.FileName)
            Dim AllTheFiles As String() = IO.Directory.GetFiles(CurrentFolder,"*.tga")
            Dim SingleFile As String
            If File.Exists("output.txt") Then
                File.Delete("output.txt")
                File.Create("output.txt").Close()
            Else
                File.Create("output.txt").Close()
            End If

            'This Is AllTheFiles defaultpack writer
            For Each SingleFile In AllTheFiles
                Dim x As String = Path.GetFileName(SingleFile).ToString()
                Using w As StreamWriter = File.AppendText("output.txt")
                    w.WriteLine("[""" & Path.GetFileName(SingleFile).ToString & """]=""Interface\\AddOns\\twemo\\" & Path.GetFileName(SingleFile).ToString & ":32:32"",")

                End Using




            Next
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            Console.ReadKey(True)
        End Try




    End Sub
End Module
