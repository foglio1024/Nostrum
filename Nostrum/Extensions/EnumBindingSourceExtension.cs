using System;
using System.Windows.Markup;

namespace Nostrum.Extensions
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _type;

        public EnumBindingSourceExtension(Type enumType)
        {
            _type = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(_type);
        }
    }
}