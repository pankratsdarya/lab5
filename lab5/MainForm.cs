using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Resources;

namespace lab5
{
    public partial class MainForm : Form
    {
        private Random rand;
        List<Unit> Children;
        List<Unit> Singles;
        List<Unit> Family;
        List<Unit> Old;
        List<Unit> Fam;
        int gencount1, gencount2, gencount3, gencount4, gencount5;
        int beginall;




        public MainForm(int genone, int gentwo, int genthree, int genfour, int genfive)
        {
            InitializeComponent();
            rand = new Random();
            beginall = genone + gentwo + genthree + genfour + genfive;
            Children = new List<Unit>(10 * beginall);
            Singles = new List<Unit>(30 * beginall);
            Family = new List<Unit>(30 * beginall);
            Old = new List<Unit>(20 * beginall);
            Fam = new List<Unit>(3);
            gencount1 = genone;
            gencount2 = gentwo;
            gencount3 = genthree;
            gencount4 = genfour;
            gencount5 = genfive;

            int x, y;
            for (int i = 0; i < beginall ; i++)
            {
                int count = 0;

                if (genone > i)
                {
                    Gen1 A;
                    x = rand.Next(0, pictureBox1.Width);
                    y = rand.Next(0, pictureBox1.Height);
                    A = new Gen1(x, y);
                    if (A.GetAge() < 18) Children.Add(A);
                    else if (A.GetAge() < 70) Singles.Add(A);
                    else Old.Add(A);
                    Console.WriteLine("создан объект типа Gen1");
                    this.Refresh();
                }
                else count++;

                if (gentwo > i)
                {
                    Gen2 A;
                    x = rand.Next(0, pictureBox1.Width);
                    y = rand.Next(0, pictureBox1.Height);
                    A = new Gen2(x, y);
                    if (A.GetAge() < 18) Children.Add(A);
                    else if (A.GetAge() < 70) Singles.Add(A);
                    else Old.Add(A);
                    Console.WriteLine("создан объект типа Gen2");
                    this.Refresh();
                }
                else count++;

                if (genthree > i)
                {
                    Gen3 A;
                    x = rand.Next(0, pictureBox1.Width);
                    y = rand.Next(0, pictureBox1.Height);
                    A = new Gen3(x, y);
                    if (A.GetAge() < 18) Children.Add(A);
                    else if (A.GetAge() < 70) Singles.Add(A);
                    else Old.Add(A);
                    Console.WriteLine("создан объект типа Gen3");
                    this.Refresh();
                }
                else count++;

                if (genfour > i)
                {
                    Gen4 A;
                    x = rand.Next(0, pictureBox1.Width);
                    y = rand.Next(0, pictureBox1.Height);
                    A = new Gen4(x, y);
                    if (A.GetAge() < 18) Children.Add(A);
                    else if (A.GetAge() < 70) Singles.Add(A);
                    else Old.Add(A);
                    Console.WriteLine("создан объект типа Gen4");
                    this.Refresh();
                }
                else count++;

                if (genfive > i)
                {
                    Gen5 A;
                    x = rand.Next(0, ClientSize.Width);
                    y = rand.Next(0, ClientSize.Height);
                    A = new Gen5(x, y);
                    if (A.GetAge() < 18) Children.Add(A);
                    else if (A.GetAge() < 70) Singles.Add(A);
                    else Old.Add(A);
                    Console.WriteLine("создан объект типа Gen5");
                    this.Refresh();
                }
                else count++;

                if (count == 5) i = beginall;
            }
            Console.WriteLine("\n\n\n...И жизнь на планете забурлила...");            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = " " + gencount1;
            label7.Text = " " + gencount2;
            label8.Text = " " + gencount3;
            label9.Text = " " + gencount4;
            label10.Text = " " + gencount5;

            int countall = gencount1 + gencount2 + gencount3 + gencount4 + gencount5;
            if (countall == (30 * beginall))
            {
                (sender as Timer).Enabled = false;
                Console.WriteLine("К сожалению раса Андромеды слишком расплодилась, привлекла внимание Галактического правительства и была уничтожена как источник опасности.");
                if (MessageBox.Show("К сожалению раса Андромеды слишком расплодилась, привлекла внимание Галактического правительства и была уничтожена как источник опасности.\n\nПопробовать еще раз?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Restart();
                Application.Exit();
            }

            if (countall == 0)
            {
                (sender as Timer).Enabled = false;
                Console.WriteLine("К сожалению раса Андромеды вымерла.");
                if (MessageBox.Show("К сожалению раса Андромеды вымерла.\n\nПопробовать еще раз?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Restart();
                Application.Exit();
            }

            if (Children.Count != 0)
            {
                for (int i = 0; i < Children.Count; i++)
                {
                    if (Children[i].GetAge() > 18)
                    {
                        Singles.Add(Children[i]);
                        Children.RemoveAt(i);
                    }
                    else Children[i].AgeUp();
                    this.Refresh();
                }                
            }

            if (Singles.Count != 0)
            {                
                for (int i = 0; i < Singles.Count; i++)
                {
                    double check = rand.NextDouble();
                    if (Singles[i].GetAge() > 70)
                    {
                        Old.Add(Singles[i]);
                        Singles.RemoveAt(i);                        
                    }
                    else if (check < 0.5)
                    {
                        Family.Add(Singles[i]);
                        Fam.Add(Singles[i]);
                        Singles.RemoveAt(i);
                        if (Fam.Count == 3)
                        {
                            Console.WriteLine("Юниты "+Fam[0].GetGender()+", "+Fam[1].GetGender()+" и "+Fam[2].GetGender()+" объединились для создания семьи. Поздравляем.");
                            Fam.RemoveRange(0, 3);
                        }
                    }
                    else Singles[i].AgeUp();
                }                
            }

            if (Old.Count != 0)
            {
                for (int i = 0; i < Old.Count; i++)
                {
                    double check = rand.NextDouble();
                    if ((check < 0.05) || (Old[i].GetAge() == 100))
                    {
                        switch (Old[i].GetGen())
                        {
                            case 1:
                                gencount1--;
                                break;
                            case 2:
                                gencount2--;
                                break;
                            case 3:
                                gencount3--;
                                break;
                            case 4:
                                gencount4--;
                                break;
                            case 5:
                                gencount5--;
                                break;
                        }
                        Console.WriteLine("Юнит "+Old[i].GetGender()+" скончался в возрасте "+Old[i].GetAge()+" лет. Скорбим.");
                        Old.RemoveAt(i);
                        this.Refresh();
                    }
                    else Old[i].AgeUp();
                }         
            }

            if (Family.Count != 0)
            {
                for (int i = 0; (3*i+5) < Family.Count; i++)
                {
                    double check1 = rand.NextDouble();
                    double check2 = rand.NextDouble();
                    double check3 = rand.NextDouble();
                    if (Family[3 * i + 1].GetAge() > 70)
                    {
                        Old.Add(Family[3 * i + 1]);
                        Singles.Add(Family[3 * i + 2]);
                        Singles.Add(Family[3 * i + 3]);
                        Family.RemoveAt(3 * i + 1);
                        Family.RemoveAt(3 * i + 2);
                        Family.RemoveAt(3 * i + 3);
                    }
                    else if (Family[3 * i + 2].GetAge() > 70)
                    {
                        Singles.Add(Family[3 * i + 1]);
                        Old.Add(Family[3 * i + 2]);
                        Singles.Add(Family[3 * i + 3]);
                        Family.RemoveAt(3 * i + 1);
                        Family.RemoveAt(3 * i + 2);
                        Family.RemoveAt(3 * i + 3);
                    }
                    else if (Family[3 * i + 3].GetAge() > 70)
                    {
                        Singles.Add(Family[3 * i + 1]);
                        Singles.Add(Family[3 * i + 2]);
                        Old.Add(Family[3 * i + 3]);
                        Family.RemoveAt(3 * i + 1);
                        Family.RemoveAt(3 * i + 2);
                        Family.RemoveAt(3 * i + 3);
                    }
                    else if ((check1 > 0.3) && (check2 > 0.3) && (check3 > 0.3))
                    {
                        int chx = 0, chy = 0, chz = 0;
                        int x, y;
                        x = rand.Next(0, pictureBox1.Width);
                        y = rand.Next(0, pictureBox1.Height);
                        for (int j = 1; j < 4; j++)
                        {
                            switch (Family[3 * i + j].GetKid())
                            {
                                case 'X':
                                    chx++;
                                    break;
                                case 'Y':
                                    chy++;
                                    break;
                                case 'Z':
                                    chz++;
                                    break;
                            }
                        }
                        if (chx == 3) { Children.Add(new Gen5(true, false, false, 0, x, y)); gencount5++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок XXX. Поздравляем счастливых родителей."); }
                        else if (chy == 3) { Children.Add(new Gen5(false, true, false, 0, x, y)); gencount5++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок YYY. Поздравляем счастливых родителей."); }
                        else if (chz == 3) { Children.Add(new Gen5(false, false, true, 0, x, y)); gencount5++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок ZZZ. Поздравляем счастливых родителей."); }
                        else if (chx == 2)
                        {
                            if (chy == 1) { Children.Add(new Gen1(true, 0, x, y)); gencount1++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок XXY. Поздравляем счастливых родителей."); }
                            else { Children.Add(new Gen1(false, 0, x, y)); gencount1++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок XXZ. Поздравляем счастливых родителей."); }
                        }
                        else if (chy == 2)
                        {
                            if (chz == 1) { Children.Add(new Gen2(true, 0, x, y)); gencount2++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок YYX. Поздравляем счастливых родителей."); }
                            else { Children.Add(new Gen2(false, 0, x, y)); gencount2++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок YYZ. Поздравляем счастливых родителей."); }
                        }
                        else if (chz == 2)
                        {
                            if (chx == 1) { Children.Add(new Gen3(true, 0, x, y)); gencount3++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок ZZX. Поздравляем счастливых родителей."); }
                            else { Children.Add(new Gen3(false, 0, x, y)); gencount3++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок ZZY. Поздравляем счастливых родителей."); }
                        }
                        else { Children.Add(new Gen4(0, x, y)); gencount4++; Console.WriteLine("В семье юнитов " + Family[3 * i + 1].GetGender() + ", " + Family[3 * i + 2].GetGender() + " и " + Family[3 * i + 3].GetGender() + " родился ребенок XYZ. Поздравляем счастливых родителей."); }
                        
                        Family[3 * i + 1].AgeUp();
                        Family[3 * i + 2].AgeUp();
                        Family[3 * i + 3].AgeUp();
                    }
                    else
                    {
                        Family[3 * i + 1].AgeUp();
                        Family[3 * i + 2].AgeUp();
                        Family[3 * i + 3].AgeUp();
                    }

                }
            }
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Children.Count != 0)
                foreach (Unit thing in Children)
                {
                    thing.Paint(sender, e);
                }

            if (Singles.Count != 0)
                foreach (Unit thing in Singles)
                {
                    thing.Paint(sender, e);
                }

            if (Family.Count != 0)
                foreach (Unit thing in Family)
                {
                    thing.Paint(sender, e);
                }

            if (Old.Count != 0)
                foreach (Unit thing in Old)
                {
                    thing.Paint(sender, e);
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                button1.Text = "Продолжить";
                Console.WriteLine("----------Пауза----------");
            }
            else
            {
                timer1.Enabled = true;
                button1.Text = "Пауза";               
            }
        }
    }
}
