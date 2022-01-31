using Nostrum.WPF.Extensions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Nostrum.WPF.Templates
{
	public class ComboBoxTemplateSelector : DataTemplateSelector
	{
		public DataTemplate? SelectedItemTemplate { get; set; }
		public DataTemplateSelector? SelectedItemTemplateSelector { get; set; }
		public DataTemplate? DropdownItemTemplate { get; set; }
		public DataTemplateSelector? DropdownItemTemplateSelector { get; set; }

		public override DataTemplate? SelectTemplate(object item, DependencyObject container)
		{
			return container.FindVisualParent<ComboBoxItem>() != null
				? DropdownItemTemplate ?? DropdownItemTemplateSelector?.SelectTemplate(item, container)
				: SelectedItemTemplate ?? SelectedItemTemplateSelector?.SelectTemplate(item, container);
		}
	}

	public class ComboBoxTemplateSelectorExtension : MarkupExtension
	{
		public DataTemplate? SelectedItemTemplate { get; set; }
		public DataTemplateSelector? SelectedItemTemplateSelector { get; set; }
		public DataTemplate? DropdownItemsTemplate { get; set; }
		public DataTemplateSelector? DropdownItemsTemplateSelector { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return new ComboBoxTemplateSelector
			{
				SelectedItemTemplate = SelectedItemTemplate,
				SelectedItemTemplateSelector = SelectedItemTemplateSelector,
				DropdownItemTemplate = DropdownItemsTemplate,
				DropdownItemTemplateSelector = DropdownItemsTemplateSelector
			};
		}
	}
}
