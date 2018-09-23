namespace Music
{
    using System;

    public class Music
    {
        private const long M = 1000000007;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            long result = AllPosiblePlaylists(n, k, l) % M;

            for (int i = 1; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    result += (CalculateCombination(n, i) * AllPosiblePlaylists(n - i, k, l)) % M;
                }
                else
                {
                    result -= (CalculateCombination(n, i) * AllPosiblePlaylists(n - i, k, l)) % M;
                }
            }

            Console.WriteLine("Possible playlists: " + result);
        }

        private static long AllPosiblePlaylists(int n, int k, int l)
        {
            long[] playlist = new long[l];
            for (int i = 0; i < playlist.Length; i++)
            {
                playlist[i] = n;
            }

            for (int i = 0; i < playlist.Length; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    if (i + j < l)
                    {
                        playlist[i + j]--;
                    }
                }
            }

            long allPosibleWays = 1;

            for (int i = 0; i < l; i++)
            {
                allPosibleWays *= playlist[i];
            }

            return allPosibleWays;
        }

        private static long CalculateFactoriel(long n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        private static long CalculateCombination(long n, long k)
        {
            return CalculateFactoriel(n) / (CalculateFactoriel(k) * CalculateFactoriel(n - k));
        }
    }
}
