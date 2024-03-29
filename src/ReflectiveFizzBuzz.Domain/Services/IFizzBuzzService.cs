﻿using System.Runtime.CompilerServices;
using ReflectiveFizzBuzz.Domain.ValueTypes;
[assembly: InternalsVisibleTo("ReflectiveFizzBuzz.Domain.UnitTests"),
           InternalsVisibleTo("ReflectiveFizzBuzz.E2ETests"),
           InternalsVisibleTo("ReflectiveFizzBuzz.Infrastructure.Console")]

namespace ReflectiveFizzBuzz.Domain.Services;


internal interface IFizzBuzzService
{
    string Classify(PositiveInteger number);
}