namespace Entity
{
    public class ValidateISBN
    {
        public bool IsValidISBN(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                return false;
            }

            isbn = isbn.Replace("-", "").Replace(" ", "");

            if (isbn.Length == 10)
            {
                return IsValidISBN10(isbn);
            }
            else if (isbn.Length == 13)
            {
                return IsValidISBN13(isbn);
            }

            return false;
        }

        private bool IsValidISBN10(string isbn)
        {
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                if (!char.IsDigit(isbn[i]))
                {
                    return false;
                }

                sum += (isbn[i] - '0') * (10 - i);
            }

            char checkDigit = isbn[9];
            if (checkDigit != 'X' && !char.IsDigit(checkDigit))
            {
                return false;
            }

            sum += (checkDigit == 'X') ? 10 : (checkDigit - '0');

            return sum % 11 == 0;
        }

        private bool IsValidISBN13(string isbn)
        {
            int sum = 0;

            for (int i = 0; i < 13; i++)
            {
                if (!char.IsDigit(isbn[i]))
                {
                    return false;
                }

                int digit = isbn[i] - '0';
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            return sum % 10 == 0;
        }
    }
}
