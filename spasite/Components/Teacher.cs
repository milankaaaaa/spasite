//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace spasite.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        internal object[] id;

        public int Id_teacher { get; set; }
        public Nullable<int> Id_employee { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
