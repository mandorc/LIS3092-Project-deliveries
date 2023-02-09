using System.Numerics;
using System.Windows.Forms;

namespace Pac_Man
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        int direction = 0; // 0 = derecha, 1 = arriba, 2 = izquierda, 3 = abajo
        private void moveGhost()
        {

            int x = ghostImage.Location.X;
            int y = ghostImage.Location.Y;


            if (direction == 0)
            {
                if (x < this.Width - 30 - ghostImage.Width)
                {
                    x = x + 10;
                    ghostImage.Location = new Point(x, y);
                }
                else
                {
                    direction = 1;
                    Image imagen = ghostImage.Image;
                    imagen.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    ghostImage.Image = imagen;
                }
            }
            else if (direction == 1)
            {
                if (y > 10)
                {
                    y = y - 10;
                    ghostImage.Location = new Point(x, y);
                }
                else
                {
                    direction = 2;
                    Image imagen = ghostImage.Image;
                    imagen.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    ghostImage.Image = imagen;
                }
            }
            else if (direction == 2)
            {
                if (x > 20)
                {
                    x = x - 10;
                    ghostImage.Location = new Point(x, y);
                }
                else
                {
                    direction = 3;
                    Image imagen = ghostImage.Image;
                    imagen.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    ghostImage.Image = imagen;
                }
            }
            else if (direction == 3)
            {
                if (y < this.Height - 60 - ghostImage.Height)
                {
                    y = y + 10;
                    ghostImage.Location = new Point(x, y);
                }
                else
                {
                    direction = 0;
                    Image imagen = ghostImage.Image;
                    imagen.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    ghostImage.Image = imagen;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveGhost();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            GameScene game = new GameScene();
            game.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutFrame about = new AboutFrame();
            about.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right )
            {
                Console.WriteLine("presionada menu");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SettingsForm settings = new SettingsForm();
            //settings.Show();
        }
    }
}