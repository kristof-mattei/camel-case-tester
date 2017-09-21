namespace CamelCase
{
    public class CamelCaseConverter
    {
        public static string ToCamelCaseRight(string s)
        {
            return ToCamelCase(s, true);
        }

        public static string ToCamelCaseWrong(string s)
        {
            return ToCamelCase(s, false);
        }

        private static string ToCamelCase(string s, bool spaceUppercaseFix)
        {
            if (string.IsNullOrEmpty(s) || !char.IsUpper(s[0]))
            {
                return s;
            }

            char[] chars = s.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (i == 1 && !char.IsUpper(chars[i]))
                {
                    break;
                }

                bool hasNext = (i + 1 < chars.Length);

                if (i > 0
                    && hasNext // do we have a next character? 
                    && !char.IsUpper(chars[i + 1])
                )
                {
                    // if the next character is a space, which is not considered uppercase 
                    // (otherwise we wouldn't be here...)
                    // we want to ensure that the following:
                    // 'FOO bar' is rewritten as 'foo bar', and not as 'foO bar'
                    // The code was written in such a way that the first word in uppercase
                    // ends when if finds an uppercase letter followed by a lowercase letter.
                    // now a ' ' (space, (char)32) is considered not upper
                    // but in that case we still want our current character to become lowercase
                    if (spaceUppercaseFix && char.IsSeparator(chars[i + 1]))
                    {
                        chars[i] = ToLower(chars[i]);
                    }

                    break;
                }

                chars[i] = ToLower(chars[i]);
            }

            return new string(chars);
        }

        private static char ToLower(char c)
        {
#if HAVE_CHAR_TO_STRING_WITH_CULTURE
                c = char.ToLower(c, CultureInfo.InvariantCulture);
#else
            c = char.ToLowerInvariant(c);
#endif
            return c;
        }
    }
}