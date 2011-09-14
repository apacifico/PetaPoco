using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetaPoco
{
    public static class MapperRegistry
    {
        //[ThreadStatic]
        private static Database _current;

        //[ThreadStatic]
        private static Dictionary<PetaPoco.Database, IMapper> registry = new Dictionary<Database, IMapper>();

        public static void Register(PetaPoco.Database database, IMapper mapper)
        {
            if(!registry.ContainsKey(database)) registry.Add(database, mapper);
        }

        public static void Cleanup()
        {
            registry.Clear();
            _current = null;
        }

        public static IMapper Mapper {
        get {
            if (!registry.ContainsKey(_current)) return null;
            else return registry[_current];
            }
        }

        public static IMapper LookupMapper(PetaPoco.Database database)
        {
            if (!registry.ContainsKey(database)) return null;
            else return registry[database];
        }

        public static Database Current { 
            set {
                    _current = value; 
                }
        }
    }
}
