using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cas
{

    public partial class Form1 : Form
    {
        Icon icon;

        List<Image> symbolImages = new List<Image>();
        List<string> symbolPaths = new List<string>();
        Random rand = new Random();

        int tickCount1 = 0;
        int tickCount2 = 0;
        int tickCount3 = 0;

        string chosen1 = "", chosen2 = "", chosen3 = "";

        public Form1()
        {
            InitializeComponent();

            // Загружаем изображения из папки
            LoadSymbols();

            // Подключаем обработчики
            timer1.Tick += timer1_Tick;
            timer2.Tick += timer2_Tick;
            timer3.Tick += timer3_Tick;

            button1.Click += button1_Click;
        }

        private void LoadSymbols()
        {
            string imageFolder = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(imageFolder))
            {
                MessageBox.Show("Папка 'Images' не найдена!");
                return;
            }

            foreach (string file in Directory.GetFiles(imageFolder, "*.png"))
            {
                symbolImages.Add(Image.FromFile(file));
                symbolPaths.Add(file);
            }

            if (symbolImages.Count == 0)
            {
                MessageBox.Show("Нет изображений в папке 'Images'!");
            }
        }

        private int GetRandomIndex()
        {
            return rand.Next(symbolImages.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (symbolImages.Count == 0) return;

            button1.Enabled = false;

            tickCount1 = tickCount2 = tickCount3 = 0;

            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tickCount1++;
            int i = GetRandomIndex();
            pictureBox1.Image = symbolImages[i];
            chosen1 = symbolPaths[i];

            if (tickCount1 >= 20)
                timer1.Stop();

            CheckIfFinished();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tickCount2++;
            int i = GetRandomIndex();
            pictureBox2.Image = symbolImages[i];
            chosen2 = symbolPaths[i];

            if (tickCount2 >= 30)
                timer2.Stop();

            CheckIfFinished();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            tickCount3++;
            int i = GetRandomIndex();
            pictureBox3.Image = symbolImages[i];
            chosen3 = symbolPaths[i];

            if (tickCount3 >= 40)
                timer3.Stop();

            CheckIfFinished();
        }

        private void CheckIfFinished()
        {
            if (!timer1.Enabled && !timer2.Enabled && !timer3.Enabled)
            {
                button1.Enabled = true;

                if (chosen1 == chosen2 && chosen2 == chosen3)
                {
                    MessageBox.Show("🎉 Вы выиграли!", "Поздравляем");
                }
                else
                {
                    MessageBox.Show("Попробуйте ещё раз!", "Не повезло");
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
