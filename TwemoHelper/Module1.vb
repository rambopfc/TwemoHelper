Imports System.IO
Module Module1

    Sub Main()
        Dim CurrentFolder As String = Path.GetDirectoryName(Process.GetCurrentProcess.MainModule.FileName)

        Dim AllTheFiles As String() = IO.Directory.GetFiles(CurrentFolder)
        Dim SingleFile As String
        For Each SingleFile In AllTheFiles
            Dim x As String = Path.GetFileName(SingleFile).ToString()
        Next

    End Sub

End Module
