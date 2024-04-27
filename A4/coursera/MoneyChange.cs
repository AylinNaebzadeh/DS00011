using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class A4_1
{
        static int MoneyChange(int money)
        {
            // 1 , 5, 10
            int coins = 0;
            while (money >= 10)
            {
                money -= 10;
                coins++;
            }
            while (money >= 5)
            {
                money -= 5;
                coins++;
            }
            while (money >= 1)
            {
                money -= 1;
                coins++;
            }
            return coins;
        }
}