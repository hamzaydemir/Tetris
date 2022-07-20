using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int satir = 0;
        int sutun = 5;
        int sayac = 0;
        int sekil = 0;
        int puan = 0;
        int saniye = 0;
        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Enabled = false;

            for (int i = 0; i < 180; i++)                               //tablelayoutpanel i pictureboxlarla dolduruyoruz.
            {
                PictureBox picture = new PictureBox();
                picture.BackColor = Color.Black;
                picture.BackgroundImageLayout = ImageLayout.Zoom;
                TablePanel.Controls.Add(picture);
                picture.Margin = new Padding(1);

            }
        }

        void bittiMi()          //oyunun bitip bitmediğini kontrol eden fonksiyon
        {        
            if (TablePanel.GetControlFromPosition(0, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(1, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(2, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(3, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(4, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(5, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(6, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(7, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(8, 0).BackgroundImage != null ||
                TablePanel.GetControlFromPosition(9, 0).BackgroundImage != null)
            {
                pictureBox2.Enabled = true;
                timer1.Stop();
                süre.Stop();
                puan += saniye;
                MessageBox.Show("Oyun Bitti Puanınız : "+puan.ToString(),"TETRİS");
            }
        }
        void inerkenYaz()       //saniye artarken tetris bloklarını yazıyor.
        {
            if (sekil == 0)     // sekil 0 I şekli.
            {
                    if (sayac < 4)
                    {
                        TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = Properties.Resources.stop;
                        sayac++;
                    }
                    else
                    {
                        TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = Properties.Resources.stop;
                        TablePanel.GetControlFromPosition(sutun, satir - 4).BackgroundImage = null;

                    }
                }
            if (sekil == 1)     //şekil 1 kare şekli.
            {
                if (sayac < 2)
                {
                    TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = Properties.Resources.stop;
                    TablePanel.GetControlFromPosition(sutun + 1, satir).BackgroundImage = Properties.Resources.stop;
                    sayac++;
                }
                else
                {
                    TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = Properties.Resources.stop;
                    TablePanel.GetControlFromPosition(sutun + 1, satir).BackgroundImage = Properties.Resources.stop;
                    TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(sutun + 1, satir - 2).BackgroundImage = null;

                }
            }
            if (sekil == 2)     //şekil 2 L şeklini.
            {

                if (sayac < 3)
                {
                    TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = Properties.Resources.stop;
                    sayac++;
                }
                else
                {
                    TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = Properties.Resources.stop;
                    TablePanel.GetControlFromPosition(sutun, satir - 3).BackgroundImage = null;

                }
                if (satir >= 1)
                {
                    TablePanel.GetControlFromPosition(sutun + 1, satir).BackgroundImage = Properties.Resources.stop;
                    TablePanel.GetControlFromPosition(sutun + 1, satir - 1).BackgroundImage = null;
                }
            }
            if (sekil == 3)     // şekil 3 Z şeklini temsil ediyor.
            {
                if (sayac == 0)
                {
                    TablePanel.GetControlFromPosition(sutun-1, satir).BackgroundImage = Properties.Resources.stop;
                    TablePanel.GetControlFromPosition(sutun , satir).BackgroundImage = Properties.Resources.stop;
                    sayac++;
                }
                if (sayac == 1)
                {
                    TablePanel.GetControlFromPosition(sutun, satir+1).BackgroundImage = Properties.Resources.stop;
                    TablePanel.GetControlFromPosition(sutun + 1, satir+1).BackgroundImage = Properties.Resources.stop;
                    sayac++;
                }
                else
                {
                    if (satir <17)
                    {
                        
                        TablePanel.GetControlFromPosition(sutun - 1, satir).BackgroundImage = Properties.Resources.stop;
                        TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = Properties.Resources.stop;
                        TablePanel.GetControlFromPosition(sutun, satir + 1).BackgroundImage = Properties.Resources.stop;
                        TablePanel.GetControlFromPosition(sutun + 1, satir + 1).BackgroundImage = Properties.Resources.stop;
                        TablePanel.GetControlFromPosition(sutun - 1, satir - 1).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun + 1, satir).BackgroundImage = null;
                    }
                }
            }
        }
        void kontrol()          //aşağı inen tetris bloklarının başka bloğa gelip gelmediğini kontrol ediyoruz.
        {                       //tetris durumunu kontrol ediyoruz. Tetris olan sıraları siliyoruz.
            if (sekil == 0)
            {
                if (satir < 19)
                {
                    if (TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage != null)
                    {
                        
                        satir = 0;
                        sekil = rnd.Next(0, 4);     //random şekil gelmesini sağlıyourz.
                        sayac = 0;
                        sutun = 5;
                        bittiMi();

                    }
                }
            }
            if (sekil == 1)
            {
                if (satir < 19)
                {
                    if (TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage != null ||
                        TablePanel.GetControlFromPosition(sutun + 1, satir).BackgroundImage != null)
                    {
                        
                        satir = 0;
                        sekil = rnd.Next(0, 4);
                        sayac = 0;
                        sutun = 5;
                        bittiMi();

                    }
                }
            }
            if (sekil == 2)
            {
                if (TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage != null ||
                    TablePanel.GetControlFromPosition(sutun + 1, satir).BackgroundImage != null)
                {
                    
                    satir = 0;
                    sekil = rnd.Next(0, 4);
                    sayac = 0;
                    sutun = 5;
                    bittiMi();
                }
            }
            if (sekil == 3)
            {
                if (satir < 16)
                {
                    if (TablePanel.GetControlFromPosition(sutun, satir+1).BackgroundImage != null||
                        TablePanel.GetControlFromPosition(sutun+1, satir+1).BackgroundImage != null)
                    {
                        
                        satir = 0;
                        sekil = rnd.Next(0, 4);
                        sayac = 0;
                        sutun = 5;
                        bittiMi();
                    }

                }
            }
            for (int i = 17; i > 0; i--)    //tetris olma durumuna bakıyoruz
            {
                if (TablePanel.GetControlFromPosition(0, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(1, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(2, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(3, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(4, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(5, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(6, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(7, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(8, i).BackgroundImage != null &&
                    TablePanel.GetControlFromPosition(9, i).BackgroundImage != null)
                {
                    puan += 100;
                    TablePanel.GetControlFromPosition(0, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(1, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(2, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(3, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(4, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(5, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(6, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(7, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(8, i).BackgroundImage = null;
                    TablePanel.GetControlFromPosition(9, i).BackgroundImage = null;

                    for (int j = 16; j > 0; j--)
                    {
                        for (int k = 0; k < 10; k++)
                        {

                            if (TablePanel.GetControlFromPosition(k, j).BackgroundImage != null)
                            {
                                TablePanel.GetControlFromPosition(k, j).BackgroundImage = null;
                                TablePanel.GetControlFromPosition(k, j + 1).BackgroundImage = Properties.Resources.stop;
                            }
                        }
                    }
                }

            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (satir == 18)
            {
                satir = 0;
                sekil = rnd.Next(0, 4);
                sutun = 5;
                sayac = 0;
            }
            
            kontrol();
            inerkenYaz();
            satir++;


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (sutun < 9)
            {
                if (e.KeyCode == Keys.Right)        //sağ ok tuşuna basıldığı zaman blokları 1 sağa taşıyoruz
                {
                    if (satir > 3)
                    {
                        TablePanel.GetControlFromPosition(sutun - 1, satir - 1).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 3).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 4).BackgroundImage = null;

                        if (sekil == 0)
                        {
                            sutun++;
                            TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 3).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 4).BackgroundImage = Properties.Resources.stop;
                        }

                        if (sekil == 1)
                        {
                            if (sutun < 8)
                            {
                                sutun++;
                                TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun + 1, satir - 1).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun + 1, satir - 2).BackgroundImage = Properties.Resources.stop;

                            }
                        }
                        if (sekil == 2)
                        {
                            if (sutun < 8)
                            {
                                sutun++;
                                TablePanel.GetControlFromPosition(sutun + 1, satir - 1).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun, satir - 3).BackgroundImage = Properties.Resources.stop;
                            }
                        }
                        if (sekil == 3)
                        {
                            if (sutun < 8)
                            {
                                sutun++;
                                TablePanel.GetControlFromPosition(sutun - 1, satir-1).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun, satir-1).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun, satir ).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun + 1, satir ).BackgroundImage = Properties.Resources.stop;
                            }
                        }
                    }
                }
            }

            if (sutun > 0)
            {
                if (e.KeyCode == Keys.Left)      //sol ok tuşuna basıldığı zaman blokları 1 sola taşıyoruz
                {
                    if (satir > 4)
                    {
                        TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 3).BackgroundImage = null;
                        TablePanel.GetControlFromPosition(sutun, satir - 4).BackgroundImage = null;
                        
                        if (sekil == 0)
                        {
                            sutun--;
                            TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 3).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 4).BackgroundImage = Properties.Resources.stop;
                        }
            
                        if (sekil == 1)
                        {
                            sutun--;
                            TablePanel.GetControlFromPosition(sutun + 2, satir - 1).BackgroundImage = null;
                            TablePanel.GetControlFromPosition(sutun + 2, satir - 2).BackgroundImage = null;

                            TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = Properties.Resources.stop;

                            TablePanel.GetControlFromPosition(sutun + 1, satir - 1).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun + 1, satir - 2).BackgroundImage = Properties.Resources.stop;
                        }
                        if (sekil == 2)
                        {
                            sutun--;
                            TablePanel.GetControlFromPosition(sutun +2, satir - 1).BackgroundImage = null;
                            TablePanel.GetControlFromPosition(sutun + 1, satir - 1).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 1).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 2).BackgroundImage = Properties.Resources.stop;
                            TablePanel.GetControlFromPosition(sutun, satir - 3).BackgroundImage = Properties.Resources.stop;
                        }
                        if (sekil == 3)
                        {
                            if (sutun > 1)
                            {
                                sutun--;
                                TablePanel.GetControlFromPosition(sutun + 2, satir).BackgroundImage = null;
                                TablePanel.GetControlFromPosition(sutun - 1, satir-1).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun, satir-1).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun, satir).BackgroundImage = Properties.Resources.stop;
                                TablePanel.GetControlFromPosition(sutun + 1, satir).BackgroundImage = Properties.Resources.stop;
                            }

                        }
                    }
                }
            }

        }

        private void süre_Tick(object sender, EventArgs e)
        {
            saniye++;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ;
            timer1.Start();
            süre.Start();
            pictureBox2.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)      //oyun alanını temizliyoruz 
        {                                                               //değerleri 0 lıyoruz.

            for (int j = 0; j<18 ; j++)
            {
                for (int k = 0; k < 10; k++)
                {

                    TablePanel.GetControlFromPosition(k, j).BackgroundImage = null;
                    
                }
            }
            satir = 0;
            sutun = 5;
            sayac = 0;
            puan = 0;
            saniye = 0;
        }

        private void TablePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
