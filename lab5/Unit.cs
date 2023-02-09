using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace lab5
{
    abstract class Unit
    {
        protected int age; //возраст юнита
        protected int x, y, z;//колличество генов каждого типа
        protected Color color;//цвет
        protected int xk, yk;//координаты

        //свойства

        public int Age
        {
            set { age = value; }
            get { return age; }
        }

        public int X
        {
            set { x = value; }
            get { return x; }
        }

        public int Y
        {
            set { y = value; }
            get { return y; }
        }

        public int Z
        {
            set { z = value; }
            get { return z; }
        }

        public int XK
        {
            set { xk = value; }
            get { return xk; }
        }

        public int YK
        {
            set { yk = value; }
            get { return yk; }
        }

        public Color Color
        {
            set { color = value; }
            get { return color; }
        }

        // абстрактный метод обязательно должен реализовываться дочерними классами
        public abstract void Paint(object sender, PaintEventArgs e);//отрисовка юнита
        public abstract char GetKid();//возвращает ген, который передается от этого юнита потомству
        public abstract string GetGender();//возвращает строчку с генокодом юнита
        public abstract int GetAge();//возвращает возраст юнита
        public abstract void AgeUp();//прибавляет юниту один год
        public abstract int GetGen();//возвращает номер пола
                
    }
}
