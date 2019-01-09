Public Class Form1
    Dim mouthopen As Boolean
    Dim direction As Integer
    Dim vertroad(4) As PictureBox
    Dim horzroad(1) As PictureBox
    Dim ghost(3) As PictureBox
    Dim ghostdir(3) As Integer
    Dim ghoststate(3) As Integer
    Const INHOME As Integer = 0
    Const LEAVINGHOME As Integer = 1
    Const REGULAR As Integer = 2
    Const NUMPELLETS As Integer = 58
    Dim pellet(NUMPELLETS) As PictureBox
    Dim numpelletseaten As Integer
    Dim deaths As Integer
    Dim lives(2) As PictureBox
    Dim powerPellet(3) As PictureBox
    Dim powerCounter As Integer
    Dim youIsPoweredUp As Boolean = False
    Dim isGhostGoing As Boolean = False
    Dim ghostIsKillable(3) As Boolean
    Dim score As Integer = 0
    Dim scoreFile As System.IO.StreamWriter
    Dim usernameFile As System.IO.StreamWriter
    Dim currentHighscore As Integer
    Dim highscoreName As String
    Dim doneRecordingHighscore As Boolean = False
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        quit = False
        vertroad(0) = vertroad0
        vertroad(1) = vertroad1
        vertroad(2) = vertroad2
        vertroad(3) = vertroad3
        vertroad(4) = vertroad4

        horzroad(0) = horzroad0
        horzroad(1) = horzroad1

        lives(0) = Lives0
        lives(1) = lives1
        lives(2) = Lives2

        deaths = 0
        numpelletseaten = 0
        powerCounter = 0
        PowerPelletSet()

        usernameLabel.Text = My.Computer.FileSystem.ReadAllText(IO.Path.GetDirectoryName(Application.ExecutablePath) & "Username.txt")
        highscoreValue.Text = My.Computer.FileSystem.ReadAllText(IO.Path.GetDirectoryName(Application.ExecutablePath) & "highscore.txt")
        currentHighscore = My.Computer.FileSystem.ReadAllText(IO.Path.GetDirectoryName(Application.ExecutablePath) & "highscore.txt")
        resetlevel()
        Timer1.Start()
    End Sub
    Private Sub PelletSet()
        pellet(0) = PictureBox2
        pellet(1) = PictureBox3
        pellet(2) = PictureBox4
        pellet(3) = PictureBox5
        pellet(4) = PictureBox6
        pellet(5) = PictureBox7
        pellet(6) = PictureBox8
        pellet(7) = PictureBox9
        pellet(8) = PictureBox10
        pellet(9) = PictureBox11
        pellet(10) = PictureBox12
        pellet(11) = PictureBox13
        pellet(12) = PictureBox14
        pellet(13) = PictureBox15
        pellet(14) = PictureBox16
        pellet(15) = PictureBox17
        pellet(16) = PictureBox18
        pellet(17) = PictureBox19
        pellet(18) = PictureBox20
        pellet(19) = PictureBox21
        pellet(20) = PictureBox22
        pellet(21) = PictureBox23
        pellet(22) = PictureBox24
        pellet(23) = PictureBox25
        pellet(24) = PictureBox26
        pellet(25) = PictureBox27
        pellet(26) = PictureBox28
        pellet(27) = PictureBox29
        pellet(28) = PictureBox30
        pellet(29) = PictureBox31
        pellet(30) = PictureBox32
        pellet(31) = PictureBox33
        pellet(32) = PictureBox34
        pellet(33) = PictureBox35
        pellet(34) = PictureBox36
        pellet(35) = PictureBox37
        pellet(36) = PictureBox38
        pellet(37) = PictureBox39
        pellet(38) = PictureBox40
        pellet(39) = PictureBox41
        pellet(40) = PictureBox42
        pellet(41) = PictureBox43
        pellet(42) = PictureBox44
        pellet(43) = PictureBox45
        pellet(44) = PictureBox46
        pellet(45) = PictureBox47
        pellet(46) = PictureBox48
        pellet(47) = PictureBox49
        pellet(48) = PictureBox50
        pellet(49) = PictureBox51
        pellet(50) = PictureBox52
        pellet(51) = PictureBox53
        pellet(52) = PictureBox54
        pellet(53) = PictureBox55
        pellet(54) = PictureBox56
        pellet(55) = PictureBox57
        pellet(56) = PictureBox58
        pellet(57) = PictureBox59
        pellet(58) = PictureBox60
    End Sub
    Private Sub PowerPelletSet()
        powerPellet(0) = Power0
        powerPellet(1) = Power1
        powerPellet(2) = Power2
        powerPellet(3) = Power3
        Dim index As Integer
        For index = 0 To 3
            powerPellet(index).Visible = True
        Next index
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        direction = e.KeyCode
    End Sub
    Private Sub moveup(ByVal steve As PictureBox, ByVal speed As Integer)
        steve.Top = steve.Top - speed
        If steve.Top < 0 Then
            steve.Top = 600
        End If
    End Sub
    Private Sub animationup()
        If mouthopen = True Then
            Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmupc.bmp")
            mouthopen = False
        ElseIf mouthopen = False Then
            Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmupo.bmp")
            mouthopen = True
        End If
    End Sub
    Private Sub moveright(ByVal steve As PictureBox, ByVal speed As Integer)
        steve.Left = steve.Left + speed
        If steve.Left > 800 Then
            steve.Left = 0
        End If
    End Sub
    Private Sub animationright()
        If mouthopen = True Then
            Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmrtc.bmp")
            mouthopen = False
        ElseIf mouthopen = False Then
            Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmrto.bmp")
            mouthopen = True
        End If
    End Sub
    Private Sub moveleft(ByVal steve As PictureBox, ByVal speed As Integer)
        steve.Left = steve.Left - speed
        If steve.Left < 0 Then
            steve.Left = 800
        End If
    End Sub
    Private Sub animationleft()
        If mouthopen = True Then
            Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmltc.bmp")
            mouthopen = False
        ElseIf mouthopen = False Then
            Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmlto.bmp")
            mouthopen = True
        End If
    End Sub
    Private Sub movedown(ByVal steve As PictureBox, ByVal speed As Integer)
        steve.Top = steve.Top + speed
        If steve.Top > 600 Then
            steve.Top = 0
        End If
    End Sub
    Private Sub animationdown()
        If mouthopen = True Then
            Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmdnc.bmp")
            mouthopen = False
        ElseIf mouthopen = False Then
            Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\Pacman\pmdno.bmp")
            mouthopen = True
        End If
    End Sub
    Private Sub moveghost(ByVal ghostindex As Integer)
        Dim index As Integer
        For index = 0 To 1
            If touching(ghost(ghostindex), horzroad(index)) Then
                If ghostdir(ghostindex) = Keys.Left Then
                    moveleft(ghost(ghostindex), 4)
                    ghost(ghostindex).Top = horzroad(index).Top
                ElseIf ghostdir(ghostindex) = Keys.Right Then
                    moveright(ghost(ghostindex), 4)
                    ghost(ghostindex).Top = horzroad(index).Top
                End If
            End If
        Next index
        For index = 0 To 4
            If touching(ghost(ghostindex), vertroad(index)) Then
                If ghostdir(ghostindex) = Keys.Up Then
                    moveup(ghost(ghostindex), 4)
                    ghost(ghostindex).Left = vertroad(index).Left
                ElseIf ghostdir(ghostindex) = Keys.Down Then
                    movedown(ghost(ghostindex), 4)
                    ghost(ghostindex).Left = vertroad(index).Left
                End If
            End If
        Next index
    End Sub
   
    Private Sub resetlevel()
        pacmanset()
        ghostset()
        PelletSet()
        PowerDown()
    End Sub
    Private Sub pacmanset()
        Pacman.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\pacman\pmRtO.bmp")
        mouthopen = True
        Pacman.Left = 347
        Pacman.Top = 418
    End Sub
    Private Sub ghostset()
        ghost(0) = ghost0
        ghost(1) = ghost1
        ghost(2) = ghost2
        ghost(3) = ghost3

        ghostdir(0) = Keys.Left
        ghostdir(1) = Keys.Right
        ghostdir(2) = Keys.Left
        ghostdir(3) = Keys.Right

        ghost0.Left = 333
        ghost0.Top = 253
        ghost1.Left = 392
        ghost1.Top = 253
        ghost2.Left = 333
        ghost2.Top = 312
        ghost3.Left = 392
        ghost3.Top = 312

        ghoststate(0) = INHOME
        ghoststate(1) = INHOME
        ghoststate(2) = INHOME
        ghoststate(3) = INHOME

        ghostIsKillable(0) = False
        ghostIsKillable(1) = False
        ghostIsKillable(2) = False
        ghostIsKillable(3) = False

        isGhostGoing = False
    End Sub
    Private Sub moveintogame(ByVal whichGhost As Integer)
        If ghoststate(whichGhost) = INHOME And isGhostGoing = False Then
            ghoststate(whichGhost) = LEAVINGHOME
            ghost(whichGhost).Left = 350
            ghost(whichGhost).Top = 286
            isGhostGoing = True
        ElseIf ghoststate(whichGhost) = LEAVINGHOME Then
            ghost(whichGhost).Top = ghost(whichGhost).Top - 4
            If ghost(whichGhost).Top < 150 Then
                ghoststate(whichGhost) = REGULAR
                ghostdir(whichGhost) = Keys.Left
                isGhostGoing = False
            End If
        End If
    End Sub
    Private Sub animatepacman()
        If direction = Keys.Left Or direction = Keys.A Then
            animationleft()
        ElseIf direction = Keys.Right Or direction = Keys.D Then
            animationright()
        ElseIf direction = Keys.Up Or direction = Keys.W Then
            animationup()
        ElseIf direction = Keys.Down Or direction = Keys.S Then
            animationdown()
        End If
    End Sub
    Private Sub movepacman()
        Dim index As Integer
        For index = 0 To 1
            If touching(Pacman, horzroad(index)) Then
                If direction = Keys.Left Or direction = Keys.A Then
                    moveleft(Pacman, 10)
                    Pacman.Top = horzroad(index).Top
                ElseIf direction = Keys.Right Or direction = Keys.D Then
                    moveright(Pacman, 10)
                    Pacman.Top = horzroad(index).Top
                End If
            End If
        Next index
        For index = 0 To 4
            If touching(Pacman, vertroad(index)) Then
                If direction = Keys.Up Or direction = Keys.W Then
                    moveup(Pacman, 10)
                    Pacman.Left = vertroad(index).Left
                ElseIf direction = Keys.Down Or direction = Keys.S Then
                    movedown(Pacman, 10)
                    Pacman.Left = vertroad(index).Left
                End If
            End If
        Next index
    End Sub
    Private Sub YouGotTheHighscore()
        Timer1.Stop()
        usernameFile = My.Computer.FileSystem.OpenTextFileWriter(IO.Path.GetDirectoryName(Application.ExecutablePath) & "Username.txt", False)
        highscoreName = InputBox("You got the highscore." & vbCrLf & "" & vbCrLf & "Enter name in box.", "Congratulations!")
        While highscoreName = ""
            highscoreName = InputBox("You got the highscore." & vbCrLf & "" & vbCrLf & "Enter name in box.", "Congratulations!")
        End While
        usernameFile.Write(highscoreName)
        usernameFile.Close()
        usernameLabel.Text = My.Computer.FileSystem.ReadAllText(IO.Path.GetDirectoryName(Application.ExecutablePath) & "Username.txt")
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim pindex As Integer
        Dim index As Integer
        If quit = True Then
            If score > currentHighscore Then
                YouGotTheHighscore()
                scoreFile = My.Computer.FileSystem.OpenTextFileWriter(IO.Path.GetDirectoryName(Application.ExecutablePath) & "highscore.txt", False)
                scoreFile.Write(score)
                scoreFile.Close()
            End If
            Me.Close()
        End If
        scoreValue.Text = score
        movepacman()
        animatepacman()
        For pindex = 0 To 3
            If touching(Pacman, powerPellet(pindex)) And powerPellet(pindex).Visible = True Then
                PowerUp()
                powerPellet(pindex).Visible = False
            End If
        Next pindex
        For index = 0 To 3
            If ghoststate(index) = REGULAR Then
                moveghost(index)
                If at_intersection(index) = True Then
                    chasepacman(index)
                End If
            Else
                moveintogame(index)
            End If
            If touching(Pacman, ghost(index)) Then
                If ghostIsKillable(index) = True Then
                    If ghoststate(index) = LEAVINGHOME Then
                        isGhostGoing = False
                    End If
                    KillGhost(index)
                    score = score + 20
                Else
                    KillPacman()
                End If
            End If
        Next index
        If youIsPoweredUp = True Then
            powerCounter = powerCounter + 1
            If powerCounter > 100 Then
                PowerDown()
            End If
        End If
        CheckBeatLevel()

    End Sub
    Private Sub PowerUp()
        If Not (ghoststate(0) = INHOME) Then
            ghostIsKillable(0) = True
            ghost(0).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghostscared.bmp")
        End If
        If Not (ghoststate(1) = INHOME) Then
            ghostIsKillable(1) = True
            ghost(1).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghostscared.bmp")
        End If
        If Not (ghoststate(2) = INHOME) Then
            ghostIsKillable(2) = True
            ghost(2).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghostscared.bmp")
        End If
        If Not (ghoststate(3) = INHOME) Then
            ghostIsKillable(3) = True
            ghost(3).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghostscared.bmp")
        End If
        youIsPoweredUp = True
    End Sub
    Private Sub PowerDown()
        youIsPoweredUp = False
        ghost(0).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghost0L.bmp")
        ghost(1).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghost3L.bmp")
        ghost(2).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghost1L.bmp")
        ghost(3).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghost2L.bmp")
        For index = 0 To 3
            ghostIsKillable(index) = False
        Next index
        powerCounter = 0
    End Sub
    Private Sub KillGhost(ByVal whichGhost As Integer)
        If whichGhost = 0 Then
            ghost(0).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghost0L.bmp")
            ghost0.Left = 333
            ghost0.Top = 253
        End If
        If whichGhost = 1 Then
            ghost(1).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghost3L.bmp")
            ghost1.Left = 392
            ghost1.Top = 253
        End If
        If whichGhost = 2 Then
            ghost(2).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghost1L.bmp")
            ghost2.Left = 333
            ghost2.Top = 312
        End If
        If whichGhost = 3 Then
            ghost(3).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\ghosts\ghost2L.bmp")
            ghost3.Left = 392
            ghost3.Top = 312
        End If
        ghostIsKillable(whichGhost) = False
        ghoststate(whichGhost) = INHOME
    End Sub
    Private Sub KillPacman()
        Dim index As Integer
        If deaths < 3 Then
            Timer1.Stop()
            lives(deaths).Visible = False
            deaths = deaths + 1
            youdieform.ShowDialog()
            resetlevel()
            Timer1.Start()
        Else
            If currentHighscore < score Then
                YouGotTheHighscore()
                scoreFile = My.Computer.FileSystem.OpenTextFileWriter(IO.Path.GetDirectoryName(Application.ExecutablePath) & "highscore.txt", False)
                scoreFile.Write(score)
                scoreFile.Close()
                currentHighscore = My.Computer.FileSystem.ReadAllText(IO.Path.GetDirectoryName(Application.ExecutablePath) & "highscore.txt")
                highscoreValue.Text = currentHighscore
            End If
            Timer1.Stop()
            GameOver.ShowDialog()
            resetlevel()
            PowerPelletSet()
            deaths = 0
            lives(0).Visible = True
            lives(1).Visible = True
            lives(2).Visible = True
            numpelletseaten = 0
            For index = 0 To NUMPELLETS
                pellet(index).Visible = True
            Next index
            score = 0
            Timer1.Start()
        End If
    End Sub
    Private Sub CheckBeatLevel()
        Dim index As Integer
        Dim pelletIndex As Integer
        For index = 0 To NUMPELLETS
            If touching(Pacman, pellet(index)) And pellet(index).Visible = True Then
                pellet(index).Visible = False
                numpelletseaten = numpelletseaten + 1
                score = score + 1
                If numpelletseaten = NUMPELLETS + 1 Then
                    Timer1.Stop()
                    youwinform.ShowDialog()
                    deaths = 0
                    lives(0).Visible = True
                    lives(1).Visible = True
                    lives(2).Visible = True
                    PowerDown()
                    For pelletIndex = 0 To NUMPELLETS
                        pellet(pelletIndex).Visible = True
                    Next pelletIndex
                    PowerPelletSet()
                    numpelletseaten = 0
                    resetlevel()
                    Timer1.Start()
                End If
            End If
        Next index
    End Sub
    Private Sub chasepacman(ByVal ghostindex As Integer)
        Dim xdis As Integer
        Dim ydis As Integer
        xdis = Math.Abs(ghost(ghostindex).Left - Pacman.Left)
        ydis = Math.Abs(ghost(ghostindex).Top - Pacman.Top)
        If xdis > ydis Then
            If Pacman.Left < ghost(ghostindex).Left Then
                ghostdir(ghostindex) = Keys.Left
            ElseIf Pacman.Left > ghost(ghostindex).Left Then
                ghostdir(ghostindex) = Keys.Right
            End If
        End If
        If xdis < ydis Then
            If Pacman.Top < ghost(ghostindex).Top Then
                ghostdir(ghostindex) = Keys.Up
            ElseIf Pacman.Top > ghost(ghostindex).Top Then
                ghostdir(ghostindex) = Keys.Down
            End If
        End If
        For index = 0 To 3
            If touching(ghost(index), ghost(ghostindex)) And index <> ghostindex Then
                If ghostdir(index) = ghostdir(ghostindex) Then
                    If xdis < ydis Then
                        If Pacman.Left < ghost(ghostindex).Left Then
                            ghostdir(ghostindex) = Keys.Left
                            ghost(ghostindex).Left = ghost(index).Left - ghost(ghostindex).Width
                        ElseIf Pacman.Left > ghost(ghostindex).Left Then
                            ghostdir(ghostindex) = Keys.Right
                            ghost(ghostindex).Left = ghost(index).Left + ghost(ghostindex).Width
                        End If
                    End If
                    If xdis > ydis Then
                        If Pacman.Top < ghost(ghostindex).Top Then
                            ghostdir(ghostindex) = Keys.Up
                            ghost(ghostindex).Top = ghost(index).Top - ghost(ghostindex).Height
                        ElseIf Pacman.Top > ghost(ghostindex).Top Then
                            ghostdir(ghostindex) = Keys.Down
                            ghost(ghostindex).Top = ghost(index).Top + ghost(ghostindex).Height
                        End If
                    End If
                End If
            End If
        Next index
    End Sub
    Private Function at_intersection(ByVal ghostindex As Integer)
        Dim index As Integer
        For index = 0 To 3
            If touching(ghost(ghostindex), horzroad0) And touching(ghost(ghostindex), vertroad(index)) Then
                Return True
            ElseIf touching(ghost(ghostindex), horzroad1) And touching(ghost(ghostindex), vertroad(index)) Then
                Return True
            End If
        Next index
        Return False
    End Function
    Private Function touching(ByVal object1 As PictureBox, ByVal object2 As PictureBox)
        If object1.Right > object2.Left And object1.Left < object2.Right Then
            If object1.Top < object2.Bottom And object1.Bottom > object2.Top Then
                Return True
            End If
        End If
        Return False
    End Function
End Class
