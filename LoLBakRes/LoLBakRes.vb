﻿Imports System.Diagnostics
Imports System.Threading
Imports System.IO

Module LoLBakRes

    Sub Main(ByVal args As String())
        If args.Length = 0 Then

            Console.WriteLine("LoLToolsX 備份主控台不能獨自運行...")
            Console.Write("5 秒後離開本系統")
            Thread.Sleep(1000)
            Console.Write(".")
            Thread.Sleep(1000)
            Console.Write(".")
            Thread.Sleep(1000)
            Console.Write(".")
            Thread.Sleep(1000)
            Console.Write(".")
            Thread.Sleep(1000)
            Console.Write(".")
            Environment.Exit(Environment.ExitCode)
        End If

        If args(0) = "Backup" Then
            Console.WriteLine("備份開始!")
            Try
                Console.WriteLine("備份中 請稍候...")
                Dim bakPath As String = Path.Combine(Directory.GetCurrentDirectory(), "\bak\LoL")
                My.Computer.FileSystem.CopyDirectory(args(1), bakPath, True)
                Console.WriteLine("備份成功! 按任意鍵離開...")
            Catch ex As Exception
                Console.WriteLine("備份失敗! 按任意鍵離開...: ")
                Console.WriteLine(ex)
            Finally
                Console.ReadLine()
            End Try


        End If

        If args(0) = "Restore" Then
            Console.WriteLine("還原開始!")
            Try
                Console.WriteLine("還原中 請稍候...")
                My.Computer.FileSystem.CopyDirectory(Directory.GetCurrentDirectory() + "\bak\LoL", args(1), True)
                Console.WriteLine("還原成功! 按任意鍵離開...")
            Catch ex As Exception
                Console.WriteLine("還原失敗! 按任意鍵離開... ")
                Console.WriteLine(ex)
            Finally
                Console.ReadLine()
            End Try
        End If

    End Sub

End Module
