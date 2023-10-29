using System.Linq;

namespace AmazonTest2 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inputs
            List<int> comedyReleaseTime = new List<int>() { 1, 4 };
            /*int comedyReleaseTimeCount = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 0; i < comedyReleaseTimeCount; i++)
            {
                int comedyReleaseTimeItem = Convert.ToInt32(Console.ReadLine().Trim());
                comedyReleaseTime.Add(comedyReleaseTimeItem);
            }*/

            List<int> comedyDuration = new List<int>() { 3, 2 };
            /*int comedyDurationCount = Convert.ToInt32(Console.ReadLine().Trim());
            for(int i = 0; i < comedyDurationCount; i++) 
            { 
                int comedyDurationTime = Convert.ToInt32(Console.ReadLine().Trim());
                comedyDuration.Add(comedyDurationTime);
            }*/

            List<int> dramaReleaseTime = new List<int>() { 5, 2 };
            /*int dramaReleaseTimeCount = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 0; i < dramaReleaseTimeCount; i++)
            {
                int dramaReleaseTimeItem = Convert.ToInt32(Console.ReadLine().Trim());
                dramaReleaseTime.Add(dramaReleaseTimeItem);
            }*/

            List<int> dramaDuration = new List<int>() { 2, 2 };
            /*int dramaDurationCount = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 0; i < dramaDurationCount; i++)
            {
                int dramaDurationTime = Convert.ToInt32(Console.ReadLine().Trim());
                dramaDuration.Add(dramaDurationTime);
            }*/

            // Code 
            int result = Result.MinimumTimeSpent(
                comedyReleaseTime, 
                comedyDuration, 
                dramaReleaseTime, 
                dramaDuration);

            // Output
            Console.WriteLine(result);
        }
    }

    class Result
    {
        public static int MinimumTimeSpent(
            List<int> comedyReleaseTime, 
            List<int> comedyDuration, 
            List<int> dramaReleaseTime, 
            List<int> dramaDuration)
        {
            var totalDuration = comedyDuration.Sum() + dramaDuration.Sum();
            for (int comedy = 0; comedy < comedyReleaseTime.Count; comedy++)
            {
                for (int drama = 0; drama < dramaReleaseTime.Count; drama++)
                {
                    // Comedy duration
                    var t = comedyReleaseTime[comedy] + comedyDuration[comedy];

                    // Release on future
                    if (t < dramaReleaseTime[drama])
                    {
                        t = t + (dramaReleaseTime[drama] - t);
                    }

                    // Drama duration
                    t = t + dramaDuration[comedy];

                    // Take the eairler time 
                    if (t < totalDuration)
                    {
                        totalDuration = t;
                    }
                }
            }

            for (int drama = 0; drama < dramaReleaseTime.Count; drama++)
            {
                for (int comedy = 0; comedy < comedyReleaseTime.Count; comedy++)
                {
                    // Drama duration
                    var t = dramaReleaseTime[drama] + dramaDuration[drama];

                    // Release on future
                    if (t < comedyReleaseTime[comedy])
                    {
                        t = t + (comedyReleaseTime[comedy] - t);
                    }

                    // Comedy duration
                    t = t + comedyDuration[comedy];

                    // Take the eairler time 
                    if (t < totalDuration)
                    {
                        totalDuration = t;
                    }
                }
            }
            return totalDuration;

            // TODO: Create a single List to evaluate both categories in less code 
        }
    }
}