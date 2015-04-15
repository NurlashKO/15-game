using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Game : Form
    {
        const int sz = 120;
        string Difficult;
        Board board;
        PictureBox[] Cells;
        int n;
        Welcome frm;

        public Game()
        {
            InitializeComponent();
            frm = new Welcome();
            frm.ShowDialog();
            
            if (frm.radioButton1.Checked) Difficult = frm.radioButton1.Tag.ToString();
            if (frm.radioButton2.Checked) Difficult = frm.radioButton2.Tag.ToString();
            if (frm.radioButton3.Checked) Difficult = frm.radioButton3.Tag.ToString();
            board = new Board();
            board.gen(Convert.ToInt32(Difficult));
            n = Board.n;
            this.Size = new Size(sz * n + 18, sz * n + 40);
            Cells = new PictureBox[n * n];
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void move(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    board.moveLeft();
                    break;
                case Keys.Right:
                    board.moveRight();
                    break;
                case Keys.Up:
                    board.moveUp();
                    break;
                case Keys.Down:
                    board.moveDown();
                    break;
            }
        }

        void showBoard()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (board.cell[i, j] == n * n - 1)
                        continue;
                    int p = board.cell[i, j];
                    Cells[p].Location = new Point(j * sz, i * sz);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (frm.DialogResult != DialogResult.OK) Close();
            Bitmap btm = frm.picture;
            btm = (Bitmap)btm.GetThumbnailImage(sz * n, sz * n, null, IntPtr.Zero);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == n - 1 && j == n - 1) break;
                    Cells[i * n + j] = new PictureBox();
                    Cells[i * n + j].Parent = this;
                    Cells[i * n + j].Size = new Size(sz, sz);
                    Cells[i * n + j].Image = btm.Clone(new Rectangle(j * sz, i * sz, sz, sz), btm.PixelFormat);
                }
            }
            showBoard();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    board.moveLeft();
                    break;
                case Keys.Right:
                    board.moveRight();
                    break;
                case Keys.Up:
                    board.moveUp();
                    break;
                case Keys.Down:
                    board.moveDown();
                    break;
            }
            showBoard();
            if (board.isWon())
            {
                MessageBox.Show("Yeahoo!!!\nGood Job ^_^");
                Close();
            }
        }
    }
}
