using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Cas
{
    public partial class Form1 : Form
    {
        // Список символов
        string[] symbols = { "🍒", "🍋", "🍊", "🍉", "⭐", "7️⃣" };
        Random rand = new Random();

        // Счётчики
        int tickCount1 = 0;
        int tickCount2 = 0;
        int tickCount3 = 0;

        public Form1()
        {
            InitializeComponent();

            // Подключаем обработчики таймеров
            timer1.Tick += timer1_Tick;
            timer2.Tick += timer2_Tick;
            timer3.Tick += timer3_Tick;

            // Подключаем кнопку
            button1.Click += button1_Click;
        }

        // Метод получения случайного символа
        private string GetRandomSymbol()
        {
            return symbols[rand.Next(symbols.Length)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            tickCount1 = tickCount2 = tickCount3 = 0;

            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tickCount1++;
            label1.Text = GetRandomSymbol();

            if (tickCount1 >= 20)
                timer1.Stop();

            CheckIfFinished();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tickCount2++;
            label2.Text = GetRandomSymbol();

            if (tickCount2 >= 30)
                timer2.Stop();

            CheckIfFinished();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            tickCount3++;
            label3.Text = GetRandomSymbol();

            if (tickCount3 >= 40)
                timer3.Stop();

            CheckIfFinished();
        }

        private void CheckIfFinished()
        {
            if (!timer1.Enabled && !timer2.Enabled && !timer3.Enabled)
            {
                button1.Enabled = true;

                if (label1.Text == label2.Text && label2.Text == label3.Text)
                {
                    MessageBox.Show("Вы выиграли!", "Поздравляем");
                }
                else
                {
                    MessageBox.Show("Попробуйте ещё раз!", "Не повезло");
                }
            }
        }
    }
}
