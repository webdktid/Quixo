using System;
using System.Windows.Forms;
using Quixo.Models;


namespace Quixo
{
    public partial class FormMain : Form
    {
        private Control _fromControl;
        private Control _toControl;

        public FormMain()
        {
            InitializeComponent();
            Game.SetupGame();
        }


        private void DrawBoard()
        {




            for (int i = 0; i < Game.Board.Pieces.Count; i++)
            {

                string label = "";
                switch (Game.Board.Pieces[i].Face)
                {
                    case BoardPieceFace.Circle:
                        label = "O";
                        break;
                    case BoardPieceFace.Cross:
                        label = "X";
                        break;
                    case BoardPieceFace.Clear:
                        label = "";
                        break;
                }

                Controls["Button" + i].Text = label;
                labelPlayer.Text = Game.Activeplayer.Name;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Game.AutoMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            Game.NextPlayer();
            DrawBoard();

        }

        private void button_Click(object sender, EventArgs e)
        {
            if (_fromControl == null)
            {
                _fromControl = sender as Control;
                return;
            }

            if (_toControl == null)
            {
                _toControl = sender as Control;

                int from = Convert.ToInt32(_fromControl.Name.Replace("button", ""));
                // ReSharper disable once PossibleNullReferenceException
                int to = Convert.ToInt32(_toControl.Name.Replace("button", ""));

                _fromControl = null;
                _toControl = null;
                try
                {
                    Game.Move(from, to);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Game.NextPlayer();
                DrawBoard();
       
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DrawBoard();
        }
    }
}
