//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoshopDBProgram
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Composition
    {
        public int Detail_ID { get; set; }
        public int Product_Quantity { get; set; }
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
