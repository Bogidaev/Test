using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PetStar.Entity;

namespace PetStar.Mapping
{
    public abstract class BaseMapping<T> : ClassMapping<T> where T : BaseEntity
    {
        protected BaseMapping(string nameTabel)
        {
            this.Table(nameTabel);
            this.Id(x => x.Id, map => map.Generator(Generators.Identity));
        }
    }
}