using System.Text.RegularExpressions;

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
            if (localPart.Length == 0 || localPart.Length > 64)
            {
                return false;
            }

            if (localPart[0] == '.' || localPart[localPart.Length - 1] == '.')
            {
                return false;
            }

            for (int i = 0; i < localPart.Length; i++)
            {
                char c = localPart[i];
                if (!(char.IsLetterOrDigit(c) || c == '!' || c == '#' || c == '$' || c == '%' || c == '&' ||
                      c == '\'' || c == '*' || c == '+' || c == '-' || c == '/' || c == '=' || c == '?' || c == '^' ||
                      c == '_' || c == '`' || c == '{' || c == '|' || c == '}' || c == '~' || c == '.'))
                {
                    return false;
                }

                if (c == '.' && (i == 0 || i == localPart.Length - 1 || localPart[i - 1] == '.' ||
                                 localPart[i + 1] == '.'))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidDomainPart(string domainPart)
        {
            if (domainPart.Length == 0 || domainPart.Length > 255)
            {
                return false;
            }

            if (domainPart[domainPart.Length - 1] == '.')
            {
                return false;
            }

            var labels = domainPart.Split('.');
            if (labels.Length != 2)
            {
                return false;
            }

            foreach (var label in labels)
            {
                if (label.Length == 0 || label.Length > 63)
                {
                    return false;
                }

                foreach (var c in label)
                {
                    if (!(char.IsLetterOrDigit(c) || c == '-' || c == '_'))
                    {
                        return false;
                    }
                }

                if (label[0] == '-' || label[label.Length - 1] == '-')
                {
                    return false;
                }
            }

            return true;
        }

    }
}