using System.Text;

namespace Shared.Helpers
{
    public class RandomGenerator
    {
        // Instantiate random number generator.
        // It is better to keep a single Random instance
        // and keep using Next on the same instance.
        private readonly Random _random = new Random();

        // Generates a random number within a range.
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public string RandomNumberContractor(string number)
        {
            string number1 = RandomNumber(100, 999).ToString();
            string number2 = RandomNumber(100, 999).ToString();
            return number + "-" + number1 + "-" + number2;
        }

        // Generates a random string with a given size.
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.

            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        // Generates a random password.
        // 4-LowerCase + 4-Digits + 2-UpperCase
        public string RandomPassword()
        {
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case
            passwordBuilder.Append(RandomString(4, true));

            // 4-Digits between 1000 and 9999
            passwordBuilder.Append(RandomNumber(1000, 9999));

            // 2-Letters upper case
            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }

        // Generates a random password.
        // 4-LowerCase + 4-Digits + 2-UpperCase
        public List<DateTime> RandomDate(DateTime minDt, DateTime maxDt, int elementCount)
        {
            List<DateTime> myDates = new List<DateTime>();
            //Random.Next in .NET is non-inclusive to the upper bound (@NickLarsen)
            int minutesDiff = Convert.ToInt32(maxDt.Subtract(minDt).TotalMinutes + 1);
            int value = minutesDiff / elementCount;
            for (int i = 0; i < elementCount; i++)
            {
                minDt = minDt.AddMinutes(value);
                myDates.Add(minDt);
            }
            return myDates;
        }

        public List<int> RandomList(int min, int max, int count)
        {
            List<int> candidates = RandomList(min, max).ToList();

            return candidates.Take(count).ToList();
        }

        private IEnumerable<int> RandomList(int min, int max)
        {
            List<int> candidates = new List<int>();
            for (int i = min; i <= max; i++)
            {
                candidates.Add(i);
            }
            Random rnd = new Random();
            while (candidates.Count > 0)
            {
                int index = rnd.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }
    }
}