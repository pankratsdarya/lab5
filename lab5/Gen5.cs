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
    class Gen5: Unit
    {
        public Gen5(bool genX, bool genY, bool genZ, int unitage, int Xk, int Yk)//конструктор создает определенного юнита
        {
            age = unitage;
            if (genX == true) { x = 3; y = 0; z = 0; }
            else if (genY == true) { x = 0; y = 3; z = 0; }
            else { x = 0; y = 0; z = 3; }
            color = Color.Orange;
            xk = Xk;
            yk = Yk;
        }

        public Gen5(int Xk, int Yk)//конструктор создает случайного юнита
        {
            double k;
            Random rand;
            rand = new Random();
            age = rand.Next(0,100);
            k = rand.NextDouble();
            if (k < 0.33) { x = 3; y = 0; z = 0; }
            else if (k < 0.66) { x = 0; y = 3; z = 0; }
            else { x = 0; y = 0; z = 3; }
            color = Color.Orange;
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
            if (x == 3) return 'X';
            else if (y == 3) return 'Y';
            else return 'Z';
        }

        public override string GetGender()//возвращает строчку с генокодом юнита
        {
            string k;
            if (x == 3) k = "XXX";
            else if (y == 3) k = "YYY";
            else k = "ZZZ";
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
            return 5;
        }

    }
}
