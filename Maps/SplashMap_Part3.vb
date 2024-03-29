﻿Public Class SplashMap_Part3
    '====Map Info====
    Public MapDrawn(10, 20)

    Public MapName = "SplashMap_Part3"
    Public MapFamily = "Splash"
    Public MapTrack = "CrimsonDrive"
    Public StartX = 8
    Public StartY = 1

    'Active Components
    Public exitSet(9, 19)
    Public exitName(9, 19)

    Public charSet(10, 20) As Object
    Public Sub Initialise()
        'Exits

        'Intro
        exitSet(2, 19) = "SplashMap_Part4"
        exitName(2, 19) = "Intro"
        'Character Set

        'Row 0
        charSet(0, 0) = "TreeNew"
        charSet(0, 1) = "TreeNew"
        charSet(0, 2) = "TreeNew"
        charSet(0, 3) = "TreeNew"
        charSet(0, 4) = "RockSmall"
        charSet(0, 5) = "RockSmall"
        charSet(0, 6) = "RockBig"
        charSet(0, 7) = "RockBig"
        charSet(0, 8) = "PathBlack"
        charSet(0, 9) = "RockSmall"
        charSet(0, 10) = "RockSmall"
        charSet(0, 11) = "RockSmall"
        charSet(0, 12) = "PathBlack"
        charSet(0, 13) = "PathBlack"
        charSet(0, 14) = "PathBlack"
        charSet(0, 15) = "PathBlack"
        charSet(0, 16) = "WaterDown"
        charSet(0, 17) = "WaterDown"
        charSet(0, 18) = "WaterDown"
        charSet(0, 19) = "WaterDown"

        'Row 1
        charSet(1, 0) = "TreeNew"
        charSet(1, 1) = "TreeNew"
        charSet(1, 2) = "TreeNew"
        charSet(1, 3) = "TreeNew"
        charSet(1, 4) = "PathBlack"
        charSet(1, 5) = "PathBlack"
        charSet(1, 6) = "RockSmall"
        charSet(1, 7) = "RockSmall"
        charSet(1, 8) = "RockSmall"
        charSet(1, 9) = "PathBlack"
        charSet(1, 10) = "RockSmall"
        charSet(1, 11) = "PathBlack"
        charSet(1, 12) = "PathBlack"
        charSet(1, 13) = "PathBlack"
        charSet(1, 14) = "PathBlack"
        charSet(1, 15) = "WaterDown"
        charSet(1, 16) = "PathBlack"
        charSet(1, 17) = "PathBlack"
        charSet(1, 18) = "WaterDown"
        charSet(1, 19) = "WaterDown"

        'Row 2
        charSet(2, 0) = "TreeNew"
        charSet(2, 1) = "TreeNew"
        charSet(2, 2) = "TreeNew"
        charSet(2, 3) = "PathBlack"
        charSet(2, 4) = "PathBlack"
        charSet(2, 5) = "PathBlack"
        charSet(2, 6) = "PathBlack"
        charSet(2, 7) = "PathBlack"
        charSet(2, 8) = "RockSmall"
        charSet(2, 9) = "PathBlack"
        charSet(2, 10) = "PathBlack"
        charSet(2, 11) = "PathBlack"
        charSet(2, 12) = "PathBlack"
        charSet(2, 13) = "PathBlack"
        charSet(2, 14) = "PathBlack"
        charSet(2, 15) = "PathBlack"
        charSet(2, 16) = "PathBlack"
        charSet(2, 17) = "EnemyBase"
        charSet(2, 18) = "PathBlack"
        charSet(2, 19) = "PathExit"

        'Row 3
        charSet(3, 0) = "TreeNew"
        charSet(3, 1) = "TreeNew"
        charSet(3, 2) = "TreeNew"
        charSet(3, 3) = "PickAxe"
        charSet(3, 4) = "PathBlack"
        charSet(3, 5) = "PathBlack"
        charSet(3, 6) = "PathBlack"
        charSet(3, 7) = "RockSmall"
        charSet(3, 8) = "PathBlack"
        charSet(3, 9) = "PathBlack"
        charSet(3, 10) = "PathBlack"
        charSet(3, 11) = "PathBlack"
        charSet(3, 12) = "PathBlack"
        charSet(3, 13) = "PathBlack"
        charSet(3, 14) = "PathBlack"
        charSet(3, 15) = "WaterDown"
        charSet(3, 16) = "PathBlack"
        charSet(3, 17) = "PathBlack"
        charSet(3, 18) = "WaterDown"
        charSet(3, 19) = "WaterDown"

        'Row 4
        charSet(4, 0) = "TreeNew"
        charSet(4, 1) = "TreeNew"
        charSet(4, 2) = "PathBlack"
        charSet(4, 3) = "PathBlack"
        charSet(4, 4) = "PathBlack"
        charSet(4, 5) = "PathBlack"
        charSet(4, 6) = "PathBlack"
        charSet(4, 7) = "PathBlack"
        charSet(4, 8) = "PathBlack"
        charSet(4, 9) = "PathBlack"
        charSet(4, 10) = "PathBlack"
        charSet(4, 11) = "PathBlack"
        charSet(4, 12) = "PathBlack"
        charSet(4, 13) = "PathBlack"
        charSet(4, 14) = "PathBlack"
        charSet(4, 15) = "PathBlack"
        charSet(4, 16) = "WaterDown"
        charSet(4, 17) = "WaterDown"
        charSet(4, 18) = "WaterDown"
        charSet(4, 19) = "WaterDown"

        'Row 5
        charSet(5, 0) = "TreeNew"
        charSet(5, 1) = "TreeNew"
        charSet(5, 2) = "PathBlack"
        charSet(5, 3) = "PathBlack"
        charSet(5, 4) = "PathBlack"
        charSet(5, 5) = "PathBlack"
        charSet(5, 6) = "PathBlack"
        charSet(5, 7) = "PathBlack"
        charSet(5, 8) = "PathBlack"
        charSet(5, 9) = "PathBlack"
        charSet(5, 10) = "PathBlack"
        charSet(5, 11) = "PathBlack"
        charSet(5, 12) = "PathBlack"
        charSet(5, 13) = "SavePoint"
        charSet(5, 14) = "SandPlain"
        charSet(5, 15) = "PathBlack"
        charSet(5, 16) = "PathBlack"
        charSet(5, 17) = "PathBlack"
        charSet(5, 18) = "PathBlack"
        charSet(5, 19) = "PathBlack"

        'Row 6
        charSet(6, 0) = "TreeNew"
        charSet(6, 1) = "PathBlack"
        charSet(6, 2) = "PathBlack"
        charSet(6, 3) = "PathBlack"
        charSet(6, 4) = "PathBlack"
        charSet(6, 5) = "PathBlack"
        charSet(6, 6) = "PathBlack"
        charSet(6, 7) = "PathBlack"
        charSet(6, 8) = "SandPlain"
        charSet(6, 9) = "SandPlain"
        charSet(6, 10) = "SandCactus"
        charSet(6, 11) = "SandPlain"
        charSet(6, 12) = "SandPlain"
        charSet(6, 13) = "SandPlain"
        charSet(6, 14) = "WaterNew"
        charSet(6, 15) = "SandPlain"
        charSet(6, 16) = "PathBlack"
        charSet(6, 17) = "PathBlack"
        charSet(6, 18) = "PathBlack"
        charSet(6, 19) = "PathBlack"

        'Row 7
        charSet(7, 0) = "PathBlack"
        charSet(7, 1) = "PathBlack"
        charSet(7, 2) = "PathBlack"
        charSet(7, 3) = "PathBlack"
        charSet(7, 4) = "SandPlain"
        charSet(7, 5) = "SandPlain"
        charSet(7, 6) = "SandPlain"
        charSet(7, 7) = "SandPlain"
        charSet(7, 8) = "WaterNew"
        charSet(7, 9) = "WaterNew"
        charSet(7, 10) = "WaterNew"
        charSet(7, 11) = "WaterNew"
        charSet(7, 12) = "WaterNew"
        charSet(7, 13) = "WaterNew"
        charSet(7, 14) = "WaterNew"
        charSet(7, 15) = "WaterNew"
        charSet(7, 16) = "SandPlain"
        charSet(7, 17) = "PathBlack"
        charSet(7, 18) = "SandPlain"
        charSet(7, 19) = "SandCactus"

        'Row 8
        charSet(8, 0) = "PathBlack"
        charSet(8, 1) = "PathBlack"
        charSet(8, 2) = "SandPlain"
        charSet(8, 3) = "SandCactus"
        charSet(8, 4) = "WaterNew"
        charSet(8, 5) = "WaterNew"
        charSet(8, 6) = "WaterNew"
        charSet(8, 7) = "WaterNew"
        charSet(8, 8) = "WaterNew"
        charSet(8, 9) = "WaterNew"
        charSet(8, 10) = "WaterNew"
        charSet(8, 11) = "WaterNew"
        charSet(8, 12) = "WaterNew"
        charSet(8, 13) = "WaterNew"
        charSet(8, 14) = "WaterNew"
        charSet(8, 15) = "WaterNew"
        charSet(8, 16) = "SandCactus"
        charSet(8, 17) = "SandPlain"
        charSet(8, 18) = "WaterNew"
        charSet(8, 19) = "WaterNew"

        'Row 9
        charSet(9, 0) = "TreeNew"
        charSet(9, 1) = "SandPlain"
        charSet(9, 2) = "WaterNew"
        charSet(9, 3) = "WaterNew"
        charSet(9, 4) = "WaterNew"
        charSet(9, 5) = "WaterNew"
        charSet(9, 6) = "WaterNew"
        charSet(9, 7) = "WaterNew"
        charSet(9, 8) = "WaterNew"
        charSet(9, 9) = "WaterNew"
        charSet(9, 10) = "WaterNew"
        charSet(9, 11) = "WaterNew"
        charSet(9, 12) = "WaterNew"
        charSet(9, 13) = "WaterNew"
        charSet(9, 14) = "WaterNew"
        charSet(9, 15) = "WaterNew"
        charSet(9, 16) = "WaterNew"
        charSet(9, 17) = "WaterNew"
        charSet(9, 18) = "WaterNew"
        charSet(9, 19) = "WaterNew"
    End Sub
    '    Public Sub StoryLine(trigger)
    '        Dim story As StoryEngine = New StoryEngine
    '        Dim message As MessageEngine = New MessageEngine
    '        Dim display As DisplayEngine = New DisplayEngine
    '        Select Case Game.Storyprogress
    '            Case 1
    '                If trigger = "Load" Then
    '                End If
    '        End select
    'end sub
End class
