using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Rocky_Utility
{
    public static class WC
    {
        public static string ImagePath = @"\img\product\";
        public static string SessionCart = "ShoppingCartSession";
        public static string SessionInquiryId = "InquirySession";

        public static string AdminRole = "Admin";
        public static string CustomerRole = "Customer";

        public const string CategoryName = "Category";

        public const string Success = "Success";
        public const string Error = "Error";

        public const string StatusPending = "Ожидание";
        public const string StatusApproved = "Подтвержден";
        public const string StatusInProcess = "В процессе";
        public const string StatusShipped = "Отправлен";
        public const string StatusCancelled = "Отменён";
        public const string StatusRefunded = "Возвращён";

    }
}
