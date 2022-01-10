namespace RemoteDesktopManager.AddOn
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProcessArgumentBuilder
    {
        private readonly List<string> arguments = new List<string>();

        public ProcessArgumentBuilder(string defaultSwitch)
        {
            this.DefaultSwitch = defaultSwitch;
        }

        public ProcessArgumentBuilder()
        {
            this.DefaultSwitch = "-";
        }

        public string DefaultSwitch
        {
            get;
            set;
        }

        public static string PreparePathValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            if (value.StartsWith("\"") && value.EndsWith("\""))
            {
                return ExpandVariables(value);
            }

            return QuoteString(ExpandVariables(value));
        }

        public static string QuoteString(string str, string quote)
        {
            return quote + str + quote;
        }

        public static string QuoteString(string str)
        {
            return QuoteString(str, "\"");
        }

        public void AddPathValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.arguments.Add(PreparePathValue(value));
        }

        public void AddSwitch(string switchValue)
        {
            if (string.IsNullOrEmpty(switchValue))
            {
                return;
            }

            if (switchValue.StartsWith(this.DefaultSwitch))
            {
                this.AddValue(switchValue);
            }
            else
            {
                this.AddValue(this.DefaultSwitch + switchValue);
            }
        }

        public void AddSwitch(string switchValue, string value)
        {
            if (switchValue.StartsWith(this.DefaultSwitch))
            {
                this.AddValue(switchValue + value);
            }
            else
            {
                this.AddValue(this.DefaultSwitch + switchValue + value);
            }
        }

        public void AddSwitchAndPathValue(string switchValue, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.AddSwitch(switchValue);
            this.AddPathValue(value);
        }

        public void AddSwitchAndValue(string switchValue, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.AddSwitch(switchValue);
            this.AddValue(value);
        }

        public void AddSwitchPath(string switchValue, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.AddSwitch(switchValue + PreparePathValue(value));
        }

        public void AddValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.arguments.Add(value);
        }

        public void Clear()
        {
            this.arguments.Clear();
        }

        public override string ToString()
        {
            if (this.arguments.Count == 0)
            {
                return string.Empty;
            }

            return Concat(this.arguments.ToArray(), " ").Trim();
        }

        private static string Concat(Array strings, string spacer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (strings != null)
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    if (strings.GetValue(i) == null)
                    {
                        stringBuilder.Append(i == 0 ? string.Empty : spacer);
                    }
                    else
                    {
                        stringBuilder.Append(i == 0 ? string.Empty : spacer);
                        stringBuilder.Append(strings.GetValue(i));
                    }
                }
            }

            return stringBuilder.ToString();
        }

        private static string ExpandVariables(string value)
        {
            return string.IsNullOrEmpty(value) ? value : Environment.ExpandEnvironmentVariables(value);
        }
    }
}