
namespace GamersAndMonsters.Classes.Helpers
{
    internal static class FieldsValidator
    {
        private static GameLogger _logger;

        public static void Initialize(GameLogger logger)
        {
            _logger = logger;
        }

        public static void ValidateRange(int value, int min, int max, string valueName)
        {
            if (value < min || value > max)
            {
                _logger.LogError($"Creature {valueName.ToUpper()} should between {min} - {max}");
                throw new ArgumentOutOfRangeException(valueName, $"Value should be between {min} and {max}.");
            }
        }
        
        public static void ValidateDiapason(int[] diapason, int diapasonLength, int min, int max, string diapasonName)
        {
            CheckDiapasonLength(diapason, diapasonLength);
            if (diapason.Min() < min || diapason.Max() > max)
            {
                _logger.LogError($"Creature must have {diapasonName.ToUpper()} between {min} - {max}");
                throw new ArgumentOutOfRangeException(diapasonName, $"Value should be between {min} and {max}.");
            }
        }

        private static void CheckDiapasonLength(int[] diapason, int diapasonLength)
        {
            if (diapason.Length != diapasonLength)
            {
                _logger.LogError($"Creature must have diapason length equal {diapasonLength}");
                throw new ArgumentOutOfRangeException($"Diapason length should equal {diapasonLength}");
            }
        }

        public static void ValidateName(string name, List<String> namesExisting)
        {
            CheckNameOnNullOrEmpty(name);
            CheckNameOnActualExist(name, namesExisting);
        }

        private static void CheckNameOnNullOrEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                _logger.LogError($"You can't create Creature with Name that contains only spaces or empty");
                throw new ArgumentNullException("Name cannot be empty or null.");
            }
        }

        private static void CheckNameOnActualExist(string name, List<String> namesExisting) {
            if (namesExisting.Contains(name))
            {
                _logger.LogError($"You can't create Creature with {name} is busy");
                throw new ArgumentException($"Creature {name} is busy");
            }
        }
    }
}
