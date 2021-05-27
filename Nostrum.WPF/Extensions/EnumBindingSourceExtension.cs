using System;
using System.Windows.Markup;

namespace Nostrum.WPF.Extensions
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private readonly Type _type;

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