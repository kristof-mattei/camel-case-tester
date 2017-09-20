namespace CamelCaseTester
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(ToCamelCase("BUILDING"));
            Console.WriteLine(ToCamelCase("BUILDING Property"));
            Console.WriteLine(ToCamelCase("Building Property"));
            Console.WriteLine(ToCamelCase("BUILDING PROPERTY"));

            Console.WriteLine(ToCamelCaseFixed("BUILDING"));
            Console.WriteLine(ToCamelCaseFixed("BUILDING Property"));
            Console.WriteLine(ToCamelCaseFixed("Building Property"));
            Console.WriteLine(ToCamelCaseFixed("BUILDING PROPERTY"));
        }

        private static string ToCamelCaseFixed(string s)
        {
            return ToCamelCase(s, true);
        }

        private static string ToCamelCase(string s, bool fix = false)
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
                bool nextCharacterNotUppercase = !char.IsUpper(chars[i + 1]);
                bool nextCharacterSeparator = char.IsSeparator(chars[i + 1]);
                if (i > 0 
                    && hasNext // do we have a next character? 
                    && nextCharacterNotUppercase  
                    && !fix // do we apply the fix
                    && nextCharacterSeparator)
                {
                    break;
                }

                char c;
#if HAVE_CHAR_TO_STRING_WITH_CULTURE
                c = char.ToLower(chars[i], CultureInfo.InvariantCulture);
#else
                c = char.ToLowerInvariant(chars[i]);
#endif
                chars[i] = c;
            }

            return new string(chars);
        }
    }
}