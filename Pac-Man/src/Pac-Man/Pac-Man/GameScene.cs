using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Pac_Man
{
    public partial class GameScene : Form
    {
        // Bitmap and graphics
        static Bitmap bmp = new Bitmap(500, 250);
        static Graphics g = Graphics.FromImage(bmp);
        private static int mapWidth = 500;
        private static int mapHeight = 250;

        // Setting up the audios
        private SoundPlayer readySong;
        private SoundPlayer chompSong;
        private SoundPlayer suCoinSong;

        // Counters for timers
        private int contReady        = 0;
        private int ghostYellowTimer = 0;
        private int ghostGreenTimer  = 0;
        private int ghostPinkTimer   = 0;
        private int ghostRedTimer    = 0;

        // characters locations
        private static int[,] pacmanMap = new int[mapWidth, mapHeight];
        private static int playerX, playerY; // Player location
        private static bool playerLeft, playerRight, playerUp, playerDown = false;
        private static int totalCoins;
        // Portals
        private static int port1o, port1d = 0;
        private static int port2o, port2d = 0;
        // Little ghosts
        private static int ghostYellowX,    ghostYellowY;
        private static int ghostGreenX,     ghostGreenY;
        private static int ghostPinkX,      ghostPinkY;
        private static int ghostRedX,       ghostRedY;
        private static int heavenX,         heavenY;

        // Score and lives
        private int score = 0;
        private int highscore = 0;
        private int ups = 1;
        private int tries = 2;

        // Ghost movements
        bool[] ghostYellowDirection = new bool[4] { false, false, false, false };
        bool[] ghostGreenDirection  = new bool[4] { false, false, false, false };
        bool[] ghostPinkDirection   = new bool[4] { false, false, false, false };
        bool[] ghostRedDirection    = new bool[4] { false, false, false, false };


        static bool pacIsOpen = false;

        public GameScene()
        {
            InitializeComponent();
            InitializeKeyboard();
            InitializeLabels();

            pacClose.Visible= false;
            pacOpen.Visible= false;
            oriPacOpen.Visible = false;

            this.KeyPreview = true;

            //bmp = new Bitmap(500, 250);
            //g = Graphics.FromImage(bmp);
            gameView.Image = bmp;

            DrawMap();

            readySong = new SoundPlayer();
            readySong.SoundLocation = @"C:\Users\arman\Documents\GitHub\UDLAP\LIS3092-Project-deliveries\Pac-Man\Pac-Man\Resources\pacman_beginning.wav";

            chompSong = new SoundPlayer();
            chompSong.SoundLocation = @"C:\Users\arman\Documents\GitHub\UDLAP\LIS3092-Project-deliveries\Pac-Man\Pac-Man\Resources\pacman_chomp.wav";

            suCoinSong = new SoundPlayer();
            suCoinSong.SoundLocation = @"C:\Users\arman\Documents\GitHub\pac-man\src\Pac-Man\Pac-Man\Resources\pacman_eatfruit.wav";


            PlayReadySong();
        }

        // Initialize form labels
        private void InitializeLabels()
        {
            upLabel.Text = ups.ToString();
            scoreLabelInt.Text = score.ToString();
            hScoreInt.Text = highscore.ToString();
        }

        private void PlayReadySong()
        {
            //readySong.Play();
        }

        private void PlayChomb()
        {
            //chompSong.Stop();
            //chompSong.Play();
        }

        private void PlayBigCoin()
        {
            suCoinSong.Stop();
            suCoinSong.Play();
        }
        
        private static void OnPlaybackStopped(object sender, EventArgs e)
        {
            // Código para ejecutar después de que se haya terminado de reproducir el audio
            //Console.WriteLine("Termino la cancion");
        }

        bool right, left, up, down = false;
        bool isHold = false;
        
        // No lista
        private void UpdateGhostPositions(bool[] ghostDirections, int gX, int gY)
        {
            if (ghostDirections[2])
            {
                if (pacmanMap[gX + 1, gY] != 1)
                    ghostYellowX++;
            }
            else if (ghostDirections[3])
            {
                if (pacmanMap[gX - 1, gY] != 1)
                    ghostYellowX--;
            }
            else if (ghostDirections[0])
            {
                if (pacmanMap[gX, gY - 1] != 1)
                    ghostYellowY--;
            }
            else if (ghostDirections[1])
            {
                if (pacmanMap[gX, gY + 1] != 1)
                    ghostYellowY++;
            }
        }
        

        private void UpdatePositions()
        {
            // Player position
            if (right)
            {
                if ((pacmanMap[playerX + 1, playerY] != 1) && (pacmanMap[playerX + 1, playerY] != 4))
                    playerX++;
            }
            else if (left)
            {
                if ((pacmanMap[playerX - 1, playerY] != 1) && (pacmanMap[playerX - 1, playerY] != 4))
                    playerX--;
            }
            else if (up)
            {
                if ((pacmanMap[playerX, playerY - 1] != 1) && (pacmanMap[playerX, playerY - 1] != 4))
                    playerY--;
            }
            else if (down)
            {
                if ((pacmanMap[playerX, playerY + 1] != 1) && (pacmanMap[playerX, playerY + 1] != 4))
                    playerY++;
            }

        }

        private void UpdateValues()
        {
            if (pacmanMap[playerX, playerY] == 2)
            {
                pacmanMap[playerX, playerY] = 0;
                score += 10;
                highscore += 10;
                PlayChomb();
                UpdateCoins();
            }

            else if (pacmanMap[playerX, playerY] == 3)
            {
                pacmanMap[playerX, playerY] = 0;
                score += 20;
                highscore += 20;
                PlayBigCoin();
                UpdateCoins();
                // Start ghosts blues
                superPower = true;
            }

            else if (pacmanMap[playerX, playerY] == 11)
            {
                playerX = port1d-1;
            }
            else if (pacmanMap[playerX, playerY] == 12)
            {
                playerX = port1o+1;
            }
            else if (pacmanMap[playerX, playerY] == 13)
            {
                playerY = port2d-1;
            }
            else if (pacmanMap[playerX, playerY] == 14)
            {
                playerY = port2o+1;
            }

            right = left = up = down = false;
        }

        private void RedrawGhostMap(int ghostX, int ghostY)
        {
            // Normal coins
            if (pacmanMap[ghostX, ghostY] == 2)
            {
                g.FillEllipse(new SolidBrush(Color.Yellow), (ghostX * 10) + 3, (ghostY * 10) + 3, 3, 3);
            }
            // Super coins
            else if (pacmanMap[ghostYellowX, ghostYellowY] == 3)
            {
                g.FillEllipse(new SolidBrush(Color.Yellow), (ghostX * 10) + 2, (ghostY * 10) + 2, 7, 7);
            }
            // Space
            else
            {
                g.FillRectangle(new SolidBrush(Color.Black), ghostX * 10, ghostY * 10, 10, 10);
            }
        }

        private void RedrawMap()
        {
               
            gameView.Image = bmp;
            // Agregar condicion de monedas para fantasmas
            g.FillRectangle(new SolidBrush(Color.Black), playerX * 10, playerY * 10, 10, 10);

            RedrawGhostMap(ghostYellowX, ghostYellowY);

            UpdatePositions();
            UpdateGhostPositions(ghostYellowDirection, ghostYellowX, ghostYellowY);
            UpdateValues();

            // Drawing pacman
            if (pacIsOpen)
            {
                g.DrawImage(pacOpen.Image, new Rectangle(playerX * 10, playerY * 10, 10, 10));
            }
            else
            {
                g.DrawImage(pacClose.Image, new Rectangle(playerX * 10, playerY * 10, 10, 10));
            }

            UpdateScore();

            // Drawing ghosts - Podemos guardar la img actual
            RotateGhosts();
            g.DrawImage(ghostYellowImg.Image, new Rectangle(ghostYellowX * 10, ghostYellowY * 10, 10, 10));
            g.DrawImage(ghostGreenImg.Image, new Rectangle(ghostGreenX * 10, ghostGreenY * 10, 10, 10));
            g.DrawImage(ghostPinkImg.Image, new Rectangle(ghostPinkX * 10, ghostPinkY * 10, 10, 10));
            g.DrawImage(ghostRedImg.Image, new Rectangle(ghostRedX * 10, ghostRedY * 10, 10, 10));
            //g.DrawImage(Resources.yellowGhostRightImg, new Rectangle(ghostYellowX*10, ghostYellowY*10, 10, 10));
            //g.DrawImage(Resources.greenGhostRightImg, new Rectangle(ghostGreenX * 10, ghostGreenY * 10, 10, 10));
            //g.DrawImage(Resources.pinkGhostRightImg, new Rectangle(ghostPinkX * 10, ghostPinkY * 10, 10, 10));
            //g.DrawImage(Resources.redGhostRightImg, new Rectangle(ghostRedX * 10, ghostRedY * 10, 10, 10));
        }
        
        private void UpdateScore()
        {
            scoreLabelInt.Text = score.ToString();
            hScoreInt.Text = highscore.ToString();
        }

        int ygi = 6;
        int ggi, pgi, rgi = 0;

        int[] yellowNextMovements = new int[6];

        // Funcion ghosttimer
        private void ghostTimer_Tick(object sender, EventArgs e)
        {
            int[] pacmanCurrentP = new int[2] { playerX, playerY };

            Manhattan manhattan = new Manhattan();
            manhattan.setMap(pacmanMap);
            RotateGhosts();
            // Agregar los movimientos del pacman
            int[] yellowCurrentP = new int[2] { ghostYellowX, ghostYellowY };
            int[] greenCurrentP = new int[2] { ghostGreenX, ghostGreenY };
            int[] pinkCurrentP = new int[2] { ghostPinkX, ghostPinkY };
            int[] redCurrentP = new int[2] { ghostRedX, ghostRedY };
            // Obtenemos el siguientes movimiento

            

            for (int i = 0; i < ghostYellowDirection.Length; i++)
            {
                ghostYellowDirection[i] = false;
            }
            if (ygi < 6)
            {
                if (yellowNextMovements[ygi] == 2)
                {
                    ghostYellowDirection[0] = true;
                }
                else if (yellowNextMovements[ygi] == 1)
                {
                    ghostYellowDirection[1] = true;
                }
                else if (yellowNextMovements[ygi] == 3)
                {
                    ghostYellowDirection[2] = true;
                }
                else if (yellowNextMovements[ygi] == 4)
                {
                    ghostYellowDirection[3] = true;
                }

                ygi++;
            }
            else
            {
                yellowNextMovements = manhattan.NextMove(yellowCurrentP, pacmanCurrentP, 6);
                ygi = 0;
            }
        }


        private void RedrawPlayer()
        {

            gameView.Image = bmp;

            g.FillRectangle(new SolidBrush(Color.Black), playerX * 10, playerY * 10, 10, 10);

            if (pacIsOpen)
            {
                g.DrawImage(pacClose.Image, new Rectangle(playerX * 10, playerY * 10, 10, 10));
                pacIsOpen = false;
            }
            else
            {
                g.DrawImage(pacOpen.Image, new Rectangle(playerX * 10, playerY * 10, 10, 10));
                pacIsOpen = true;
            }
        }

        // Rotating player when moving
        private void RotatePlayerLeft()
        {
            if (playerLeft == false)
            {
                Bitmap bmp = new Bitmap(oriPacOpen.Image);
                bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pacOpen.Image = bmp;
            }
            
        }

        private void RotatePlayerRight()
        {
            pacOpen.Image = oriPacOpen.Image;
        }

        private void RotatePlayerUp()
        {
            Bitmap bmp = new Bitmap(oriPacOpen.Image);
            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pacOpen.Image = bmp;
        }

        private void RotatePlayerDown()
        {
            Bitmap bmp = new Bitmap(oriPacOpen.Image);
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pacOpen.Image = bmp;
        }
        static bool superPower = false;
        private void RotateGhosts()
        {
            // Yellow ghost rotation
            if (ghostYellowDirection[0])
            {
                ghostYellowImg.Image = Resources.yellowGhostUpImg;
            }
            else if (ghostYellowDirection[1])
            {
                    ghostYellowImg.Image = Resources.yellowGhostDownImg;
            }
            else if (ghostYellowDirection[2])
            {
                ghostYellowImg.Image = Resources.yellowGhostRightImg;
            }
            else if (ghostYellowDirection[3])
            {
                ghostYellowImg.Image = Resources.yellowGhostLeftImg;
            }
            // Green ghost rotation
            if (ghostGreenDirection[0])
            {
                ghostGreenImg.Image = Resources.greenGhostUpImg;
            }
            else if (ghostGreenDirection[1])
            {
                ghostGreenImg.Image = Resources.greenGhostUpImg;
            }
            else if (ghostGreenDirection[2])
            {
                ghostGreenImg.Image = Resources.greenGhostUpImg;
            }
            else 
            {
                ghostGreenImg.Image = Resources.greenGhostUpImg;
            }
            // Pink ghost rotation
            if (ghostPinkDirection[0])
            {
                ghostPinkImg.Image = Resources.pinkGhostUpImg;
            }
            else if (ghostPinkDirection[1])
            {
                ghostPinkImg.Image = Resources.pinkGhostDownImg;
            }
            else if (ghostPinkDirection[2])
            {
                ghostPinkImg.Image = Resources.pinkGhostRightImg;
            }
            else 
            {
                ghostPinkImg.Image = Resources.pinkGhostLeftImg;
            }
            // Red ghost rotation
            if (ghostRedDirection[0])
            {
                ghostRedImg.Image = Resources.redGhostUpImg;
            }
            else if (ghostRedDirection[1])
            {
                ghostRedImg.Image = Resources.redGhostDownImg;
            }
            else if (ghostRedDirection[2])
            {
                ghostRedImg.Image = Resources.redGhostRightImg;
            }
            else
            {
                ghostRedImg.Image = Resources.redGhostLeftImg;
            }

            if (superPower == true)
            {
                ghostYellowImg.Image =  Resources.pacman_weak;
                ghostRedImg.Image =     Resources.pacman_weak;
                ghostPinkImg.Image=     Resources.pacman_weak;
                ghostGreenImg.Image =   Resources.pacman_weak;
            }
        }

        private void DrawMap()
        {
            Pen pen = new Pen(Color.Blue, 1);
            score = 0;

            g.Clear(Color.Black);

            pictureBox1.Height = 10;
            pictureBox1.Width = 10;

            totalCoins = 0;

            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 25; y++)
                {

                    if (Maps.currentMap[y, x] != 1)
                    {
                        // Moneditas
                        if (Maps.currentMap[y, x] == 2)
                        {
                            g.FillEllipse(new SolidBrush(Color.Yellow), (x * 10)+3, (y * 10)+3, 3, 3);
                            pacmanMap[x,y] = 2;
                            totalCoins++;
                        }
                        // Super moneda
                        else if (Maps.currentMap[y, x] == 3)
                        {
                            g.FillEllipse(new SolidBrush(Color.Yellow), (x * 10) + 2, (y * 10) + 2, 7, 7);
                            pacmanMap[x, y] = 3;
                            totalCoins++;
                        }

                        // Puerta enemigos
                        else if (Maps.currentMap[y, x] == 4)
                        {
                            g.FillRectangle(new SolidBrush(Color.Yellow), (x * 10), (y * 10)+3, 10, 2);
                            pacmanMap[x, y] = 4;
                        }

                        // Ubicacion jugador
                        else if (Maps.currentMap[y, x] == 10)
                        {
                            playerX = x;
                            playerY = y;
                            pacmanMap[x, y] = 0;
                        }

                        // Enemigos
                        else if (Maps.currentMap[y, x] == 90)
                        {
                            ghostYellowX = x;
                            ghostYellowY = y;
                            pacmanMap[x, y] = 0;
                        }

                        else if (Maps.currentMap[y, x] == 91)
                        {
                            ghostGreenX = x;
                            ghostGreenY = y;
                            pacmanMap[x, y] = 0;
                        }

                        else if (Maps.currentMap[y, x] == 92)
                        {
                            ghostPinkX = x;
                            ghostPinkY = y;
                            pacmanMap[x, y] = 0;
                        }

                        else if (Maps.currentMap[y, x] == 93)
                        {
                            ghostRedX = x;
                            ghostRedY = y;
                            pacmanMap[x, y] = 0;
                        }

                        else if (Maps.currentMap[y,x] == 94)
                        {
                            heavenX = x;
                            heavenY = y;
                        }

                        // Portal
                        else if (Maps.currentMap[y,x] == 11)
                        {
                            pacmanMap[x,y] = 11;
                            port1o = x;
                        }
                        else if (Maps.currentMap[y, x] == 12)
                        {
                            pacmanMap[x, y] = 12;
                            port1d= x;
                        }
                        else if (Maps.currentMap[y, x] == 13)
                        {
                            pacmanMap[x, y] = 13;
                            port2o = y;
                        }
                        else if (Maps.currentMap[y, x] == 14)
                        {
                            pacmanMap[x, y] = 14;
                            port2d = y;
                        }
                        else
                        {
                            pacmanMap[x, y] = 0;
                        }

                    }
                    // Muros normales
                    else
                    {
                        g.FillRectangle(new SolidBrush(Color.Blue), x * 10,  y* 10, 10, 10);
                        pacmanMap[x,y] = 1;
                    }
                        

                }
            }
            // Pac-Man
            g.DrawImage(pacClose.Image, new Rectangle(playerX * 10, playerY * 10, 10, 10));

            // Yellow ghost
            g.DrawImage(ghostYellowImg.Image, new Rectangle(ghostYellowX * 10, ghostYellowY * 10, 10, 10));
            // Green ghost
            g.DrawImage(ghostGreenImg.Image, new Rectangle(ghostGreenX * 10, ghostGreenY * 10, 10, 10));
            // Pink ghost
            g.DrawImage(ghostPinkImg.Image, new Rectangle(ghostPinkX * 10, ghostPinkY * 10, 10, 10));
            // Red ghost
            g.DrawImage(ghostRedImg.Image, new Rectangle(ghostRedX * 10, ghostRedY * 10, 10, 10));
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartGame()
        {
            gameTimer.Enabled = true;
            gameTimer.Start();
            playerTimer.Enabled = true;
            playerTimer.Start();
        }

        private void GameScene_Load(object sender, EventArgs e)
        {

        }

        private void gameView_Click(object sender, EventArgs e)
        {

        }

        private bool ghostYellowReady = true;
        private bool ghostGreenReady = false;
        private bool ghostPinkReady = false;
        private bool ghostRedReady = false;

        int contSuperPower = 10;
        private void readyTimer_Tick(object sender, EventArgs e)
        {
            if (contReady == 4)
            {
                StartGame();
                //readyTimer.Stop();
                ghostTimer.Enabled = true;
                ghostTimer.Start();
                
                Console.WriteLine("Inicia el juego");
            }

            if (superPower)
            {
                if (contSuperPower != 0)
                {
                    contSuperPower--;
                }
                else
                {
                    contSuperPower = 10;
                    superPower = false;
                }
            }

            if (ghostYellowReady == false)
            {
                ghostYellowTimer++;
                if (ghostYellowTimer == 4)
                {
                    ghostYellowReady = true;
                    ghostYellowTimer = 0;
                } 
            }

            if (ghostGreenReady == false)
            {
                ghostGreenTimer++;
                if (ghostGreenTimer == 8)
                {
                    ghostGreenReady = true;
                    ghostGreenTimer = 0;
                }
            }

            if (ghostPinkReady == false)
            {
                ghostPinkTimer++;
                if (ghostPinkTimer == 12)
                {
                    ghostPinkReady = true;
                    ghostPinkTimer = 0;
                }
            }

            if (ghostRedReady == false)
            {
                ghostRedTimer++;
                if (ghostRedTimer == 16)
                {
                    ghostRedReady = true;
                    ghostRedTimer = 0;
                }
            }

            if (contReady <= 4) 
                contReady++;

        }

        private void playerSoundTimer_Tick(object sender, EventArgs e)
        {
            RedrawPlayer();
        }

        // Funcion gametimer
        private void gameTimer_Tick(object sender, EventArgs e)
        {

            JoystickState state = joystick.GetCurrentState();
            //Console.WriteLine("X: " + state.X + " y: " + state.Y);
            //Console.WriteLine("Coins" + totalCoins);


            if (state.X == 65535)
            {
                //Console.WriteLine("derecha presionada");
                if (!playerRight)
                {
                    RotatePlayerRight();
                    playerRight = true;
                }
                playerLeft = playerDown = playerUp = false;
                right = true;
            }
            else if (state.X == 0)
            {
                //Console.WriteLine("izquierda presionada");
                if (!playerLeft)
                {
                    RotatePlayerLeft();
                    playerLeft = true;
                }

                playerRight = playerDown = playerUp = false;
                left = true;
            }
            else if (state.Y == 0)
            {
                //Console.WriteLine("Arriba presioanda");

                if (!playerUp)
                {
                    RotatePlayerUp();
                    playerUp = true;
                }

                playerRight = playerDown = playerLeft = false;

                up = true;
            }
            else if (state.Y == 65535)
            {
                //Console.WriteLine("derecha presionada");

                if (!playerDown)
                {
                    RotatePlayerDown();
                    playerDown = true;
                }

                playerRight = playerLeft = playerUp = false;

                down = true;
            }
            

            RedrawMap();

            if ((ghostYellowX == playerX) && (ghostYellowY == playerY))
            {
                if (superPower)
                {
                    ghostYellowX = heavenX; ghostYellowY = heavenY;
                    ghostYellowReady = false;
                    score += 50;
                    highscore += 50;
                }
                else
                {
                    Console.WriteLine("Ya perdiste");
                }
                
            }
        }
        // Inicializar control externo

        private static DirectInput directInput = new DirectInput();
        private static Guid joystickGuid = Guid.Empty;
        private static Joystick joystick;

        private void InitializeKeyboard()
        {
            foreach(var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
            }  

            if (joystickGuid == Guid.Empty)
            {
                //
                //Console.WriteLine("estuvo vacio, es joystick");
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                }
            }

            joystick = new Joystick(directInput, joystickGuid);

            Console.WriteLine("El control es {0}", joystickGuid);

            joystick.Properties.BufferSize = 128;

            joystick.Acquire();
        }


        private void UpdateCoins()
        {
            totalCoins--;
            if (totalCoins == 0)
            {
                //Console.WriteLine("Has ganado");
                scoreLabelInt.Text = "0";
                ygi = 6;
                ghostTimer.Enabled = false;
                superPower = false;
                Maps.UpdateMap();
                DrawMap();
                ghostTimer.Enabled = true;
            }
        }

        private void UpdateTries()
        {
            tries--;
            life2.Visible= false;
        }

        private void GameScene_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Right)
            {
                //Console.WriteLine("derecha presionada");
                right = true;
            }
            else if (e.KeyData == Keys.Left)
            {
                //Console.WriteLine("izquierda presionada");
                left = true;
            }
            else if (e.KeyData == Keys.Up)
            {
                //Console.WriteLine("arriba presionada");
            }
            else if (e.KeyData == Keys.Down)
            {
                //Console.WriteLine("abajo presionada");
            }
            //Console.WriteLine(e.KeyCode);
            RedrawMap();
        }
        private void GameScene_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
