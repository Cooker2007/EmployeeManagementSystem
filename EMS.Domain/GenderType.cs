using Infrastructure.Common;
using System.Collections.Generic;

namespace EMS.Domain
{
    public class GenderType : Enumeration
    {
        protected GenderType(int value, string displayName)
            : base(value, displayName)
        {
        }

        public GenderType()
            : base()
        {
        }

        public static readonly GenderType Male = new MaleType();

        public static readonly GenderType Female = new FemaleType();

        public static readonly GenderType Other = new OtherType();

        public static readonly GenderType Unknown = new UnknownType();

        public static bool TryParse(string s, out GenderType result)
        {
            if (s != null)
            {
                var genders = GenderType.GetAll(typeof(GenderType));
                var value = s.ToLower();

                foreach (var gender in GetAll(typeof(GenderType)))
                {
                    var temp = gender as GenderType;

                    if (temp != null && temp.InternalTryParse(value, out result))
                    {
                        return true;
                    }
                }
            }
            result = GenderType.Unknown; ;
            return false;
        }

        protected virtual bool InternalTryParse(string value, out GenderType result)
        {
            result = null;
            return false;
        }

        private class MaleType : GenderType
        {
            public MaleType()
                : base(1, "Male")
            {
            }

            protected override bool InternalTryParse(string value, out GenderType result)
            {
                List<string> acceptibleValues = new List<string>
                {
                    // Lowercase values
                    "m",
                    "male",
                };

                foreach (var acceptibleValue in acceptibleValues)
                {
                    if (!value.Equals(acceptibleValue))
                    {
                        continue;
                    }

                    result = GenderType.Male;
                    return true;
                }
                result = null;
                return false;
            }
        }

        private class FemaleType : GenderType
        {
            public FemaleType()
                : base(2, "Female")
            {
            }

            protected override bool InternalTryParse(string value, out GenderType result)
            {
                List<string> acceptibleValues = new List<string>
                {
                    // Lowercase values
                    "f",
                    "female",
                };

                foreach (var acceptibleValue in acceptibleValues)
                {
                    if (!value.Equals(acceptibleValue))
                    {
                        continue;
                    }

                    result = GenderType.Female;
                    return true;
                }
                result = null;
                return false;
            }
        }

        private class OtherType : GenderType
        {
            public OtherType()
                : base(3, "Other")
            {
            }

            protected override bool InternalTryParse(string value, out GenderType result)
            {
                List<string> acceptibleValues = new List<string>
                {
                    // Lowercase values
                    "o",
                    "other",
                };

                foreach (var acceptibleValue in acceptibleValues)
                {
                    if (!value.Equals(acceptibleValue))
                    {
                        continue;
                    }

                    result = GenderType.Other;
                    return true;
                }
                result = null;
                return false;
            }
        }

        private class UnknownType : GenderType
        {
            public UnknownType()
                : base(0, "Unknown")
            {
            }

            protected override bool InternalTryParse(string value, out GenderType result)
            {
                result = null;
                return false;
            }
        }
    }
}