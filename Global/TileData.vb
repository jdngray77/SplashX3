Public Class TileData
    '===Buildings/Transport===
    'XXX Hahaha, buildings.

    '=====Tile Data====
    Public TileData(30, 13) 'DONE
    Public TileIndex(30, 2) 'DONE
    Public tileindexlength = 30

    Public ItemData(100, 10)

    Public craftingIndex(10, 10)
    Public CraftingData(10, 10, 10)
    Public Sub Initialise()
        'PathBlack - Row 0 
        TileIndex(0, 0) = "Path" ' friendly name
        TileIndex(0, 1) = "PathBlack" ' resource name
        TileIndex(0, 2) = 0 ' tileData index


        TileData(0, 0) = True  'Air
        TileData(0, 1) = True 'Ground
        TileData(0, 2) = True 'Heavy
        TileData(0, 3) = False 'Causes Damage
        TileData(0, 4) = "" 'AcInfo 0
        TileData(0, 5) = "" 'AcInfo 2
        TileData(0, 6) = "" 'AcInfo 3
        TileData(0, 7) = False 'Can be Axed?
        TileData(0, 8) = "" 'Axe Drop?
        TileData(0, 9) = False 'Can be Mined?
        TileData(0, 0) = "" 'Mine Drop

        TileData(0, 11) = 0 'Damage Multiplyer



        'PathExit - Row 1
        TileIndex(1, 0) = "Exit" ' friendly name
        TileIndex(1, 1) = "PathExit" ' resource name
        TileIndex(1, 2) = 1 ' tileData index


        TileData(1, 0) = True  'Air
        TileData(1, 1) = True 'Ground
        TileData(1, 2) = True 'Heavy
        TileData(1, 3) = False 'Causes Damage
        TileData(1, 4) = "This way!" 'AcInfo 1
        TileData(1, 5) = "" 'AcInfo 2
        TileData(1, 6) = "" 'AcInfo 3
        TileData(1, 7) = False 'Can be Axed?
        TileData(1, 8) = "" 'Axe Drop?
        TileData(1, 9) = False 'Can be Mined?
        TileData(1, 10) = "" 'Mine Drop

        TileData(1, 11) = 0 'Damage Multiplyer

        'RockBig
        TileIndex(2, 0) = "Boulder" ' friendly name
        TileIndex(2, 1) = "RockBig" ' resource name
        TileIndex(2, 2) = 2 ' tileData index

        TileData(2, 0) = True  'Air
        TileData(2, 1) = False 'Ground
        TileData(2, 2) = False 'Heavy
        TileData(2, 3) = False 'Causes Damage
        TileData(2, 4) = "Boulder" 'AcInfo 2
        TileData(2, 5) = "" 'AcInfo 2
        TileData(2, 6) = "Too large to climb!" 'AcInfo 3
        TileData(2, 7) = False 'Can be Axed?
        TileData(2, 8) = "" 'Axe Drop?
        TileData(2, 9) = True 'Can be Mined?
        TileData(2, 10) = "Iron" 'Mine Drop

        TileData(2, 11) = 0 'Damage Multiplyer

        'RockSmall
        TileIndex(3, 0) = "Rocks, Pebbles" ' friendly name
        TileIndex(3, 1) = "RockSmall" ' resource name
        TileIndex(3, 2) = 3 ' tileData index

        TileData(3, 0) = True  'Air
        TileData(3, 1) = False 'Ground
        TileData(3, 2) = True 'Heavy
        TileData(3, 3) = False 'Causes Damage
        TileData(3, 4) = "Small Pebbles" 'AcInfo 1
        TileData(3, 5) = "" 'AcInfo 2
        TileData(3, 6) = "Too unstable to climb!" 'AcInfo 3
        TileData(3, 7) = False 'Can be Axed?
        TileData(3, 8) = "" 'Axe Drop?
        TileData(3, 9) = True 'Can be Mined?
        TileData(3, 10) = "Stone" 'Mine Drop

        TileData(3, 11) = 0 'Damage Multiplyer

        'TreeSmall
        TileIndex(4, 0) = "Tree" ' friendly name
        TileIndex(4, 1) = "TreeSmall" ' resource name
        TileIndex(4, 2) = 4 ' tileData index


        TileData(4, 0) = False  'Air
        TileData(4, 1) = False 'Ground
        TileData(4, 2) = False 'Heavy
        TileData(4, 3) = False 'Causes Damage
        TileData(4, 4) = "Tree" 'AcInfo 1
        TileData(4, 5) = "" 'AcInfo 2
        TileData(4, 6) = "That a tall tree!" 'AcInfo 3
        TileData(4, 7) = True 'Can be Axed?
        TileData(4, 8) = "WoodPlank" 'Axe Drop?
        TileData(4, 9) = False 'Can be Mined?
        TileData(4, 10) = "" 'Mine Drop

        TileData(4, 11) = 0 'Damage Multiplyer

        'WaterNew
        TileIndex(5, 0) = "Water" ' friendly name
        TileIndex(5, 1) = "WaterNew" ' resource name
        TileIndex(5, 2) = 5 ' tileData index


        TileData(5, 0) = True  'Air
        TileData(5, 1) = False 'Ground
        TileData(5, 2) = False 'Heavy
        TileData(5, 3) = False 'Causes Damage
        TileData(5, 4) = "Water" 'AcInfo 1
        TileData(5, 5) = "" 'AcInfo 2
        TileData(5, 6) = "I can't swim!" 'AcInfo 3
        TileData(5, 7) = False 'Can be Axed?
        TileData(5, 8) = "" 'Axe Drop?
        TileData(5, 9) = False 'Can be Mined?
        TileData(5, 10) = "" 'Mine Drop

        TileData(5, 11) = 0 'Damage Multiplyer


        'SandPlain
        TileIndex(6, 0) = "Sand" ' friendly name
        TileIndex(6, 1) = "SandPlain" ' resource name
        TileIndex(6, 2) = 6 ' tileData index


        TileData(6, 0) = True  'Air
        TileData(6, 1) = True 'Ground
        TileData(6, 2) = True 'Heavy
        TileData(6, 3) = False 'Causes Damage
        TileData(6, 4) = "Sand" 'AcInfo 1
        TileData(6, 5) = "" 'AcInfo 2
        TileData(6, 6) = "How lovely!" 'AcInfo 3
        TileData(6, 7) = False 'Can be Axed?
        TileData(6, 8) = "" 'Axe Drop?
        TileData(6, 9) = False 'Can be Mined?
        TileData(6, 10) = "" 'Mine Drop

        TileData(6, 11) = 0 'Damage Multiplyer
        TileData(6, 12) = "2: Place Item" ' Active Info

        'SandCactus
        TileIndex(7, 0) = "Cactus" ' friendly name
        TileIndex(7, 1) = "SandCactus" ' resource name
        TileIndex(7, 2) = 7 ' tileData index


        TileData(7, 0) = True  'Air
        TileData(7, 1) = False 'Ground
        TileData(7, 2) = False 'Heavy
        TileData(7, 3) = True 'Causes Damage
        TileData(7, 4) = "Cactus" 'AcInfo 1
        TileData(7, 5) = "" 'AcInfo 2
        TileData(7, 6) = "Ouch!" 'AcInfo 3
        TileData(7, 7) = True 'Can be Axed?
        TileData(7, 8) = "" 'Axe Drop?
        TileData(7, 9) = False 'Can be Mined?
        TileData(7, 10) = "" 'Mine Drop

        TileData(7, 11) = 1 'Damage Multiplyer
        TileData(7, 12) = "2: Place Item" ' Active Info

        'Wooden Plank
        TileIndex(8, 0) = "Wooden Planks" ' friendly name
        TileIndex(8, 1) = "WoodPlank" ' resource name
        TileIndex(8, 2) = 8 ' tileData index

        TileData(8, 0) = True  'Air
        TileData(8, 1) = True 'Ground
        TileData(8, 2) = True 'Heavy
        TileData(8, 3) = False 'Causes Damage
        TileData(8, 4) = "Wooden Planks" 'AcInfo 1
        TileData(8, 5) = "" 'AcInfo 2
        TileData(8, 6) = "Surprisingly soft feeling!" 'AcInfo 3
        TileData(8, 7) = True 'Can be Axed?
        TileData(8, 8) = "WoodPlank" 'Axe Drop?
        TileData(8, 9) = False 'Can be Mined?
        TileData(8, 10) = "" 'Mine Drop

        TileData(8, 11) = 0 'Damage Multiplyer
        TileData(8, 12) = "2: Place Item" ' Active Info


        'SavePoint
        TileIndex(9, 0) = "Save Point" ' friendly name
        TileIndex(9, 1) = "SavePoint" ' resource name
        TileIndex(9, 2) = 9 ' tileData index


        TileData(9, 0) = True  'Air
        TileData(9, 1) = True 'Ground
        TileData(9, 2) = True 'Heavy
        TileData(9, 3) = False 'Causes Damage
        TileData(9, 4) = "Save Point." 'AcInfo 1
        TileData(9, 5) = "" 'AcInfo 2
        TileData(9, 6) = "1: Save" 'AcInfo 3
        TileData(9, 7) = False 'Can be Axed?
        TileData(9, 8) = "" 'Axe Drop?
        TileData(9, 9) = False 'Can be Mined?
        TileData(9, 10) = "" 'Mine Drop

        TileData(9, 11) = 0 'Damage Multiplyer

        'Quest Pointers
        TileIndex(10, 0) = "Quest Pointers" ' friendly name
        TileIndex(10, 1) = "QuestPointer" ' resource name
        TileIndex(10, 2) = 10 ' tileData index

        TileData(10, 0) = True  'Air
        TileData(10, 1) = True 'Ground
        TileData(10, 2) = True 'Heavy
        TileData(10, 3) = False 'Causes Damage
        TileData(10, 4) = "Quest!" 'AcInfo 1
        TileData(10, 5) = "" 'AcInfo 2
        TileData(10, 6) = "" 'AcInfo 3
        TileData(10, 7) = False 'Can be Axed?
        TileData(10, 8) = "" 'Axe Drop?
        TileData(10, 9) = False 'Can be Mined?
        TileData(10, 10) = "" 'Mine Drop

        TileData(10, 11) = 0 'Damage Multiplyer


        'PathAxe
        TileIndex(11, 0) = "Axe" ' friendly name
        TileIndex(11, 1) = "PathAxe" ' resource name
        TileIndex(11, 2) = 11 ' tileData index

        TileData(11, 0) = True  'Air
        TileData(11, 1) = False 'Ground
        TileData(11, 2) = True 'Heavy
        TileData(11, 3) = False 'Causes Damage
        TileData(11, 4) = "Axe" 'AcInfo 1
        TileData(11, 5) = "Used to cut wood" 'AcInfo 2
        TileData(11, 6) = "1: Pick Up" 'AcInfo 3
        TileData(11, 7) = False 'Can be Axed?
        TileData(11, 8) = "" 'Axe Drop?
        TileData(11, 9) = False 'Can be Mined?
        TileData(11, 10) = "" 'Mine Drop

        TileData(11, 11) = 5 'Damage Multiplyer
        TileData(11, 12) = "2: Use Item" ' Active Info

        'PickAxe
        TileIndex(12, 0) = "Pick Axe" ' friendly name
        TileIndex(12, 1) = "PickAxe" ' resource name
        TileIndex(12, 2) = 12 ' tileData index

        TileData(12, 0) = True  'Air
        TileData(12, 1) = False 'Ground
        TileData(12, 2) = True 'Heavy
        TileData(12, 3) = False 'Causes Damage
        TileData(12, 4) = "Pick Axe" 'AcInfo 1
        TileData(12, 5) = "Used to mine" 'AcInfo 2
        TileData(12, 6) = "1: Pick Up" 'AcInfo 3
        TileData(12, 7) = False 'Can be Axed?
        TileData(12, 8) = "" 'Axe Drop?
        TileData(12, 9) = False 'Can be Mined?
        TileData(12, 10) = "" 'Mine Drop

        TileData(12, 11) = 3 'Damage Multiplyer
        TileData(12, 12) = "2: Use Item"

        'GrassFlower
        TileIndex(13, 0) = "Flower" ' friendly name
        TileIndex(13, 1) = "GrassFlower" ' resource name
        TileIndex(13, 2) = 13 ' tileData index

        TileData(13, 0) = True  'Air
        TileData(13, 1) = True 'Ground
        TileData(13, 2) = True 'Heavy
        TileData(13, 3) = False 'Causes Damage
        TileData(13, 4) = "Flower" 'AcInfo 1
        TileData(13, 5) = "" 'AcInfo 2
        TileData(13, 6) = "" 'AcInfo 3
        TileData(13, 7) = False 'Can be Axed?
        TileData(13, 8) = "" 'Axe Drop?
        TileData(13, 9) = False 'Can be Mined?
        TileData(13, 10) = "" 'Mine Drop
        TileData(13, 11) = 0 'Damage Multiplyer
        TileData(13, 12) = ""

        'GrassLong
        TileIndex(14, 0) = "Long Grass" ' friendly name
        TileIndex(14, 1) = "GrassLong" ' resource name
        TileIndex(14, 2) = 14 ' tileData index

        TileData(14, 0) = True  'Air
        TileData(14, 1) = True 'Ground
        TileData(14, 2) = True 'Heavy
        TileData(14, 3) = False 'Causes Damage
        TileData(14, 4) = "Long Grass" 'AcInfo 1
        TileData(14, 5) = "" 'AcInfo 2
        TileData(14, 6) = "" 'AcInfo 3
        TileData(14, 7) = False 'Can be Axed?
        TileData(14, 8) = "" 'Axe Drop?
        TileData(14, 9) = False 'Can be Mined?
        TileData(14, 10) = "" 'Mine Drop

        TileData(14, 11) = 0 'Damage Multiplyer
        TileData(14, 12) = ""

        'Grass Plain
        TileIndex(15, 0) = "Grass" ' friendly name
        TileIndex(15, 1) = "GrassPlain" ' resource name
        TileIndex(15, 2) = 15 ' tileData index

        TileData(15, 0) = True  'Air
        TileData(15, 1) = True 'Ground
        TileData(15, 2) = True 'Heavy
        TileData(15, 3) = False 'Causes Damage
        TileData(15, 4) = "Grass" 'AcInfo 1
        TileData(15, 5) = "" 'AcInfo 2
        TileData(15, 6) = "" 'AcInfo 3
        TileData(15, 7) = False 'Can be Axed?
        TileData(15, 8) = "" 'Axe Drop?
        TileData(15, 9) = False 'Can be Mined?
        TileData(15, 10) = "" 'Mine Drop

        TileData(15, 11) = 3 'Damage Multiplyer
        TileData(15, 12) = ""


        'Grass Pole Fence
        TileIndex(16, 0) = "Fence" ' friendly name
        TileIndex(16, 1) = "GrassPoleFence" ' resource name
        TileIndex(16, 2) = 16 ' tileData index

        TileData(16, 0) = True  'Air
        TileData(16, 1) = False 'Ground
        TileData(16, 2) = False 'Heavy
        TileData(16, 3) = False 'Causes Damage
        TileData(16, 4) = "Fence" 'AcInfo 1
        TileData(16, 5) = "" 'AcInfo 2
        TileData(16, 6) = "" 'AcInfo 3
        TileData(16, 7) = False 'Can be Axed?
        TileData(16, 8) = "" 'Axe Drop?
        TileData(16, 9) = False 'Can be Mined?
        TileData(16, 10) = "" 'Mine Drop

        TileData(16, 11) = 0 'Damage Multiplyer
        TileData(16, 12) = ""

        'Grass pole large
        TileIndex(17, 0) = "Fence" ' friendly name
        TileIndex(17, 1) = "GrassPoleLarge" ' resource name
        TileIndex(17, 2) = 17 ' tileData index

        TileData(17, 0) = True  'Air
        TileData(17, 1) = False 'Ground
        TileData(17, 2) = False 'Heavy
        TileData(17, 3) = False 'Causes Damage
        TileData(17, 4) = "Fence" 'AcInfo 1
        TileData(17, 5) = "" 'AcInfo 2
        TileData(17, 6) = "" 'AcInfo 3
        TileData(17, 7) = False 'Can be Axed?
        TileData(17, 8) = "" 'Axe Drop?
        TileData(17, 9) = False 'Can be Mined?
        TileData(17, 10) = "" 'Mine Drop

        TileData(17, 11) = 3 'Damage Multiplyer
        TileData(17, 12) = ""

        'Grass Sign
        TileIndex(18, 0) = "Sign" ' friendly name
        TileIndex(18, 1) = "GrassSign" ' resource name
        TileIndex(18, 2) = 18 ' tileData index

        TileData(18, 0) = True  'Air
        TileData(18, 1) = False 'Ground
        TileData(18, 2) = False 'Heavy
        TileData(18, 3) = False 'Causes Damage
        TileData(18, 4) = "" 'AcInfo 1
        TileData(18, 5) = "" 'AcInfo 2
        TileData(18, 6) = "" 'AcInfo 3
        TileData(18, 7) = False 'Can be Axed?
        TileData(18, 8) = "" 'Axe Drop?
        TileData(18, 9) = False 'Can be Mined?
        TileData(18, 10) = "" 'Mine Drop

        TileData(18, 11) = 3 'Damage Multiplyer
        TileData(18, 12) = "1: Read"

        'Grass Tree
        TileIndex(19, 0) = "Tree" ' friendly name
        TileIndex(19, 1) = "GrassTree" ' resource name
        TileIndex(19, 2) = 19 ' tileData index

        TileData(19, 0) = True  'Air
        TileData(19, 1) = False 'Ground
        TileData(19, 2) = False 'Heavy
        TileData(19, 3) = False 'Causes Damage
        TileData(19, 4) = "Tree" 'AcInfo 1
        TileData(19, 5) = "" 'AcInfo 2
        TileData(19, 6) = "" 'AcInfo 3
        TileData(19, 7) = True 'Can be Axed?
        TileData(19, 8) = "WoodPlank" 'Axe Drop?
        TileData(19, 9) = False 'Can be Mined?
        TileData(19, 10) = "" 'Mine Drop

        TileData(19, 11) = 3 'Damage Multiplyer
        TileData(19, 12) = ""


        'sand
        TileIndex(20, 0) = "Sand" ' friendly name
        TileIndex(20, 1) = "Sand" ' resource name
        TileIndex(20, 2) = 20 ' tileData index

        TileData(20, 0) = True  'Air
        TileData(20, 1) = True 'Ground
        TileData(20, 2) = True 'Heavy
        TileData(20, 3) = False 'Causes Damage
        TileData(20, 4) = "Sand" 'AcInfo 1
        TileData(20, 5) = "" 'AcInfo 2
        TileData(20, 6) = "" 'AcInfo 3
        TileData(20, 7) = False 'Can be Axed?
        TileData(20, 8) = "" 'Axe Drop?
        TileData(20, 9) = False 'Can be Mined?
        TileData(20, 10) = "" 'Mine Drop

        TileData(20, 11) = 3 'Damage Multiplyer
        TileData(20, 12) = ""

        'Grass Gravel
        TileIndex(21, 0) = "Harsh Sand" ' friendly name
        TileIndex(21, 1) = "SandGravel" ' resource name
        TileIndex(21, 2) = 21 ' tileData index

        TileData(21, 0) = True  'Air
        TileData(21, 1) = True 'Ground
        TileData(21, 2) = True 'Heavy
        TileData(21, 3) = False 'Causes Damage
        TileData(21, 4) = "Gravely Sand" 'AcInfo 1
        TileData(21, 5) = "" 'AcInfo 2
        TileData(21, 6) = "" 'AcInfo 3
        TileData(21, 7) = False 'Can be Axed?
        TileData(21, 8) = "" 'Axe Drop?
        TileData(21, 9) = False 'Can be Mined?
        TileData(21, 10) = "" 'Mine Drop

        TileData(21, 11) = 3 'Damage Multiplyer
        TileData(21, 12) = ""

        'Sand Pole Fence
        TileIndex(22, 0) = "Fence" ' friendly name
        TileIndex(22, 1) = "SandPoleFence" ' resource name
        TileIndex(22, 2) = 22 ' tileData index

        TileData(22, 0) = True  'Air
        TileData(22, 1) = False 'Ground
        TileData(22, 2) = False 'Heavy
        TileData(22, 3) = False 'Causes Damage
        TileData(22, 4) = "Fence" 'AcInfo 1
        TileData(22, 5) = "" 'AcInfo 2
        TileData(22, 6) = "" 'AcInfo 3
        TileData(22, 7) = False 'Can be Axed?
        TileData(22, 8) = "" 'Axe Drop?
        TileData(22, 9) = False 'Can be Mined?
        TileData(22, 10) = "" 'Mine Drop

        TileData(22, 11) = 3 'Damage Multiplyer
        TileData(22, 12) = ""

        'Sand Pole Large
        TileIndex(23, 0) = "Fence" ' friendly name
        TileIndex(23, 1) = "SandPoleLarge" ' resource name
        TileIndex(23, 2) = 23 ' tileData index

        TileData(23, 0) = True  'Air
        TileData(23, 1) = False 'Ground
        TileData(23, 2) = False 'Heavy
        TileData(23, 3) = False 'Causes Damage
        TileData(23, 4) = "Fence" 'AcInfo 1
        TileData(23, 5) = "" 'AcInfo 2
        TileData(23, 6) = "" 'AcInfo 3
        TileData(23, 7) = False 'Can be Axed?
        TileData(23, 8) = "" 'Axe Drop?
        TileData(23, 9) = False 'Can be Mined?
        TileData(23, 10) = "" 'Mine Drop

        TileData(23, 11) = 3 'Damage Multiplyer
        TileData(23, 12) = ""

        'Sand Sign
        TileIndex(24, 0) = "Sign" ' friendly name
        TileIndex(24, 1) = "SandSign" ' resource name
        TileIndex(24, 2) = 24 ' tileData index

        TileData(24, 0) = True  'Air
        TileData(24, 1) = False 'Ground
        TileData(24, 2) = False 'Heavy
        TileData(24, 3) = False 'Causes Damage
        TileData(24, 4) = "Sign" 'AcInfo 1
        TileData(24, 5) = "" 'AcInfo 2
        TileData(24, 6) = "" 'AcInfo 3
        TileData(24, 7) = False 'Can be Axed?
        TileData(24, 8) = "" 'Axe Drop?
        TileData(24, 9) = False 'Can be Mined?
        TileData(24, 10) = "" 'Mine Drop

        TileData(24, 11) = 3 'Damage Multiplyer
        TileData(24, 12) = "1: Read"

        'Save Point
        TileIndex(25, 0) = "Save Point" ' friendly name
        TileIndex(25, 1) = "SaveNew" ' resource name
        TileIndex(25, 2) = 25 ' tileData index

        TileData(25, 0) = True  'Air
        TileData(25, 1) = False 'Ground
        TileData(25, 2) = False 'Heavy
        TileData(25, 3) = False 'Causes Damage
        TileData(25, 4) = "Save" 'AcInfo 1
        TileData(25, 5) = "" 'AcInfo 2
        TileData(25, 6) = "" 'AcInfo 3
        TileData(25, 7) = False 'Can be Axed?
        TileData(25, 8) = "" 'Axe Drop?
        TileData(25, 9) = False 'Can be Mined?
        TileData(25, 10) = "" 'Mine Drop

        TileData(25, 11) = 3 'Damage Multiplyer
        TileData(25, 12) = "1: Save"

        'Grass that's as worn as me
        TileIndex(26, 0) = "Worn Grass" ' friendly name
        TileIndex(26, 1) = "GrassWorn" ' resource name
        TileIndex(26, 2) = 26 ' tileData index

        TileData(26, 0) = True  'Air
        TileData(26, 1) = True 'Ground
        TileData(26, 2) = False 'Heavy
        TileData(26, 3) = False 'Causes Damage
        TileData(26, 4) = "Worn Grass" 'AcInfo 1
        TileData(26, 5) = "" 'AcInfo 2
        TileData(26, 6) = "" 'AcInfo 3
        TileData(26, 7) = False 'Can be Axed?
        TileData(26, 8) = "" 'Axe Drop?
        TileData(26, 9) = False 'Can be Mined?
        TileData(26, 10) = "" 'Mine Drop

        TileData(26, 11) = 0 'Damage Multiplyer
        TileData(26, 12) = ""

        'PathAxe
        ItemData(11, 0) = 10 'Durability
        ItemData(11, 1) = 1 'Efficiency

        'PickAxe
        ItemData(12, 0) = 10 'Durability
        ItemData(12, 1) = 1 'Efficiency

        'Crafting Data(ITEM NUMBER, 0 = data - 1 = CRAFTING ITEM -  2 = CRAFTING QUANTITY)
        CraftingData(0, 0, 1) = 3 'Extra, Craftable items
        CraftingData(1, 0, 0) = "PathAxe" 'Resource name
        CraftingData(1, 0, 1) = "Axe" 'Friendly name
        CraftingData(1, 1, 0) = "WoodPlank" 'Crafting item 1 resource name
        CraftingData(1, 2, 0) = 2 'Crafting item 1 quantity name
        CraftingData(1, 1, 0) = "RockSmall" 'Crafting item 1 resource name
        CraftingData(1, 2, 0) = 2 'Crafting item 1 quantity name

    End Sub

    Public Sub ItemAction(Item, Action, x, y)
        Initialise()
        Select Case Item
            Case "PathAxe"
                If Action = "1" Then
                    frmGame.inventory("Add", "PathAxe")
                    frmGame.DisplayEngine("PlaceTile", "ForAndBack", x, y, "GrassPlain")
                ElseIf Action = "ActionComplete" Then
                    Dim index = GetIndex(frmGame.ActiveDisplayMemory(x - 1, y - 1), "Resource")
                    If Not TileData(index, 7) Then Exit Sub
                    frmGame.TimerTime = 1
                    frmGame.TimerEfficiency = ItemData(11, 1)
                    frmGame.inventory("UpdateActive", "Force")
                    frmGame.ActionTimer.Enabled = True
                    frmGame.DisplayEngine("PlaceTile", "Fore", x, y, "Working1")
                ElseIf Action = "TimerComplete" Then
                    Dim index = GetIndex(frmGame.ActiveDisplayMemory(x - 1, y - 1), "Resource")
                    frmGame.inventory("Add", TileData(index, 8))
                    frmGame.DisplayEngine("PlaceTile", "ForAndBack", x, y, "GrassWorn")
                ElseIf Action = "2" Then
                    frmGame.SelecterEngine("Open", vbNull)
                End If
            Case "WoodPlank"
                If Action = "2" Then
                    frmGame.SelecterEngine("Open", vbNull)
                ElseIf Action = "ActionComplete" Then
                    frmGame.TimerTime = 1
                    frmGame.TimerEfficiency = 1
                    frmGame.inventory("UpdateActive", "Force")
                    frmGame.ActionTimer.Enabled = True
                    frmGame.DisplayEngine("PlaceTile", "Fore", x, y, "Working1")
                ElseIf Action = "TimerComplete" Then
                    frmGame.inventory("ChangeDurablity", -1)
                    frmGame.DisplayEngine("PlaceTile", "ForAndBack", x, y, "WoodPlank")
                End If
        End Select
    End Sub

    Public Function GetIndex(Tile, type)
        Dim index = 1000
        Dim e = 1
        If type = "Resource" Then
            e = 1
        ElseIf type = "Friend" Then
            e = 0
        End If

        For i = 0 To tileindexlength Step 1
            Try
                If TileIndex(i, e) = Tile Then
                    index = i
                End If
            Catch ex As Exception
                frmGame.MessageEngine("ERROR: at Character handler, Action, Game:" & ex.Message, "Error")
            End Try
        Next
        Return index
    End Function
End Class