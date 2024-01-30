using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1
{
    internal class Field
    {
        public static List<List<bool>> Field10x10 = new List<List<bool>>();
    
        static Field()
        {
            for (int i = 0; i < 10; i++)
            {
                Field10x10.Add(new List<bool>());
                for (int j = 0; j < 10; j++)
                {
                    Field10x10[i].Add(false);
                }
            }
        }

        static bool IsFree(int x, int y)
        {
            // Проверка наличия свободных точек в радиусе 1 с минимальным расстоянием 1 ячейка
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    // Пропуск проверки центральной ячейки (0, 0)
                    if (i == 0 && j == 0)
                        continue;

                    int newX = x + i;
                    int newY = y + j;

                    // Проверка, что новые координаты не выходят за пределы массива
                    if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10)
                    {
                        // Проверка наличия точек в соседней ячейке
                        if (Field10x10[newY][newX])
                            return false;
                    }
                }
            }

            return true;
        }

        static public void RandomizeField()
        {
            /*for (int i = 0; i < ((int)Ship.Counts.Liners); i++)
            {

                int randX = new Random().Next(0, 10);
                int randY = new Random().Next(0, 10);

                if (IsFree(randX, randY))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (IsFree(randX, randY)) 
                    }
                   
                }
                else break;  
            
            }
            for (int i = 0; i < ((int)Ship.Counts.T_Shaped); i++)
            {

            }
            for (int i = 0; i < ((int)Ship.Counts.Angled); i++)
            {

            }*/
            for (int i = 0; i < ((int)Ship.Counts.Dots); i++)
            {
                int randX = new Random().Next(1, 11);
                int randY = new Random().Next(1, 11);

                if (IsFree(randX, randY))
                {
                    Field10x10[randY][randX] = true;
                }
                else break;
            }

        }

        static public void PresetField()
        {
            Field10x10[1][1] = true;
            Field10x10[1][2] = true;
            Field10x10[1][3] = true;
            Field10x10[2][2] = true;

            Field10x10[1][5] = true;
            Field10x10[1][6] = true;
            Field10x10[1][7] = true;

            Field10x10[3][8] = true;

            Field10x10[4][1] = true;
            Field10x10[4][3] = true;

            Field10x10[5][1] = true;
            Field10x10[5][6] = true;
            Field10x10[6][1] = true;
            Field10x10[6][2] = true;
            Field10x10[6][8] = true;
            Field10x10[7][8] = true;
            Field10x10[7][6] = true;
            Field10x10[8][3] = true;
            Field10x10[8][8] = true;






        }
     
    }
}
