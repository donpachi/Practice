using System;
using System.Collections;
using System.Collections.Generic;

namespace MinimumCoinChange
{
    class Program
    {
        public int MinimumCoins(int[] coins, int amount){
            int[] dp = new int[amount + 1];
            for(int i = 1; i < dp.Length; i++)dp[i] = Int32.MaxValue;
            dp[0] = 0;
            //for every subsequent amount up to amount
            for (int i = 1; i <= amount; i++){
                //for every amount, check each coin possibility
                for (int j = 0; j < coins.Length; j++){
                    //as long as the amount is separable into coins
                    //and if the min amount of coins at the amount minus the
                    //current coin value + 1 is less than the current value, replace
                    if (coins[j] <= i && dp[i - coins[j]] + 1 < dp[i])
                        dp[i] = dp[i - coins[j]] + 1;
                }
            }
            return dp[amount];
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.MinimumCoins(new int[]{1,2,5,10,20}, 204));
        }
    }
}
