﻿namespace Api.Models
{
    public class Deduction
    {
        public string Name { get; set; }
        public decimal Value { get; set; }

        public Deduction(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
