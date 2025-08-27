namespace MaintenanceTrack.API.Extension.Services
{
    public class PrivateMethod
    {
        private static Random _random = new Random();

        public static string GenerateRequestTrackingNumber()
        {
            string prefix = "MAIN";
            string datePart = DateTime.UtcNow.ToString("yyyy-MM-dd"); // e.g., 2025-08-26
            string uniquePart = GenerateUniquePart();                 // e.g., AB#12345

            return $"{prefix}-{datePart}-{uniquePart}";
        }

        private static string GenerateUniquePart()
        {
            string alphaPart = GenerateRandomLetters(2);    // AB
            string specialChar = GenerateSpecialCharacter(); // #
            string numberPart = _random.Next(10000, 99999).ToString(); // 5 digits

            return $"{alphaPart}{specialChar}{numberPart}";
        }

        private static string GenerateRandomLetters(int length)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(letters, length)
                                        .Select(s => s[_random.Next(s.Length)])
                                        .ToArray());
        }

        private static string GenerateSpecialCharacter()
        {
            string specials = "#@$%&*!?";
            return specials[_random.Next(specials.Length)].ToString();
        }
    }
}
