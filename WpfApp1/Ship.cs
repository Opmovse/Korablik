using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO:Реализация существования фигур кораблей, Рандомизация кораблей на поле

namespace WpfApp1
{
    public class Ship
    {
        public enum Counts{
           Dots = 10,
           Liners = 2,
           T_Shaped = 1,
           Angled = 1,
        }

        /// <summary>
        /// ⬛
        /// </summary>
        static int[,] DotShip = new int[,]
        {
            { 0, 0 }
        };

        /// <summary>
        /// ⬛ ⬛ ⬛
        /// </summary>
        static int[,] LineShip = new int[,]
        {
            { 0, 0 },
            { 0, 1 },
            { 0, 2 },
        };

        /// <summary>
        /// ⬛ ⬛ ⬛ <br/>
        /// ⬜ ⬛ ⬜ <br/>
        /// </summary>
        static int[,] T_Ship = new int[,]
        {
            { 0, 0 },{ 0, 1 },{ 0, 2 },
                     { 1, 1 },
        };

        /// <summary>
        /// ⬛ ⬛ <br/>
        /// ⬛ ⬜ <br/>
        /// ⬛ ⬜ <br/>
        /// </summary>
        static int[,] AngledShip = new int[,]
        {
            { 0, 0 },{ 0, 1 },
            { 1, 0 },
            { 2, 0 },
        };

        /// <summary>
        /// ⬛ ⬛ <br/>
        /// ⬛ ⬛ <br/>
        /// </summary>
        static int[,] CubeShip = new int[,]
        {
            { 0, 0 },{ 0, 1 },
            { 1, 0 },{ 1, 1 },
        };
       

    }
}
