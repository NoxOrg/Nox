using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Data.Helper
{
    /// <summary>
    /// Navigation helper class to return SVG Icon Path based on keyNames
    /// </summary>
    public class IconHelper
    {
        /// <summary>
        /// Helper method to return Icon Svg path via key
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string GetIconSvgPath(string Key)
        {
            switch (Key.Trim().ToLower())
            {
                case "employees":
                    return "<path d=\"M12 12c2.21 0 4-1.79 4-4s-1.79-4-4-4-4 1.79-4 4 1.79 4 4 4zm0 2c-2.67 0-8 1.34-8 4v2h16v-2c0-2.66-5.33-4-8-4z\"/>";
                case "customers":
                    return "<path d=\"M14,7h-4C8.9,7,8,7.9,8,9v6h2v7h4v-7h2V9C16,7.9,15.1,7,14,7z\"/><circle cx=\"12\" cy=\"4\" r=\"2\"/>";
                case "vendingmachines":
                    return "<path d=\"M20.54 5.23l-1.39-1.68C18.88 3.21 18.47 3 18 3H6c-.47 0-.88.21-1.16.55L3.46 5.23C3.17 5.57 3 6.02 3 6.5V19c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V6.5c0-.48-.17-.93-.46-1.27zM12 17.5L6.5 12H10v-2h4v2h3.5L12 17.5zM5.12 5l.81-1h12l.94 1H5.12z\"/>";
                case "test":
                    return "<path d=\"M19.8,18.4L14,10.67V6.5l1.35-1.69C15.61,4.48,15.38,4,14.96,4H9.04C8.62,4,8.39,4.48,8.65,4.81L10,6.5v4.17L4.2,18.4 C3.71,19.06,4.18,20,5,20h14C19.82,20,20.29,19.06,19.8,18.4z\"></path>";
                default:
                    return String.Empty;
            }            
        }
    }

}