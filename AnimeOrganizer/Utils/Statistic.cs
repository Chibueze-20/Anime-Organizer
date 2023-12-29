namespace AnimeOrganizer
{
    public readonly struct Statistic
    {
        private readonly int total;
        private readonly int tens;
        private readonly int lows;
        private readonly int rated;
        private readonly int sum; //sum of all ratings >0

        public Statistic(int total, int tens, int lows, int rated, int sum)
        {
            this.total = total;
            this.tens = tens;
            this.lows = lows;
            this.rated = rated;
            this.sum = sum;
        }

        public int Mids()
        {
            return total - (tens + lows);
        }
        public int Unrated() {
            return total - rated;
        }

        public double AverageRating()
        {
            return (double)sum / rated;
        }
        public override string ToString()
        {
            string format_message = "Total Anime Organized:{0}\nNumber of Anime Rated:{1}\n" +
               "Number of Anime rated 10:{2}\nNumber of Anime rated below 6:{3}\n" +
               "Number of Anime rated between 6 and 9: {4}\nNumber of Anime unrated:{5}\n" +
               "Average Anime Rating:{6:N1}";
            string message = string.Format(format_message, total, rated, 
                tens, lows,Mids(), Unrated(), AverageRating());
            return message;
        }
    }
}
