using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreSession.Models
{
    [Serializable]
    public class Predictor
    {
        private string _name;
        private List<int> _ratings;
        private List<int> _predictions;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<int> Predictions { get => _predictions; set => _predictions = value; }
        public List<int> Ratings { get => _ratings; set => _ratings = value; }

        public Predictor()
        {
            Predictions = new List<int>();
            Ratings = new List<int> ();
        }
        public int GetLastPredictions()
        {
            return Predictions[Predictions.Count - 1];

        }
        public int[] GetHistoryPredictions()
        {
            int[] predictions = Predictions.ToArray<int>();
            return predictions;
        }
        public List<int> ListHistoryPredictions()
        {
            return Predictions;
        }
        public List<int> SetHistoryPredictions(List<int> listPredictions)
        {
            Predictions = listPredictions;
            return Predictions;
        }
        public void AddPrediction(int number)
        {
            Predictions.Add(number);
        }
        public void AddRating(int originalNumber, int predictionNumber)
        {
            Ratings.Add(Evaluation(originalNumber, predictionNumber));
        }
        public decimal GetRating()
        {
            decimal average = 0;
            foreach (int item in Ratings)
            {
                average += item;
            }
            average /= Ratings.Count;
            
            return decimal.Round(average, 2, MidpointRounding.AwayFromZero); ; 
        }
        public int Evaluation(int originalNumber, int predictedNumber)
        {
            int difference = Math.Abs(originalNumber - predictedNumber);
            if (difference <= 20)
            {
                return 5;
            }
            else if (difference > 20 && difference <= 40)
            {
                return 4;
            }
            else if (difference > 40 && difference <= 60)
            {
                return 3;
            }
            else if (difference > 60 && difference <= 80)
            {
                return 2;
            }
            else if (difference > 80)
            {
                return 1;
            }
            else return 0;
        }
    }
}
