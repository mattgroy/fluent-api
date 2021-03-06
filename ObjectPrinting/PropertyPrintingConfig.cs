﻿using System;
using System.Reflection;

namespace ObjectPrinting
{
    public class PropertyPrintingConfig<TOwner, TPropType> : IPropertyPrintingConfig<TOwner, TPropType>
    {
        private readonly PrintingConfig<TOwner> printingConfig;
        private readonly PropertyInfo propertyInfo;

        public PropertyPrintingConfig(PrintingConfig<TOwner> printingConfig, PropertyInfo propertyInfo)
        {
            this.propertyInfo = propertyInfo;
            this.printingConfig = printingConfig;
        }

        PrintingConfig<TOwner> ITypePrintingConfig<TOwner, TPropType>.ParentConfig => printingConfig;
        PropertyInfo IPropertyPrintingConfig<TOwner, TPropType>.PropertyInfo => propertyInfo;

        public PrintingConfig<TOwner> Using(Func<TPropType, string> print)
        {
            printingConfig.ChangeSerializationForProperty(propertyInfo, print);
            return printingConfig;
        }
    }

    public interface IPropertyPrintingConfig<TOwner, TPropType> : ITypePrintingConfig<TOwner, TPropType>
    {
        PropertyInfo PropertyInfo { get; }
    }
}