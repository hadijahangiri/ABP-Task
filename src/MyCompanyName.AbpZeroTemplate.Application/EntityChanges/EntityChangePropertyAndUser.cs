using Abp.EntityHistory;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using System.Collections.Generic;

namespace MyCompanyName.AbpZeroTemplate.EntityChanges
{
    public class EntityChangePropertyAndUser
    {
        public EntityChange EntityChange { get; set; }
        public List<EntityPropertyChange> PropertyChanges { get; set; }
        public User User { get; set; }
    }
}
