namespace Exercise_2
{
    public class TextFinder
    {
        private List<string> _text;

        public List<string> Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public TextFinder(List<string> text)
        {
            Text = text;
        }

        public (List<string> emails, List<string> lexemes) FindEmails()
        {
            var validEmails = new List<string>();
            var lexemes = new List<string>();
            foreach (var word in Text.SelectMany(line => line.Split(' ', '\t', '\n')))
            {
                if (word.Contains('@'))
                {
                    var parts = word.Split('@');
                    if (parts.Length == 2 && parts[0].Length <= 64 && parts[1].Length <= 255)
                    {
                        var localPart = parts[0];
                        var domainPart = parts[1];
                        if (IsValidLocalPart(localPart) && IsValidDomainPart(domainPart))
                        {
                            validEmails.Add(word);
                        }
                        else
                        {
                            lexemes.Add(word);
                        }
                    }
                }
            }

            return (validEmails, lexemes);
        }

        private bool IsValidLocalPart(string localPart)
        {
            if (localPart.Length == 0 || localPart.Length > 64 || localPart.StartsWith(".") ||
                localPart.EndsWith(".") || localPart.Contains(".."))
            {
                return false;
            }

            if (localPart[0] == '"' && localPart[localPart.Length - 1] != '"')
            {
                return false;
            }

            if (localPart.Contains("\""))
            {
                return false;
            }

            // Перевірка символів
            for (int i = 0; i < localPart.Length; i++)
            {
                char c = localPart[i];
                if (c >= 0x80) // Включаємо інтернаціональні символи
                {
                    continue;
                }

                if (c == '@' || c == '<' || c == '>' || c == '[' || c == '\\' || c == ']' || c == ',' ||
                    c == ';' || c == ':' || c == '(' || c == ')' || c == ' ' || c == '\t') // обмеження символів
                {
                    if (!localPart.StartsWith("\"") || !localPart.EndsWith("\""))
                    {
                        return false;
                    }

                    if (i > 0 && localPart[i - 1] != '\\')
                    {
                        return false;
                    }
                }

                if (c == '"' && (i == 0 || localPart[i - 1] != '\\'))
                {
                    return false;
                }

                if (c == '.' && (i == 0 || i == localPart.Length - 1 || localPart[i - 1] == '.' ||
                                 localPart[i + 1] == '.'))
                {
                    return false;
                }

                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') ||
                      c == '!' || c == '#' || c == '$' || c == '%' || c == '&' || c == '\'' || c == '*' || c == '+' ||
                      c == '-' || c == '/' || c == '=' || c == '?' || c == '^' || c == '_' || c == '`' ||
                      c == '{' || c == '|' || c == '}' || c == '~' || c == '.'))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidDomainPart(string domainPart)
        {
            if (domainPart.Length == 0 || domainPart.Length > 253)
            {
                return false;
            }

            if (domainPart.StartsWith("-") || domainPart.EndsWith("-"))
            {
                return false;
            }

            var labels = domainPart.Split('.');
            if (labels.Length < 2)
            {
                return false;
            }

            foreach (var label in labels)
            {
                if (label.Length == 0 || label.Length > 63)
                {
                    return false;
                }

                if (!label.All(c => char.IsLetterOrDigit(c) || c == '-'))
                {
                    return false;
                }

                if (label.StartsWith("-") || label.EndsWith("-"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}