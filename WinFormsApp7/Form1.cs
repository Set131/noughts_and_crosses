using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        int x = 3;
        bool play = false;
        int num_btn = 0;
        List<Button> field;
        int result_counter = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Хрестики-нолики (Героєв К.М. ІПЗ 21)";
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (comboBox_begin.Text != "")
            {
                btn_start.Enabled = false;
                comboBox_begin.Enabled = false;
                play = true;
                field = new List<Button>();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        num_btn++;
                        var tmp = new Button()
                        {
                            Height = 100,
                            Width = 100,
                            Location = new Point(5 + j * (100 + 5), 5 + i * (100 + 5)),
                            BackColor = Color.BlueViolet,
                            ForeColor = Color.GreenYellow,
                            Font = new Font("Arial", 30, FontStyle.Bold),
                            Name = $"btn_game{num_btn}"
                        };
                        tmp.Click += Btn_Click;
                        field.Add(tmp);
                        Controls.Add(tmp);
                    }
                }

                if (comboBox_begin.Text == "Починає комп'ютер")
                    ComputerMove();
            }
            else
            {
                MessageBox.Show("Визначтесь з параметрами гри");
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (play)
            {
                Button clickedButton = (Button)sender;
                if (clickedButton.Text == "")
                {
                    clickedButton.Text = "X";
                    CheckGameState();
                    result_counter++;
                    if (play)
                        ComputerMove();
                }
            }
        }

        private void ComputerMove()
        {
            var emptyButtons = field.Where(btn => btn.Text == "").ToList();
            if (emptyButtons.Any())
            {
                if (result_counter == 0)
                {
                    var random = new Random();
                    int index = random.Next(emptyButtons.Count);
                    var computerButton = emptyButtons[index];
                    computerButton.Text = "O";
                    result_counter++;
                    CheckGameState();
                }
                else
                {
                    Button bestMove = FindBestMove();
                    if (bestMove != null)
                    {
                        bestMove.Text = "O";
                        result_counter++;
                        CheckGameState();
                    }
                }
            }
        }

        private Button FindBestMove()
        {
            int bestScore = int.MinValue;
            Button bestMove = null;

            foreach (var emptyButton in field.Where(btn => btn.Text == ""))
            {
                emptyButton.Text = "O";
                int score = Minimax(emptyButton, false, 0);
                emptyButton.Text = "";

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = emptyButton;
                }
            }

            return bestMove;
        }

        private int Minimax(Button button, bool isMaximizing, int depth)
        {
            if (CheckWin("O"))
            {
                return 10 - depth;
            }
            else if (CheckWin("X"))
            {
                return depth - 10;
            }
            else if (CheckDraw())
            {
                return 0;
            }

            int bestScore = isMaximizing ? int.MinValue : int.MaxValue;
            foreach (var emptyButton in field.Where(btn => btn.Text == ""))
            {
                emptyButton.Text = isMaximizing ? "O" : "X";
                int score = Minimax(emptyButton, !isMaximizing, depth + 1);
                emptyButton.Text = "";

                if (isMaximizing)
                    bestScore = Math.Max(bestScore, score);
                else
                    bestScore = Math.Min(bestScore, score);
            }

            return bestScore;
        }

        private bool CheckWin(string player)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < num_btn / x; j++)
                {
                    if (field[i + j * x].Text != player)
                        break;
                    if (j == num_btn / x - 1)
                        return true;
                }
            }

            if (x == 3)
            {
                if (field[0].Text == player && field[4].Text == player && field[8].Text == player)
                    return true;
                if (field[2].Text == player && field[4].Text == player && field[6].Text == player)
                    return true;
            }

            return false;
        }

        private bool CheckDraw()
        {
            return !field.Any(btn => btn.Text == "");
        }

        private void AddNewRow()
        {
            for (int j = 0; j < x; j++)
            {
                num_btn++;
                var tmp = new Button()
                {
                    Height = 100,
                    Width = 100,
                    Location = new Point(5 + j * (100 + 5), 320),
                    BackColor = Color.BlueViolet,
                    ForeColor = Color.GreenYellow,
                    Font = new Font("Arial", 30, FontStyle.Bold),
                    Name = $"btn_game{num_btn}"
                };
                tmp.Click += Btn_Click;
                field.Add(tmp);
                Controls.Add(tmp);
            }
        }

        private void CheckGameState()
        {
            string[,] buttons = new string[x, num_btn / x];
            int count = 0;

            if (x == 3)
            {
                for (int i = 0; i < num_btn / x; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        buttons[j, i] = field[count++].Text;
                    }
                }

                for (int i = 0; i < num_btn / x; i++)
                {
                    if (buttons[0, i] == buttons[1, i] && buttons[1, i] == buttons[2, i] && buttons[0, i] != "")
                    {
                        MessageBox.Show($"{buttons[0, i]} переміг!");
                        play = false;
                        return;
                    }
                }
                for (int j = 0; j < x; j++)
                {
                    if (buttons[j, 0] == buttons[j, 1] && buttons[j, 1] == buttons[j, 2] && buttons[j, 0] != "")
                    {
                        MessageBox.Show($"{buttons[j, 0]} переміг!");
                        play = false;
                        return;
                    }
                }
                if (buttons[0, 0] == buttons[1, 1] && buttons[1, 1] == buttons[2, 2] && buttons[0, 0] != "")
                {
                    MessageBox.Show($"{buttons[0, 0]} переміг!");
                    play = false;
                    return;
                }
                if (buttons[0, 2] == buttons[1, 1] && buttons[1, 1] == buttons[2, 0] && buttons[0, 2] != "")
                {
                    MessageBox.Show($"{buttons[0, 2]} переміг!");
                    play = false;
                    return;
                }
            }

            if (!buttons.Cast<string>().Any(btn => btn == ""))
            {
                if (!field.Any(btn => btn.Text == ""))
                {
                    if (result_counter < 10)
                    {
                        AddNewRow();
                        x = 4;
                        field.AddRange(Controls.OfType<Button>().Where(btn => btn.Name.StartsWith("btn_game") && !field.Contains(btn)));
                    }
                }
                if (!field.Any(btn => btn.Text == ""))
                {
                    MessageBox.Show("Нічия!");
                    play = false;
                }
            }
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила такі ж, як і в звичайних Хрестики-нолики, " +
                "але якщо все поле заповнене і переможця не має, " +
                "створюється ще один ряд поля, для продовження гри.");
        }
    }
}