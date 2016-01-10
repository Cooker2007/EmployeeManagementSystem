using System;
using Infrastructure.Common;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Domain
{
    public class Gender : Enumeration
    {
        public Gender() { }

        private Gender(InternalGenderEnum internalGenderEnum)
            : base((int)internalGenderEnum, internalGenderEnum.ToString())
        {
        }

        public static readonly Gender Male = new MaleType();

        public static readonly Gender Female = new FemaleType();

        public static readonly Gender Other = new OtherType();

        public static readonly Gender Unknown = new UnknownType();

        public static bool TryParse(string s, out Gender result)
        {
            if (s != null)
            {
                var genders = GetAll(typeof(Gender)).Cast<Gender>();
                var value = s.ToLower();

                foreach (var gender in genders)
                {
                    if (gender.InternalTryParse(value, out result))
                    {
                        return true;
                    }
                }
            }
            result = Gender.Unknown;
            return false;
        }

        protected virtual bool InternalTryParse(string value, out Gender result)
        {
            result = null;
            return false;
        }

        class MaleType : Gender
        {
            public MaleType()
                : base(InternalGenderEnum.Male)
            {
            }

            protected override bool InternalTryParse(string value, out Gender result)
            {
                var acceptibleValues = new List<string>
                {
                    // Lowercase values
                    "m",
                    "male",
                };
                if (acceptibleValues.Contains(value))
                {
                    result = Gender.Male;
                    return true;
                }
                result = null;
                return false;
            }
        }

        class FemaleType : Gender
        {
            public FemaleType()
                : base(InternalGenderEnum.Female)
            {
            }

            protected override bool InternalTryParse(string value, out Gender result)
            {
                var acceptibleValues = new List<string>
                {
                    // Lowercase values
                    "f",
                    "female",
                };

                if (acceptibleValues.Contains(value))
                {
                    result = Gender.Female;
                    return true;
                }
                result = null;
                return false;
            }
        }

        class OtherType : Gender
        {
            public OtherType()
                : base(InternalGenderEnum.Other)
            {
            }

            protected override bool InternalTryParse(string value, out Gender result)
            {
                var acceptibleValues = new List<string>
                {
                    // Lowercase values
                    "o",
                    "other",
                };

                if (acceptibleValues.Contains(value))
                {
                    result = Gender.Other;
                    return true;
                }
                result = null;
                return false;
            }
        }

        class UnknownType : Gender
        {
            public UnknownType()
                : base(InternalGenderEnum.Unknown)
            {
            }

            protected override bool InternalTryParse(string value, out Gender result)
            {
                result = Gender.Unknown;
                return false;
            }
        }

        enum InternalGenderEnum
        {
            Unknown = 0,
            Male = 1,
            Female = 2,
            Other = 3
        }
    }
}