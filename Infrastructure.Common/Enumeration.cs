// License
// The MIT License
// Copyright (c) 2012 Headspring
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
//software and associated documentation files (the "Software"), to deal in the Software
//without restriction, including without limitation the rights to use, copy, modify, merge,
//publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
//to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

// Enumeration class used from github from HeadspringLabs/Tarantino
// https://github.com/HeadspringLabs/Tarantino/blob/master/src/Tarantino.Core/Commons/Model/Enumerations/Enumeration.cs

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Common
{
    [Serializable]
    public abstract class Enumeration : IComparable
    {
        private readonly int value;
        private readonly string displayName;

        protected Enumeration()
        {
        }

        protected Enumeration(int value, string displayName)
        {
            this.value = value;
            this.displayName = displayName;
        }

        public int Value
        {
            get { return this.value; }
        }

        public string DisplayName
        {
            get { return this.displayName; }
        }

        public override string ToString()
        {
            return this.DisplayName;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public static IEnumerable GetAll(Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                object instance = Activator.CreateInstance(type);
                yield return info.GetValue(instance);
            }
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = this.value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            var matchingItem = parse<T, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
        {
            var matchingItem = parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T parse<T, K>(K value, string description, Func<T, bool> predicate)
            where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public virtual int CompareTo(object other)
        {
            return this.Value.CompareTo(((Enumeration)other).Value);
        }
    }
}