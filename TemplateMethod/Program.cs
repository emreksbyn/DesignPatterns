using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;

            Console.WriteLine("Men");
            algorithm = new MenScoringAlgoritm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0,2,34)));
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgoritm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Children");
            algorithm = new ChildrenScoringAlgoritm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));
            Console.WriteLine("-------------------------------");
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = CalculeBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculeBaseScore(int hits);
    }

    class MenScoringAlgoritm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculeBaseScore(int hits)
        {
            return hits * 100;
        }
    }

    class WomenScoringAlgoritm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculeBaseScore(int hits)
        {
            return hits * 100;
        }
    }

    class ChildrenScoringAlgoritm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }

        public override int CalculeBaseScore(int hits)
        {
            return hits * 80;
        }
    }
}