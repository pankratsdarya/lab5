using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace lab5
{
    class Gen1 : Unit
    {
        public Gen1(bool newgen, int unitage, int Xk, int Yk)//конструктор создает определенного юнита
        {
            age = unitage;
            x = 2;
            if (newgen == true) { y = 1; z = 0; }
            else { z = 1; y = 0; }
            color = Color.Blue;
            xk = Xk;
            yk = Yk;
        }

        public Gen1(int Xk, int Yk)//конструктор создает случайного юнита
        {
            double k;
            Random rand;
            rand = new Random();
            age = rand.Next(0, 100);
            x = 2;
            k = rand.NextDouble();
            if (k < 0.5) { y = 1; z = 0; }
            else { z = 1; y = 0; }
            color = Color.Blue;
            xk = Xk;
            yk = Yk;
        }

        public override void Paint(object sender, PaintEventArgs e)//отрисовка юнита
        {
            e.Graphics.DrawEllipse(new Pen(color, 3), xk - 3, yk - 3, 6, 6);
            e.Graphics.DrawEllipse(new Pen(Color.Black, 1), xk - 4, yk - 4, 8, 8);
        }

        public override char GetKid()//возвращает ген, который передается от этого юнита потомству
        {
            double k;
            Random rand;
            rand = new Random();
            k = rand.NextDouble();
            if (k < 0.1) return 'Y';
            else return 'X';
        }

        public override string GetGender()//возвращает строчку с генокодом юнита
        {
            string k;
            if (y == 1) k = "XXY";
            else k = "XXZ";
            return k;
        }

        public override int GetAge()//возвращает возраст юнита
        {
            return age;
        }

        public override void AgeUp()//прибавляет юниту один год
        {
            age++;
        }

        public override int GetGen()//возвращает номер пола
        {
            return 1;
        }


    }
}
