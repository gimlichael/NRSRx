﻿using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Formatter.Serialization;
using Microsoft.OData;
using Microsoft.OData.Edm;
using System;
using System.Collections.Immutable;

namespace IkeMtz.NRSRx.Core.OData
{
    public class NrsrxODataSerializer : ODataResourceSerializer
    {
        private static ImmutableList<Type> DateTypes => ImmutableList.Create(
            typeof(DateTime),
            typeof(DateTimeOffset)
        );
        private static ImmutableList<Type> NumericTypes => ImmutableList.Create(
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(decimal),
            typeof(double),
            typeof(float),
            typeof(long),
            typeof(short),
            typeof(ulong),
            typeof(ushort)
        );

        public NrsrxODataSerializer(ODataSerializerProvider serializerProvider) : base(serializerProvider)
        {
        }
        public override ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
        {
            var property = base.CreateStructuralProperty(structuralProperty, resourceContext);
            if (property.Value == null)
            {
                return null;
            }
            else if (DateTypes.Contains(property.Value.GetType()) && ((dynamic)property.Value == default(DateTime)))
            {
                return null;
            }
            else if (NumericTypes.Contains(property.Value.GetType()) && (dynamic)property.Value == 0)
            {
                return null;
            }
            else
                return property;
        }
    }
}