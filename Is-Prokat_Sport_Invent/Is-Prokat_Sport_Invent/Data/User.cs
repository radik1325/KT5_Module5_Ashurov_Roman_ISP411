//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Is_Prokat_Sport_Invent.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserEmail { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserPhone { get; set; }
        public string UserPasport { get; set; }
        public Nullable<System.DateTime> UserDateBirth { get; set; }
        public Nullable<System.DateTime> UserLastVxodDate { get; set; }
        public Nullable<int> UserTypeVxodId { get; set; }
        public int UserGenderId { get; set; }
    
        public virtual Gender Gender { get; set; }
        public virtual Role Role { get; set; }
        public virtual TypeVxoda TypeVxoda { get; set; }
    }
}
