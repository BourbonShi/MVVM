using MVVM.Model;
using System;
using Windows.UI.Xaml.Data;

namespace MVVM.ValueConverter
{
    /// <summary>
    /// 定义一个值转换器，用于将绑定的数据格式化为指定的格式
    /// </summary>
    public class ItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            User user = value as User;
            if (user != null)
            {
                return user.Name;
            }
            else
            {
                return "you have not select!";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
